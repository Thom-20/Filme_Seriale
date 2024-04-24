using Filme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seriale
{
    public class Serial
    {
        // proprietati auto-implemented
        public string nume {  get; set; }
        public string regizor { get; set; }
        public string genSerial {  get; set; }
        public float durata { get; set; }
        public int lansare {  get; set; }
        public int sezoane { get; set; }
        public int episoade { get; set; }
        public int idserial { get; set; }

        private const char SEPARATOR_PRINCIPAL_FISIER = ';';

        private const int IDSERIAL = 0;
        private const int NUME = 1;
        private const int REGIZOR = 2;
        private const int GEN = 3;
        private const int DURATA = 4;
        private const int LANSARE = 5;
        private const int EPISOADE = 6;
        private const int SEZOANE = 7;
 

        // string nume, regizor, gen;
        // float durata;
        // int lansare, sezoane, episoade;


        //	Constructor fara parametri
        public Serial()
        {
            nume = string.Empty;
            regizor = string.Empty;
            genSerial = string.Empty;
            lansare = 0;
            durata = 0;
            sezoane = 0;
            episoade = 0;
        }

        //	Constructor cu parametri
        public Serial(string _nume, string _regizor, string _gen, int _lansare, float _durata, int _episoade, int _sezoane)
        {
            nume = _nume;
            regizor = _regizor;
            genSerial = _gen;
            lansare = _lansare;
            episoade = _episoade;
            sezoane = _sezoane;
            durata = _durata;
        }

        public static void AfisareSerialelansare(Serial[] seriale, int nrSeriale, int lansare)
        {
            bool exista = false;// Variabilă de verificare

            Console.WriteLine("Serialele sunt:");
            for (int contor = 0; contor < nrSeriale; contor++)
            {
                if (seriale[contor].lansare == lansare)
                {
                    string infoSerial = seriale[contor].Info();
                    Console.WriteLine(infoSerial);
                    exista = true; // setarea variabilelei la true daca am gasit >=1 film
                }
            }
            if (!exista)
            {
                Console.WriteLine("Nu exista seriale lansate in anul mentionat!");
            }
        }

        public static void AfisareSeriale(Serial[] seriale, int nrSeriale)
        {
            Console.WriteLine("Serialele sunt:");
            for (int contor = 0; contor < nrSeriale; contor++)
            {
                string infoSerial = seriale[contor].Info();
                Console.WriteLine(infoSerial);
            }
        }

        //	Metoda care returneaza informatiile despre film sub forma unui sir de caractere
        public string Info()
        {
            string info = $"ID: {idserial}\n Numele serialului: {nume}\n Regizor: {regizor}\n Gen: {genSerial}\n An lansare: {lansare}\n Sezoane: {sezoane}\n Episoade: {episoade}\n Durata unui episod: {durata}\n";
            return info;
        }

        //constructor cu un singur parametru de tip string care reprezinta o linie dintr-un fisier text
        public Serial(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            this.idserial = Convert.ToInt32(dateFisier[IDSERIAL]);
            this.nume = dateFisier[NUME];
            this.regizor = dateFisier[REGIZOR];
            this.genSerial = dateFisier[GEN];
            this.lansare = Convert.ToInt32(dateFisier[LANSARE]);
            this.durata = Convert.ToInt32(dateFisier[DURATA]);
            int ep = Convert.ToInt32(EPISOADE);
            this.episoade = ep;
            this.sezoane = Convert.ToInt32(dateFisier[SEZOANE]);
        }
        public string ConversieLaSir_PentruFisier()
        {
            string obiectFilmPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                IDSERIAL.ToString(),
                (nume ?? " NECUNOSCUT "),
                (regizor ?? " NECUNOSCUT "),
                (genSerial ?? " NECUNOSCUT "),
                (Convert.ToString(lansare) ?? " 0 "),
                (Convert.ToString(durata) ?? " 0 "),
                (Convert.ToString(episoade) ?? " 0 "),
                (Convert.ToString(sezoane) ?? " 0 "));

            return obiectFilmPentruFisier;
        }
    }

}

