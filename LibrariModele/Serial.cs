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
        public string gen {  get; set; }
        public float durata { get; set; }
        public int lansare {  get; set; }
        public int sezoane { get; set; }
        public int episoade { get; set; }
        public int idserial { get; set; }



        // string nume, regizor, gen;
        // float durata;
        // int lansare, sezoane, episoade;


        //	Constructor fara parametri
        public Serial()
        {
            nume = string.Empty;
            regizor = string.Empty;
            gen = string.Empty;
            lansare = 0;
            durata = 0;
            sezoane = 0;
            episoade = 0;
        }

        //	Constructor cu parametri
        public Serial(string _nume, string _regizor, string _gen, int _lansare, int _episoade, int _sezoane, float _durata)
        {
            nume = _nume;
            regizor = _regizor;
            gen = _gen;
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
            string info = $" Numele serialului: {nume}\n Regizor: {regizor}\n Gen: {gen}\n An lansare: {lansare}\n Sezoane: {sezoane}\n Episoade: {episoade}\n Durata unui episod: {durata}\n";
            return info;
        }
    }

}

