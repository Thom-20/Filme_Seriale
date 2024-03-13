using System;
using System.Runtime.InteropServices;
using Filme;
using Seriale;
using StocareDate;

namespace Filme_Seriale
{
    class Program
    {
        static void Main()
        {
            Stocare stocFilme = new Stocare();
            Film filmnou = new Film();
            int nrFilme = 0;

            Stocare stocSeriale = new Stocare();
            Serial serialnou = new Serial();
            int nrSeriale = 0;

            string optiune;
            int ok = 0;
            do
            {
                Console.WriteLine("ATENTIE: Dupa fiecare film/serial citit de la tastatura " +
                    "acesta trebuie salvat pentru a ramane in lista respectiva a acestuia!");
                Console.WriteLine();
                Console.WriteLine("F. Citire informatii film de la tastatura");
                Console.WriteLine("S. Citire informatii serial de la tastatura");
                Console.WriteLine("AF. Afisarea listei de filme");
                Console.WriteLine("AS. Afisarea listei de seriale");
                Console.WriteLine("Y. Salvare filme/seriale in lista");
                Console.WriteLine("X. Inchidere program");

                Console.WriteLine("Alegeti o optiune");
                optiune = Console.ReadLine();
                switch (optiune.ToUpper())
                {
                    case "F":
                       filmnou  = CitireFilmTastatura();
                        ok = 1;

                    break;

                    case "S":
                        serialnou = CitireSerialTastatura();
                        ok = 2;

                    break;

                    case "AF":
                        Film[] filme = stocFilme.GetFilme(out nrFilme);
                        AfisareFilme(filme, nrFilme); 
                    break;

                    case "AS":
                        Serial[] seriale = stocSeriale.GetSeriale(out nrSeriale);
                        AfisareSeriale(seriale, nrSeriale);
                    break;

                    case "Y":
                        if (ok == 1)
                        {
                            int idfilm = nrFilme + 1;
                            filmnou.idfilm = idfilm;
                            //adaugare film in lista
                            stocFilme.AddFilm(filmnou);

                            break;
                        }
                        else if(ok == 2)
                        {
                            int idserial = nrSeriale + 1;
                            serialnou.idserial = idserial;
                            //adaugare serial in lista
                            stocSeriale.AddSerial(serialnou);

                            break;
                        }
                        break;

                    case "X":
                        return;
                    default:
                        Console.WriteLine("Optiune inexistenta");
                    break;

                }
            } while (optiune.ToUpper() != "X");
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
            int lansare = int.Parse(_lansare); // sau: int an_lansare = Convert.ToInt32(lansareStr);

            Console.WriteLine("Introduceti durata filmului:");
            string _durata = Console.ReadLine();
            float durata = float.Parse(_durata); // sau: float an_lansare = Convert.ToSingle(lansareStr);

            Film film = new Film( nume, regizor, gen, lansare, durata);

            return film;
        }

        public static Serial CitireSerialTastatura()
        {
            Console.WriteLine("Introduceti numele serialului:");
            string nume = Console.ReadLine();

            Console.WriteLine("Introduceti regizorul serialului:");
            string regizor = Console.ReadLine();

            Console.WriteLine("Introduceti genul serialului:");
            string gen = Console.ReadLine();

            Console.WriteLine("Introduceti anul lansarii serialului:");
            string _lansare = Console.ReadLine();
            int lansare = int.Parse(_lansare); // sau: int lansare = Convert.ToInt32(_lansare);

            Console.WriteLine("Introduceti numarul de episoade serialului:");
            string _episoade = Console.ReadLine();
            int episoade = Convert.ToInt32(_episoade);// sau: int episoade = int.Parse(_episoade);

            Console.WriteLine("Introduceti numarul de sezoane a serialului:");
            string _sezoane = Console.ReadLine();
            int sezoane = int.Parse(_sezoane); // sau: int sezoane = Convert.ToInt32(_sezoane);

            Console.WriteLine("Introduceti durata serialului:");
            string _durata = Console.ReadLine();
            float durata = float.Parse(_durata); // sau: float an_lansare = Convert.ToSingle(lansareStr);

            Serial serial = new Serial(nume, regizor, gen, lansare, episoade, sezoane , durata);

            return serial;
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
        public static void AfisareSeriale(Serial[] seriale, int nrSeriale)
        {
            Console.WriteLine("Serialele sunt:");
            for (int contor = 0; contor < nrSeriale; contor++)
            {
                string infoSerial = seriale[contor].Info();
                Console.WriteLine(infoSerial);
            }
        }
    }
}


