namespace _08zOrnekler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MatematikselIslemler mat = new MatematikselIslemler();

            Urun urun1 = new Urun();
            urun1.Id = 1;
            urun1.Adi = "Bilgisayar";
            urun1.Adet = 4;
            urun1.KdvOran = 18;
            urun1.Fiyat = 10650.20;
            urun1.AraToplamFiyat = urun1.Adet * urun1.Fiyat;
            urun1.KdvFiyati = mat.KdvFiyatHesapla(urun1.AraToplamFiyat, urun1.KdvOran);
            urun1.GenelToplamFiyat = urun1.AraToplamFiyat + urun1.KdvFiyati;


            Console.WriteLine("{0} Idli {1} ürünün {2} adet {3} fiyattan satış işlemi sonrası {4} kdv oranı ile ara toplam {5}, kdv {6}, genel toplam {7} ", urun1.Id, urun1.Adi, urun1.Adet, urun1.Fiyat, urun1.KdvOran, urun1.AraToplamFiyat, urun1.KdvFiyati, urun1.GenelToplamFiyat);


        }
    }
}