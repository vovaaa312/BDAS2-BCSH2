using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.Model
{
    internal class Veterinar
    {
        private int id { get;  }
        private string jmeno { get; set; }
        private string prijmeni { get; set; }
        private string tel_cislo { get; set; }
        private string email { get; set; }
        private int plat { get; set; }
        private DateTime narozeni { get; set; }
        private DateTime nastup { get; set; }
        private string specializace { get; set; }
        private int id_oddeleni { get; set; }

        public Veterinar(int id, string jmeno, string prijmeni, string tel_cislo, string email, int plat, DateTime narozeni, DateTime nastup, string specializace, int id_oddeleni)
        {
            this.id = id;
            this.jmeno = jmeno;
            this.prijmeni = prijmeni;
            this.tel_cislo = tel_cislo;
            this.email = email;
            this.plat = plat;
            this.narozeni = narozeni;
            this.nastup = nastup;
            this.specializace = specializace;
            this.id_oddeleni = id_oddeleni;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
