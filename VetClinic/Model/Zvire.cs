using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.Model
{
    internal class Zvire
    {
        private int id { get; }
        private int nazev { get; set; }

        public Zvire(int id, int nazev)
        {
            this.id = id;
            this.nazev = nazev;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
