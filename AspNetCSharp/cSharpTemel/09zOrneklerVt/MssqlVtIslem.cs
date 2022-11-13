using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09zOrneklerVt
{
    internal class MssqlVtIslem : IVeritabaniIslemleri
    {
        public void Duzenleme(Urunler urun)
        {
            Console.WriteLine("Mssql Veritabanına {0} isimli ürünün düzenlenme işlemi yapıldı.", urun.Adi);
        }

        public void Ekle(Urunler urun)
        {
            Console.WriteLine("Mssql Veritabanına {0} isimli ürünün eklenme işlemi yapıldı.", urun.Adi);
        }

        public void Listeleme(Urunler urun)
        {
            Console.WriteLine("Mssql Veritabanına {0} isimli ürünün listeleme işlemi yapıldı.", urun.Adi);
        }

        public void Silme(Urunler urun)
        {
            Console.WriteLine("Mssql Veritabanına {0} isimli ürünün silme işlemi yapıldı.", urun.Adi);
        }
    }
}
