namespace _10VirtualMethods
{

    internal class Program
    {
        static void Main(string[] args)
        {

            SqlServerVeritabani sqlServerVeritabani = new SqlServerVeritabani();
            sqlServerVeritabani.VeritabaninaKaydet();
            sqlServerVeritabani.VeritabanindanSil();

            MysqlVeritabani mysqlVeritabani = new MysqlVeritabani();
            mysqlVeritabani.VeritabanindanSil();
            mysqlVeritabani.VeritabaninaKaydet();

            Console.ReadLine();
        }
    }

    class VeritabaniIslemleri
    {
        public virtual void VeritabaninaKaydet() // virtual olarak oluşturulan methodlar miras olarak alınan inheritance olarak kullanımı sağlanan diğer classlarda da aynı method bulunyorsa bu method çalışmaz aynı isimde kullanılan method çalışır.
        {
            Console.WriteLine("Default olarak ana Veritabanına  eklendi.");
        }
        public virtual void VeritabanindanSil()
        {
            Console.WriteLine("Default olarak ana Veritabanından silindi.");
        }
    }
    class MysqlVeritabani : VeritabaniIslemleri
    {
        //MySQL'e Özgün methodlar buraya eklenecek.
        public override void VeritabaninaKaydet()
        {
            Console.WriteLine("MYSQL olarak ana Veritabanına  eklendi.");
        }
    }
    class SqlServerVeritabani : VeritabaniIslemleri
    {
        //SQL'e Özgün methodlar buraya eklenecek.
        public override void VeritabaninaKaydet() // Virtual sınıfına alternatif olarak yazdığımız method
        {
            Console.WriteLine("SQL Veritabanına eklendi.");
        }

    }


}
