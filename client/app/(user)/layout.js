import Header from "../_components/Header";

export default function UserLayout({ children }) {
  return (
    <>
      <Header />
      <body>{children}</body>
    </>
  );
}
