using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.Model
{
    internal class Majitel
    {
        private int id { get;  }
        private int jmeno { get; set; }
        private int prijmeni { get; set; }
        private string tel_cislo { get; set; }
        private string email { get; set; }
        private int id_adresa { get; set; }

        public Majitel(int id, int jmeno, int prijmeni, string tel_cislo, string email, int id_adresa)
        {
            this.id = id;
            this.jmeno = jmeno;
            this.prijmeni = prijmeni;
            this.tel_cislo = tel_cislo;
            this.email = email;
            this.id_adresa = id_adresa;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
