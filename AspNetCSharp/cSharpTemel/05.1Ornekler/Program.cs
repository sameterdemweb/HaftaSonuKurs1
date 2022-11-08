namespace _05._1Ornekler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AsalSayiMi(18);
            AsalSayiMi(22);
            AsalSayiMi(98);
        }

        private static void AsalSayiMi(int sayi)
        {
            bool asalMi = true;
            for (int i = 2; i < sayi; i++)
            {
                if (sayi % i == 0)
                {
                    asalMi = false;
                    break;
                }
            }
            if (asalMi == true)
            {
                Console.WriteLine("Bu sayı asaldır");
            }
            else
            {
                Console.WriteLine("Bu sayı asal değildir");
            }
            Console.ReadLine();
        }
    }
}