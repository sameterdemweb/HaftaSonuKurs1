namespace _09zOrnekler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Robotlar robot1 = new Robotlar();
            robot1.SeriNo = 1235512;
            robot1.Sarj();

            Yoneticiler yonetici1 = new Yoneticiler();
            yonetici1.Adi = "Samet";
            yonetici1.Soyadi = "Erdem";
            yonetici1.Yonet();

            Calisanlar calisan1 = new Calisanlar();
            calisan1.Adi = "Mehmet";
            calisan1.Soyadi = "Ulusoy";
            calisan1.Calis();
        }
    }


    interface IYemek
    {
        void Yemek(); // Ortak olara kullanılacak methodlar
    }

    interface IYonet
    {
        void Yonet();// Ortak olara kullanılacak methodlar
    }

    interface ICalis
    {
        void Calis();// Ortak olara kullanılacak methodlar
    }

    interface IDinlen
    {
        void Dinlen();// Ortak olara kullanılacak methodlar
    }

    interface ISarjOl
    {
        void Sarj();// Ortak olara kullanılacak methodlar
    }

    interface IInsan
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
    }

    class Yoneticiler : IYemek, IYonet, IDinlen, IInsan
    {
        public void Yemek() { Console.WriteLine("Yemek Yedim");}
        public void Yonet() { Console.WriteLine("Yönettim"); }
        public void Dinlen() { Console.WriteLine("Ben Yöneticiyim odamda şekerleme yapıyorum."); }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
    }

    class Calisanlar: IYemek, ICalis, IDinlen, IInsan
    {
        public void Yemek() { Console.WriteLine("Yemek Yedim"); }
        public void Dinlen() { Console.WriteLine("Ben çalışanım bahçede çuğara içerek dinleniyorum."); }
        public void Calis() {   Console.WriteLine("Çalıştım"); }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
    }

    class Robotlar: ICalis, ISarjOl
    {
        public void Calis() { Console.WriteLine("Calistim."); }
        public void Sarj() { Console.WriteLine("Şarj Oldum"); }
        public int SeriNo { get; set; }
    }

}