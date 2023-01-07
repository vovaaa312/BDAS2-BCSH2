using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.Model
{
    public class VeterinariMazlickyPohled
    {
        public string Jmeno_mazlicek { get; set; }
        public string Druh_zvire { get; set; }
        public string Jmeno_majitele { get; set; }
        public string Primeni_majitele { get; set; }
        public string Tel_cislo { get; set; }
        public string Email { get; set; }
        public string Nazev_mesta { get; set; }
        public string Nazev_ulice { get; set; }
        public int Cislo_ulice { get; set; }
        public string Psc_kod { get; set; }
        public string Stat { get; set; }
        public string Datum_nastupu { get; set; }
        public string Datum_propusteni { get; set; }
        public string Nazev_oddeleni { get; set; }


    }
}
