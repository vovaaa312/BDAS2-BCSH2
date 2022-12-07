using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.Model
{
    public class Klinika
    {
        private int id { get; }
        private string nazev_kliniky { get; set; }
        private string email { get; set;}
        private string tel_cislo { get; set; }
        private Adresa adresa { get; set; }

        public Klinika(int id, string nazev_kliniky, string email, string tel_cislo, Adresa adresa)
        {
            this.id = id;
            this.nazev_kliniky = nazev_kliniky;
            this.email = email;
            this.tel_cislo = tel_cislo;
            this.adresa = adresa;
        }
    }
}
