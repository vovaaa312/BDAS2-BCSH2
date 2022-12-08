using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.Model
{
    internal class Krev
    {
        private int id { get; }

        public Krev(int id)
        {
            this.id = id;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
