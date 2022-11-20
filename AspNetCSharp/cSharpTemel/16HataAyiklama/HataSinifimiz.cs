using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16HataAyiklama
{
    internal class HataSinifimiz : Exception  // Kendi hata classimizi oluştuduk. Exception hata classından miras aldık bunun özelliklerine erişebiliyoruz artık.
    {
        public HataSinifimiz(string message) : base(message) // Miraas aldığığımız classa mesaaj bilgisini gönderdik.
        {

        }

    }
}
