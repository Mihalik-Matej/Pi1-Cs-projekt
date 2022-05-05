using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pi1_Cs_projekt
{
    class Trieda
    {
        private string meno;
        private string odbor;
        private string triednyUcitel;
        private int rocnik;


        public Trieda()
        {
        }

        public Trieda(string meno, string odbor, string triednyUcitel, int rocnik)
        {
            this.Meno = meno;
            this.Odbor = odbor;
            this.TriednyUcitel = triednyUcitel;
            this.Rocnik = rocnik;
        }

        public string Meno { get => meno; set => meno = value; }
        public string Odbor { get => odbor; set => odbor = value; }
        public string TriednyUcitel { get => triednyUcitel; set => triednyUcitel = value; }
        public int Rocnik { get => rocnik; set => rocnik = value; }

    }
}
