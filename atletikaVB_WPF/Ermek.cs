using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atletikaVB_WPF
{
    internal class Ermek
    {
        public string Verseny { get; set; }
        public string Nem { get; set; }
        public string Orszag { get; set; }
        public string Nev { get; set; }
        public string Eredmeny { get; set; }
        public string Rekord { get; set; }
        public int Helyezes { get; set; }

    
        public Ermek(string sor)
        {
            string[] adatok = sor.Split(';');
            Verseny = adatok[0];
            Nem = adatok[1];
            Orszag = adatok[2];
            Nev = adatok[3];
            Eredmeny = adatok[4];
            Rekord = adatok[5];
            Helyezes = int.Parse(adatok[6]);
        }
        public Ermek(string verseny, string nem, string orszag, string nev, string eredmeny, string rekord, int helyezes)
        {
            Verseny = verseny;
            Nem = nem;
            Orszag = orszag;
            Nev = nev;
            Eredmeny = eredmeny;
            Rekord = rekord;
            Helyezes = helyezes;
        }

        public override string ToString()
        {
            return $"{Verseny};{Nem};{Orszag};{Nev};{Eredmeny};{Rekord};{Helyezes}";
        }

    }
}
