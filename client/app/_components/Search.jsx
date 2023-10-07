import { BiSearch } from "react-icons/bi";

function Search() {
  return (
    <div className="flex flex-row rounded-md  px-4  shadow-lg  border w-1/2 items-center justify-center">
      <input
        type="text"
        className="w-full focus:outline-none p-2 "
        name=""
        placeholder="Search..."
        id=""
      />
      <button className="">
        <BiSearch className="self-center" size={30} />
      </button>
    </div>
  );
}

export default Search;
