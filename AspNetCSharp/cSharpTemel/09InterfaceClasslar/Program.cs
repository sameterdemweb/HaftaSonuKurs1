namespace _09InterfaceClasslar
{
   class Program
    {
        static void Main(string[] args)
        {
            Islemler islemler = new Islemler();
            Islemler islemler2 = new();
            islemler.Ekleme(new Musteri { Id = 1, Adi = "Samet", Soyadi = "Erdem" }); // Birinci yöntem
            Musteri musteri = new Musteri
            {
                Id = 2,
                Adi = "Özge",
                Soyadi = "Erdem",
                MusteriAdresi = "Hürriyet Mahallesi"
            };
            //İkinci yöntem
            islemler.Ekleme(musteri); // İkinci yöntem


            Musteri musteri2 = new Musteri();//üçüncü yöntem
            musteri2.Id = 3;//üçüncü yöntem
            musteri2.Adi = "Ali";//üçüncü yöntem
            musteri2.Soyadi = "Erdem";//üçüncü yöntem
            musteri2.MusteriAdresi = "Hürriyet Mahallesi";//üçüncü yöntem
            islemler.Ekleme(musteri2); // üçüncü yöntem

            Console.WriteLine(musteri.Adi);
            Console.WriteLine(musteri2.Adi);
           
            Calisan calisan = new Calisan { Id = 1, Adi = "Ahmet", Soyadi = "Sarıkaya" };
            //islemler.Ekleme(calisan);// Hata Neden var? - Ekleme işleminde ben müşteri istiyorum sen bana çalışan veriyorsun.
            islemler.Duzenle(calisan);// Hata Yok çünkü IInsan olarak tanımlanmış var? - Ekleme işleminde ortak bilgiler mevcut ve bunları istiyorum diyor


            islemler.Duzenle(calisan); // üçüncü yöntem
        }

    }
    
    interface IInsan // Baş Harfine ayrıca interface sınıfıın ilk harfi olan büyük "I" eklenir.!
    {
        int Id { get; set; }
        string Adi { get; set; }
        string Soyadi { get; set; }

    }

    class Musteri : IInsan // Tanımladığımız değişkenleri tanımlamaz ise iki nokta üst üsteden sonra hata verecek! Solda Çıkan Düzelme kısmından "Ara Birimi Uygula" dediğimizde bütün değerleri set etti fakat görüntü kötü
    {
        //public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string adi { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string soyadi { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Id { get; set; }//Interface ile gelen interface tarafında tanımlanan özellikler!
        public string Adi { get; set; }//Interface ile gelen interface tarafında tanımlanan özellikler!
        public string Soyadi { get; set; } //Interface ile gelen interface tarafında tanımlanan özellikler!
        public string MusteriAdresi { get; set; } // Musteriye özel tanımladığımız özellik

    }

    class Calisan : IInsan
    {
        public int Id { get; set; } //Interface ile gelen interface tarafında tanımlanan özellikler!
        public string Adi { get; set; } //Interface ile gelen interface tarafında tanımlanan özellikler!
        public string Soyadi { get; set; } //Interface ile gelen interface tarafında tanımlanan özellikler!
        public string Departman { get; set; } // Departmana özel tanımladığımız özellik

    }

    class Islemler
    {
        public void Ekleme(Musteri gelenDeger)
        {
            Console.WriteLine("Eklendi"); // Gelen değerleri ektran yazdır.
        }
        public void Duzenle(IInsan gelenDeger)
        {
            Console.WriteLine("Düzenlendi"); // Gelen değerleri ekrana yazdır.
        }
    }

}
