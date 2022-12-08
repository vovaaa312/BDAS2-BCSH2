using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.Model
{
    internal class VysledekSluzby
    {
        private int id { get;  }
        private Boolean jeHotov { get; set; }
        private Boolean jePlanovana { get; set; }
        private DateTime zacatek { get; set; }
        private DateTime ukonceni { get; set; }
        private int id_sluzba { get; set; }
        private int id_krev { get; set; }
        private int id_pet_karty { get; set; }

        public VysledekSluzby(int id, bool jeHotov, bool jePlanovana, DateTime zacatek, DateTime ukonceni, int id_sluzba, int id_krev, int id_pet_karty)
        {
            this.id = id;
            this.jeHotov = jeHotov;
            this.jePlanovana = jePlanovana;
            this.zacatek = zacatek;
            this.ukonceni = ukonceni;
            this.id_sluzba = id_sluzba;
            this.id_krev = id_krev;
            this.id_pet_karty = id_pet_karty;
        }

        public VysledekSluzby(int id, bool jeHotov, bool jePlanovana, DateTime zacatek, int id_sluzba, int id_krev, int id_pet_karty)
        {
            this.id = id;
            this.jeHotov = jeHotov;
            this.jePlanovana = jePlanovana;
            this.zacatek = zacatek;
            this.id_sluzba = id_sluzba;
            this.id_krev = id_krev;
            this.id_pet_karty = id_pet_karty;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
