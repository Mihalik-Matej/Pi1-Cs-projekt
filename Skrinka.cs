using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pi1_Cs_projekt
{
    class Skrinka
    {
        private int cislo;
        private string poznamka;
        private Ziak vlastnik;

        public Skrinka()
        {
        }

        public Skrinka(int cislo, string poznamka, Ziak vlastnik)
        {
            this.Cislo = cislo;
            this.Poznamka = poznamka;
            this.Vlastnik = vlastnik;
        }

        public int Cislo { get => cislo; set => cislo = value; }
        public string Poznamka { get => poznamka; set => poznamka = value; }
        internal Ziak Vlastnik { get => vlastnik; set => vlastnik = value; }
    }
}
