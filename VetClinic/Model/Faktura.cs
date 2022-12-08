using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.Model
{
    internal class Faktura
    {
        private int id { get; }
        private float konecna_cena { get; set; }
        private string popis { get; set; }
        private int id_sluzba { get; set; }
        private int id_pet_karty { get; set; }

        public Faktura(int id, float konecna_cena, string popis, int id_sluzba, int id_pet_karty)
        {
            this.id = id;
            this.konecna_cena = konecna_cena;
            this.popis = popis;
            this.id_sluzba = id_sluzba;
            this.id_pet_karty = id_pet_karty;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
