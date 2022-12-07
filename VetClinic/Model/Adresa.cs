using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.Model
{
    public class Adresa
    {
        private int id;
        private string nazev_mista { get; set; }
        private string nazev_ulice { get; set; }
        private int cislo_ulice { get; set; }
        private int psc_kod { get; set; }
        private string stat { get; set; }

        public Adresa(int id, string nazev_mista, string nazev_ulice, int cislo_ulice, int psc_kod, string stat)
        {
            this.id = id;
            this.nazev_mista = nazev_mista;
            this.nazev_ulice = nazev_ulice;
            this.cislo_ulice = cislo_ulice;
            this.psc_kod = psc_kod;
            this.stat = stat;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public  string shortToString()
        {
            return nazev_mista + " " +nazev_ulice + " " + cislo_ulice;
        }
    }
}
