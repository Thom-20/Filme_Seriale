using System;
using Filme;

namespace StocareDate
{
    public class StocareFilme
    {
        private const int NR_MAX_FILME = 50;

        private Film[] filme;
        private int nrFilme;


        public StocareFilme()
        {
            filme = new Film[NR_MAX_FILME];
            nrFilme = 0;
        }

        public void AddFilm(Film film)
        {
            filme[nrFilme] = film;
            nrFilme++;
        }
        public Filme.Film[] GetFilmelansare(out int nrFilme, int lansare)
        {
            nrFilme = 0;
            Film[] filmeGasite = new Film[this.nrFilme]; // Inițializăm un vector pentru a stoca filmele găsite

            for (int i = 0; i < this.nrFilme; i++)
            {
                if (filme[i] != null && filme[i].lansare == lansare)
                {
                    filmeGasite[nrFilme++] = filme[i]; // Adăugăm filmul găsit în vectorul de filme și incrementăm numărul de filme găsite
                }
            }
            return filmeGasite; 
        }
        public Film[] GetFilme(out int nrFilme)
        {
            nrFilme = this.nrFilme;
            return filme;
        }
        public Film GetFilm(string nume)
        {
            for (int i = 0; i < nrFilme; i++)
            {
                if (filme[i] != null && filme[i].nume == nume)
                {
                    return filme[i];
                }
            }
            return null; // Returnăm null dacă nu găsim niciun film cu numele dat
        }
        public static Film CitireFilmTastatura()
        {
            Console.WriteLine("Introduceti numele filmului:");
            string nume = Console.ReadLine();

            Console.WriteLine("Introduceti regizorul filmului:");
            string regizor = Console.ReadLine();

            Console.WriteLine("Introduceti genul filmului:");
            string gen = Console.ReadLine();

            Console.WriteLine("Introduceti anul lansarii filmului:");
            string _lansare = Console.ReadLine();
            int lansare = int.Parse(_lansare); // sau: int lansare = Convert.ToInt32(lansareStr);

            Console.WriteLine("Introduceti durata filmului:");
            string _durata = Console.ReadLine();
            float durata = float.Parse(_durata); // sau: float lansare = Convert.ToSingle(lansareStr);

            Film film = new Film(nume, regizor, gen, lansare, durata);

            return film;
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
    }
}