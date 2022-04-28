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
        private List<Ziak> ziacivTriede;

        public Trieda()
        {
        }

        public string Meno { get => meno; set => meno = value; }
        public string Odbor { get => odbor; set => odbor = value; }
        public string TriednyUcitel { get => triednyUcitel; set => triednyUcitel = value; }
        public int Rocnik { get => rocnik; set => rocnik = value; }
        internal List<Ziak> ZiacivTriede { get => ziacivTriede; set => ziacivTriede = value; }
    }
}
