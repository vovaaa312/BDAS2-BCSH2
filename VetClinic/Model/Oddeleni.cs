using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.Model
{
    internal class Oddeleni
    {
        private int id { get;  }
        private string nazev { get; set; }
        private int id_klinika{ get; set; }

    public Oddeleni(int id, string nazev, int id_klinika)
        {
            this.id = id;
            this.nazev = nazev;
            this.id_klinika = id_klinika;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
