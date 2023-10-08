from fastapi import FastAPI, File, UploadFile
from fastapi.middleware.cors import CORSMiddleware
from pydantic import BaseModel
import gensim, uvicorn, json, uuid
import pandas as pd
from pdfquery import PDFQuery

class Recommend(BaseModel):
    prompt: str

app = FastAPI()

origins = ["*"]

app.add_middleware(
    CORSMiddleware,
    allow_origins=origins,
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)

def corpus(text:str, tags = [], tokens_only=False, row = ""):
    tokens = gensim.utils.simple_preprocess(text)
    if tokens_only:
        return tokens
    else:
        doc = gensim.models.doc2vec.TaggedDocument(tokens, tags=tags)
        doc.mtitle = row.to_dict()
        return doc

@app.on_event("startup")
async def startup():
    app.model = gensim.models.doc2vec.Doc2Vec.load("gensim_small.tea")
    app.train_corpus = []
    app.df = pd.read_csv("./teapot_small.csv")
    app.df = app.df.fillna("")
    app.df.rename(columns={"author_id":"owner_id"}, inplace=True)
    app.df[['owner_id', 'project_id']] = app.df[['owner_id', 'project_id']].astype(int)
    for i, row in app.df.iterrows():
        app.train_corpus.append(corpus(row["project_description"], row["keywords"].split(", ") if "," in row["keywords"] else row["keywords"].split("; "), row=row))
    
@app.get("/projects/{page}")
async def projects(page:int = 0):
    return json.loads(app.df.to_json(orient="records"))[page*25:(page+1)*25]

@app.post("/recommend")
async def recommend(item: Recommend):
    inferred_vec = app.model.infer_vector(corpus(item.prompt, tags=[], tokens_only=True))
    sims = app.model.dv.most_similar([inferred_vec], topn=10)
    similars = []
    for i in app.train_corpus:
        for j in sims:
            if (j[0] in i.tags) and (i not in similars):
                similars.append(i)
    return [i.mtitle for i in similars]

@app.post("/resume")
async def resume(cv_file: UploadFile):
    contents = cv_file.file.read()
    filename = f"./resumes/{str(uuid.uuid4())}.pdf"
    with open(filename, 'wb') as f:
        f.write(contents)
    pdf = PDFQuery(filename)
    pdf.load()

    # Use CSS-like selectors to locate the elements
    text_elements = pdf.pq('LTTextLineHorizontal')

    # Extract the text from the elements
    text = [t.text for t in text_elements if t.text]
    parsed_pdf = {
        "phone": text[0].split(" · ")[0],
        "email": text[0].split(" · ")[1],
        "website": text[0].split(" · ")[2],
        "address": text[1],
        "resume": " ".join(text[2:]),
    }
    return parsed_pdf

if __name__ == "__main__":
    uvicorn.run("main:app", host="0.0.0.0", port=80)

