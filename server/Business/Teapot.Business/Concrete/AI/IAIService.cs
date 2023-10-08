using Newtonsoft.Json;
using Teapot.DataAccess.Contexts;
using Teapot.Entities.Concrete;

namespace Teapot.Business.Concrete.AI
{
    public interface IAIService
    {
        Task WriteToDatabase();
    }

    public class AIManager : IAIService
    {
        private readonly Teapot418DbContext _context;

        public AIManager(Teapot418DbContext context)
        {
            _context = context;
        }

        public async Task WriteToDatabase()
        {
            using (var client = new HttpClient())
            {
                int i = 0;
                while (true)
                {
                    string response = string.Empty;
                    try
                    {
                        response = await client.GetAsync($"https://multicoloredroundcad.uysalibov.repl.co/projects/{i}")
                                                     .Result
                                                     .Content
                                                     .ReadAsStringAsync();

                        var deserialized = JsonConvert.DeserializeObject<List<Root>>(response);
                        if (deserialized == null || deserialized.Count < 1)
                            break;
                        await _context.Projects.AddRangeAsync(deserialized.Select(p => new Project
                        {
                            StartDate = p.StartDate,
                            Description = p.Description,
                            FieldsOfScience = p.FieldsOfScience,
                            GeographicScope = p.GeographicScope,
                            Keywords = p.Keywords,
                            OwnerId = p.OwnerId,
                            ParticipantAge = p.ParticipantAge,
                            ParticipationTasks = p.ParticipationTasks,
                            ProjectStatus = p.ProjectStatus,
                            ProjectUrlExternal = p.ProjectUrlExternal,
                            Title = p.Title,
                            ProjectUrl = null
                        }).ToList());
                        await _context.SaveChangesAsync();
                        i++;
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
            }
        }
    }

    public class Root
    {
        [JsonProperty("project_description")]
        public string Description { get; set; }
        [JsonProperty("keywords")]
        public string Keywords { get; set; }
        [JsonProperty("project_name")]
        public string Title { get; set; }
        [JsonProperty("project_url_external")]
        public string ProjectUrlExternal { get; set; }
        [JsonProperty("fields_of_science")]
        public string FieldsOfScience { get; set; }
        [JsonProperty("project_status")]
        public string ProjectStatus { get; set; }
        [JsonProperty("geographic_scope")]
        public string GeographicScope { get; set; }
        [JsonProperty("participant_age")]
        public string ParticipantAge { get; set; }
        [JsonProperty("participation_tasks")]
        public string ParticipationTasks { get; set; }
        [JsonProperty("start_date")]
        public string StartDate { get; set; }
        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }
    }
}
