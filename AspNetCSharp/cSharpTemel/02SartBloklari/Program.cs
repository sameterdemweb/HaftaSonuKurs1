namespace _02SartBloklari
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sayi1 = 20;
            int sayi2 = 30;
            int sayi3 = 40;

            if (sayi1 < sayi2 )
            {
                Console.WriteLine("Sayi 1 sayi 2 den küçüktür. Sayı: 1 {0}, Sayı: 2 {1}", sayi1, sayi2);
            }
            else
            {
                Console.WriteLine("Sayi 2 sayi 1 den küçüktür yada eşittir. Sayı: 1 {0}, Sayı: 2 {1}", sayi1, sayi2);
            }


            // if / else if / else

            int sayimiz = 10;
            if (sayimiz == 10)
            {
                Console.WriteLine("Sayımız 10dur.");
            }
            else if (sayimiz == 20)
            {
                Console.WriteLine("Sayımız 20dir.");
            }
            else
            {
                Console.WriteLine("Sayımız 10 ve 20 değildir.");
            }
            Console.ReadLine();


            int switchSayimiz = 10;
            //Switch bloklarının kullanımı
            switch (switchSayimiz)
            {
                case 10:  // Sayimiz 10 olma durumunda
                    Console.WriteLine("Sayımız 10dur.");
                    break;// ilgili swtich şart bloğundan olayı kes yani noktala bu şekilde süslü parantezin dışına çıkar.
                case 20:
                    Console.WriteLine("Sayımız 20dir.");
                    break;
                default://Hiçbir case'e uymuyor sie default olarak yapması gereken işlemi yapar.
                    Console.WriteLine("Sayımız 10 ve 20 değildir.");
                    break;
            }
            Console.ReadLine();
        }
    }
}