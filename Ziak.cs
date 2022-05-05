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
        private DateTime datumNarodenia;
        private Trieda trieda;

        public Ziak()
        {
        }

        public Ziak(string menoPriezvisko, int poradoveCislo, string pohlavie, int vek, DateTime datumNarodenia, Trieda trieda)
        {
            this.MenoPriezvisko = menoPriezvisko;
            this.PoradoveCislo = poradoveCislo;
            this.Pohlavie = pohlavie;
            this.Vek = vek;
            this.DatumNarodenia = datumNarodenia;
            this.Trieda = trieda;
        }

        public string MenoPriezvisko { get => menoPriezvisko; set => menoPriezvisko = value; }
        public int PoradoveCislo { get => poradoveCislo; set => poradoveCislo = value; }
        public string Pohlavie { get => pohlavie; set => pohlavie = value; }
        public int Vek { get => vek; set => vek = value; }
        public DateTime DatumNarodenia { get => datumNarodenia; set => datumNarodenia = value; }
        public Trieda Trieda { get => trieda; set => trieda = value; }
    }
}
