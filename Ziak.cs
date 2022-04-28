using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pi1_Cs_projekt
{
    class Ziak
    {
        private string menoPriezvisko;
        private int poradoveCislo;
        private string pohlavie;
        private int vek;

        public Ziak()
        {
        }

        public string MenoPriezvisko { get => menoPriezvisko; set => menoPriezvisko = value; }
        public int PoradoveCislo { get => poradoveCislo; set => poradoveCislo = value; }
        public string Pohlavie { get => pohlavie; set => pohlavie = value; }
        public int Vek { get => vek; set => vek = value; }
    }
}
