using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.Model
{
    internal class Mazlicek
    {
        private int id { get; }
        private int id_zvire { get; set; }
        private string jmeno { get; set; }
        private int id_majitel { get; set; }

        public Mazlicek(int id, int id_zvire, string jmeno, int id_majitel)
        {
            this.id = id;
            this.id_zvire = id_zvire;
            this.jmeno = jmeno;
            this.id_majitel = id_majitel;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
