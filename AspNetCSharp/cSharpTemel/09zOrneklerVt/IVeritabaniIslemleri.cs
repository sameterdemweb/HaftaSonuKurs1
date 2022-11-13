using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09zOrneklerVt
{
    internal interface IVeritabaniIslemleri
    {
        void Ekle(Urunler urun);
        void Silme(Urunler urun);
        void Duzenleme(Urunler urun);
        void Listeleme(Urunler urun);
    }
}
