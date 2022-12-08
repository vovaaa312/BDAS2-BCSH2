using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.Model
{
    internal class PetKarta
    {
        private int id { get;  }
        private DateTime nastup { get; set; }
        private DateTime propusteni { get; set; }
        private int id_mazlicke { get; set; }
        private int id_oddeleni { get; set; }

        public PetKarta(int id, DateTime nastup, DateTime propusteni, int id_mazlicke, int id_oddeleni)
        {
            this.id = id;
            this.nastup = nastup;
            this.propusteni = propusteni;
            this.id_mazlicke = id_mazlicke;
            this.id_oddeleni = id_oddeleni;
        }

        public PetKarta(int id, DateTime nastup, int id_mazlicke, int id_oddeleni)
        {
            this.id = id;
            this.nastup = nastup;
            this.id_mazlicke = id_mazlicke;
            this.id_oddeleni = id_oddeleni;
        }
    }
}
