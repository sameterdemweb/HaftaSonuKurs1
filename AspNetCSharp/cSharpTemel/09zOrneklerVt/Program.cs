namespace _09zOrneklerVt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Urunler urun1 = new Urunler { Id = 1, Adi = "Kalem", Fiyati = 7, StokAdet = 100 };

            MssqlVtIslem mssqlVtIslem = new MssqlVtIslem();
            mssqlVtIslem.Ekle(urun1);

            OracleVtIslem oracleVtIslem = new OracleVtIslem();
            oracleVtIslem.Ekle(urun1);
        }
    }
}