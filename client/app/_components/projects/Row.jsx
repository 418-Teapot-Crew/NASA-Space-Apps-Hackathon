const Row = ({ label, value }) => {
  return (
    <div className="bg-gray-50 py-2 px-12 mb-2">
      <span className="font-bold">{label} : </span>
      <span>{Array.isArray(value) ? value.join(", ") : value}</span>
    </div>
  );
};

export default Row;
