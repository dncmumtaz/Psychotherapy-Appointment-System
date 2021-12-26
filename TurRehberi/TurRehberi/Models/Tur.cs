using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurRehberi.Models
{
    public class Tur
    {
        public int Id { get; set; }
        public string TurAdi { get; set; }
        public string Aciklama { get; set; }
        public string Sehir { get; set; }
        public string Tip { get; set; }
        public double? Fiyat { get; set; }
        public string Ulasim { get; set; }
        public double? Puan { get; set; }
        public string Fotograf { get; set; }
        
    }
}
