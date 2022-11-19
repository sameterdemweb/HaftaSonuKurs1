using System.Collections;

namespace _14Koleksiyonlar
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Collection Array List Kullanımı
            ArrayList Sehirler = new ArrayList();  //Sınır yok
            Sehirler.Add("Ankara");
            Sehirler.Add("İstanbul");
            Sehirler.Add("Tekirdağ"); //Object türünde herangi bir şey gönderilebilir.
            foreach (string sehir in Sehirler)
            {
                Console.WriteLine(sehir);
            }

            Sehirler.Add(5);// foreach içerisine alırsak hata verir çünkü string değil
            Console.WriteLine(Sehirler[3]);
            Console.ReadLine();
            // ########## Tip güvenli Collectionlar ile çalışmalıyız!




            //// TipGuvenliListlerleCalisma();

            //List<MusteriDegerleri> musteriler = new List<MusteriDegerleri>();  //1. yöntem tanımlayıp tek tek eklemek
            //musteriler.Add(new MusteriDegerleri { Id = 1, AdiSoyadi = "Samet Erdem" });
            //musteriler.Add(new MusteriDegerleri { Id = 2, AdiSoyadi = "Özge Ulusoy Erdem" });
            //musteriler.Add(new MusteriDegerleri { Id = 3, AdiSoyadi = "Ege Ali Erdem" });

            //List<MusteriDegerleri> musteriler2 = new List<MusteriDegerleri> //1. yöntem tanımlarken toplu eklemek
            //    {
            //        new MusteriDegerleri{Id=1,AdiSoyadi="Ferhat Falan" },
            //        new MusteriDegerleri{Id=2,AdiSoyadi="Samet Falan" },
            //        new MusteriDegerleri{Id=3,AdiSoyadi="Ahmet Falan" },
            //        new MusteriDegerleri{Id=4,AdiSoyadi="Furkan Falan" },
            //        new MusteriDegerleri{Id=5,AdiSoyadi="Mehmet Falan" },
            //        new MusteriDegerleri{Id=5,AdiSoyadi="Gamze Falan" }
            //    };

            //foreach (MusteriDegerleri m in musteriler)
            //{
            //    Console.WriteLine("Müşteri id:{0} Adı ve Soyadı: {1}", m.Id, m.AdiSoyadi);
            //}
            //Console.ReadLine();

            //foreach (MusteriDegerleri m in musteriler2)
            //{
            //    Console.WriteLine("Müşteri id:{0} Adı ve Soyadı: {1}", m.Id, m.AdiSoyadi);
            //}
            //Console.ReadLine();


            // ProfesyonelCalismaNesneOlusturma();

        }

        private static void ProfesyonelCalismaNesneOlusturma()
        {
            List<MusteriDegerleri> musteriler = new List<MusteriDegerleri>();  //1. yöntem tanımlayıp tek tek eklemek
            musteriler.Add(new MusteriDegerleri { Id = 1, AdiSoyadi = "Samet Erdem" });
            musteriler.Add(new MusteriDegerleri { Id = 2, AdiSoyadi = "Özge Ulusoy Erdem" });
            musteriler.Add(new MusteriDegerleri { Id = 3, AdiSoyadi = "Ege Ali Erdem" });


            //List<MusteriDegerleri> musteriler2 = new List<MusteriDegerleri> //1. yöntem tanımlarken toplu eklemek
            //    {
            //        new MusteriDegerleri{Id=1,AdiSoyadi="Ferhat Falan" },
            //        new MusteriDegerleri{Id=2,AdiSoyadi="Samet Falan" },
            //        new MusteriDegerleri{Id=3,AdiSoyadi="Ahmet Falan" },
            //        new MusteriDegerleri{Id=4,AdiSoyadi="Furkan Falan" },
            //        new MusteriDegerleri{Id=5,AdiSoyadi="Mehmet Falan" },
            //        new MusteriDegerleri{Id=5,AdiSoyadi="Gamze Falan" }
            //    };

            foreach (MusteriDegerleri m in musteriler)
            {
                Console.WriteLine("Müşteri id:{0} Adı ve Soyadı: {1}", m.Id, m.AdiSoyadi);
            }
            Console.ReadLine();

            //foreach (MusteriDegerleri m in musteriler2)
            //{
            //    Console.WriteLine("Müşteri id:{0} Adı ve Soyadı: {1}", m.Id, m.AdiSoyadi);
            //}
            //Console.ReadLine();


        }


        private static void TipGuvenliListlerleCalisma()
        {
            List<string> sehirIsimleri = new List<string>();  // Liste nesnesini kullanmak istiyorum string tipinde newle!
            sehirIsimleri.Add("Tekirdağ");
            sehirIsimleri.Add("İstanbul");
            sehirIsimleri.Add("Ankara");
            sehirIsimleri.Add("izmir");
            //sehirIsimleri.Add(5);//Hata verir çünkü int tipinde değer gönderdik.!

            foreach (string sehir in sehirIsimleri)
            {
                Console.WriteLine(sehir);
            }

            Console.ReadLine();
        }

     
    }



    class MusteriDegerleri  //Bir nesne oluşturup çalışıyoruz çünkü ; Genellikle veritabanı programlama yaptığımız için veritabanındaki tablolarımız karşılığını nesne halinde tutarız. Kayıtları bu şekilde veritabanından çekerek listeye atarız ve o listeyi kullanıcıya gösteririz bu bağlamda direk nesnelerle çalışmak önemli !
    {
        public int Id { get; set; }
        public string AdiSoyadi { get; set; }


    }
}
