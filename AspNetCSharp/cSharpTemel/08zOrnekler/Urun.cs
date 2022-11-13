using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08zOrnekler
{
    internal class Urun
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public double Fiyat { get; set; }
        public int Adet { get; set; }
        public int KdvOran { get; set; }
        public double KdvFiyati { get; set; }
        public double AraToplamFiyat { get; set; }
        public double GenelToplamFiyat { get; set; }
    }
}
