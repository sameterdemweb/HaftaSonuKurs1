using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08zOrnekler
{
    internal class MatematikselIslemler
    {
        public double KdvFiyatHesapla(double aratoplam, int kdvorani)
        {
            return (aratoplam / 100) * kdvorani; ;
        }
    }
}
