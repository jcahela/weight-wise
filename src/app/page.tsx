import Image from "next/image";

export default function Page() {
  return (
    <main className="flex min-h-screen flex-col justify-between p-24">
      <Image
        src="/images/Air_Bike_0.jpg"
        alt="Air Bike"
        width={500}
        height={500}
      />
    </main>
  );
}
