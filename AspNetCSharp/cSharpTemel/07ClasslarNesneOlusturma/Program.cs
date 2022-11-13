namespace _07ClasslarNesneOlusturma
{
    internal class Program
    {
        static void Main(string[] args)
        {
         
            Musteri musteri1 = new Musteri();
            musteri1.Ad = "Mehmet";
            musteri1.Soyad = "Ulusoy";
            musteri1.Sehir = "Çorlu";

            Console.WriteLine(musteri1.Ad);

        }
    }
}