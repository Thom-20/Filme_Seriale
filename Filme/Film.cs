using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filme
{

    public class Film
    {

        // proprietati auto-implemented
        public string nume { get; set; }
        public string regizor { get; set; }
        public string gen { get; set; }
        public float durata { get; set; }
        public int lansare { get; set; }
        public int idfilm { get; set; }
        //string nume, regizor, gen;
        //float durata;
        //int lansare;


        //	Constructor fara parametri
        public Film()
        {
            nume = string.Empty;
            regizor = string.Empty;
            gen = string.Empty;
            lansare = 0;
            durata = 0;
        }

        //	Constructor cu parametri
        public Film(string _nume, string _regizor, string _gen, int _lansare, float _durata)
        {
            nume = _nume;
            regizor = _regizor;
            gen = _gen;
            lansare = _lansare;
            durata = _durata;
        }
        public static void AfisareFilmelansare(Film[] filme, int nrFilme, int lansare)
        {
            bool exista = false;// Variabilă de verificare

            Console.WriteLine("Filmele sunt:");
            for (int contor = 0; contor < nrFilme; contor++)
            {
                if (filme[contor].lansare == lansare)
                {
                    string infoFilm = filme[contor].Info();
                    Console.WriteLine(infoFilm);
                    exista = true; // setarea variabilelei la true daca am gasit >=1 film
                }
            }
            if (!exista)
            {
                Console.WriteLine("Nu exista filme lansate in anul mentionat!");
            }
        }

        public static void AfisareFilme(Film[] filme, int nrFilme)
        {
            Console.WriteLine("Filmele sunt:");
            for (int contor = 0; contor < nrFilme; contor++)
            {
                string infoFilm = filme[contor].Info();
                Console.WriteLine(infoFilm);
            }
        }

        //	Metoda care returneaza informatiile despre film sub forma unui sir de caractere
        public string Info()
        {
            string info = $" Numele filmului: {nume}\n Regizor: {regizor}\n Gen: {gen}\n An lansare: {lansare}\n Durata: {durata}\n";
            return info;
        }
    }
}