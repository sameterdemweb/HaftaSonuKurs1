namespace _11AbstractClasslar
{
    abstract class Veritabani
    {
        public void Ekle() // Her durumda aynı olan method
        {
            Console.WriteLine("Ekleme Yapıldı");
        }
        public abstract void Silme(); // Silme işlemi veritbanlarında farklı yapılıyorsa tamamlanmış method oluşturuyoruz ve bunu zorunlu olarak tip olarak atanan diğer classlardan istenir.
    }
    class SqlVeritabani : Veritabani
    {
        public override void Silme()
        {
            throw new NotImplementedException();
        }
    }
    class OraclelVeritabani : Veritabani
    {
        public override void Silme() // Silme Zorunlu olarak tanımlanacak.
        {
            Console.WriteLine("Oracle Silindi Yapıldı");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Veritabani veritabani1 = new SqlVeritabani();
            veritabani1.Ekle();
            veritabani1.Silme();

            Veritabani veritabani2 = new OraclelVeritabani();
            veritabani1.Ekle();
            veritabani2.Silme();


         

            Console.ReadLine();
        }
    }
}
