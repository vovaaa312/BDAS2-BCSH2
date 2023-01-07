using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.Model
{
    public class VeterinariVysledkyPohled
    {
        public string Jmeno_mazlicek { get; set; }
        public string JeHotovy { get; set; }
        public string JePlanovany { get; set; }
        public string Datum_zacatku { get; set; }
        public string Datum_ukonceni { get; set; }
        public int Glukoza { get; set; }
        public int Bilkovina { get; set; }
        public int Mocovina { get; set; }
        public int Bilirubin { get; set; }
        public int RBC { get; set; }
        public int HGB { get; set; }
        public int HCT { get; set; }
    }
}
