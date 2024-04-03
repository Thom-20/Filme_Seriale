using System;
using System.Configuration;
using System.IO;
using Filme;
using Seriale;
using StocareDate;
using StocareFisier;

namespace Filme_Seriale
{
    class Program
    {
        static void Main()
        {
            
            string numeFisier1 = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie1 = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier1 = locatieFisierSolutie1 + "\\" + numeFisier1;
            StocareFilmeFisier adminFilme = new StocareFilmeFisier(caleCompletaFisier1);
            StocareFilme stocFilme = new StocareFilme();
           
            Film filmnou = new Film();
            int nrFilme = 0;
            

            StocareSeriale stocSeriale = new StocareSeriale();
            Serial serialnou = new Serial();
            int nrSeriale = 0;

            
            
           

            string numeFisier2 = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie2 = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier2 = locatieFisierSolutie2 + "\\" + numeFisier2;
            StocareSerialeFisier adminSeriale = new StocareSerialeFisier(caleCompletaFisier2);


            string optiune;
            int ok = 0;
            Console.WriteLine("ATENTIE: Dupa fiecare film/serial citit de la tastatura " +
                    "acesta trebuie salvat pentru a ramane in lista respectiva a acestuia!");
            do
            {

                Console.WriteLine();
                Console.WriteLine("C. Citire informatii film/serial de la tastatura:");
                Console.WriteLine("A. Afisarea listei de filme/seriale");
                Console.WriteLine("P. Cautare film/serial dupa nume");
                Console.WriteLine("L. Cautare film/serial dupa lansare");
                Console.WriteLine("S. Salvare filme/seriale in lista/fisier");
                Console.WriteLine("X. Inchidere program");

                Console.WriteLine("Alegeti o optiune");
                optiune = Console.ReadLine();
                switch (optiune.ToUpper())
                {
                    case "C":
                        Console.WriteLine("Introduceti ce vreti sa cititi (film/serial):");
                        string cautare1 = Console.ReadLine();
                        if (cautare1 == "film")
                        {
                            filmnou = CitireFilmTastatura();
                            ok = 1;
                        }
                        else if(cautare1 == "serial")
                        {
                            serialnou = CitireSerialTastatura();
                            ok = 2;
                        }

                        break;


                    case "A":
                        Console.WriteLine("Introduceti ce doriti sa vedeti din lista ('filme'/'seriale'):");
                        string afisare = Console.ReadLine();
                        if (afisare == "filme")
                        {
                            Console.WriteLine("Introduceti de unde doriti sa se afiseze ('lista'/'fisier'):");
                            string afisare1 = Console.ReadLine();
                            if (afisare1 == "lista")
                            {
                                Film[] filme = stocFilme.GetFilme(out nrFilme);
                                StocareFilme.AfisareFilme(filme, nrFilme);
                            }
                            else if (afisare1 == "fisier")
                            {
                                Film[] filme = adminFilme.GetFilme(out nrFilme);
                                adminFilme.AfisareFilme(filme, nrFilme);
                            }
                            break;
                        }
                        else if(afisare == "seriale")
                        {
                            Serial[] seriale = stocSeriale.GetSeriale(out nrSeriale);
                            Serial.AfisareSeriale(seriale, nrSeriale);
                        }
                        break;

                    case "S":
                        if (ok == 1)
                        {
                            int idFilm = ++nrFilme;
                            filmnou.idfilm = idFilm;

                            //adaugare film in lista
                            stocFilme.AddFilm(filmnou);

                            //adaugare film in fisier
                            adminFilme.AddFilm(filmnou);
                            break;
                        }
                        else if (ok == 2)
                        {
                            int idserial = nrSeriale + 1;
                            serialnou.idserial = idserial;
                            //adaugare serial in lista
                            stocSeriale.AddSerial(serialnou);

                            break;
                        }
                        break;

                    case "P":

                        Console.WriteLine("Introduceti ce vreti sa cautati ('film'/'serial'):");
                        string cautare = Console.ReadLine();
                        if (cautare == "film")
                        {
                            Console.WriteLine("Introduceti numele filmului:");
                            string numeFilm = Console.ReadLine();
                            Film filmgasit = stocFilme.GetFilm(numeFilm);

                            if (filmgasit != null)
                            {
                                Console.WriteLine($"Filmul a fost gasit!");
                                string infoFilm = filmgasit.Info();
                                Console.WriteLine(infoFilm);
                            }
                            else
                            {
                                Console.WriteLine($"Filmul '{numeFilm}' nu a fost gasit.");
                            }
                            break;
                        }
                        else
                            if (cautare == "serial")
                        {
                            Console.WriteLine("Introduceti numele serialului:");
                            string numeSerial = Console.ReadLine();
                            Serial serialgasit = stocSeriale.GetSerial(numeSerial);

                            if (serialgasit != null)
                            {
                                Console.WriteLine($"Serialul a fost gasit!");
                                string infoSerial = serialgasit.Info();
                                Console.WriteLine(infoSerial);
                            }
                            else
                            {
                                Console.WriteLine($"Serialul '{numeSerial}' nu a fost gasit.");
                            }
                            break;
                        }
                        break;

                    case "L":

                        Console.WriteLine("Introduceti ce vreti sa cautati (film/serial):");
                        string cautarea = Console.ReadLine();
                        if (cautarea == "film")
                        {
                            Console.WriteLine("Introduceti anul de cautare:");
                            string _lansare = Console.ReadLine();
                            int lansare = Convert.ToInt32(_lansare);
                              Film[] filmegasite = stocFilme.GetFilmelansare(out nrFilme, lansare);
                            StocareFilme.AfisareFilmelansare(filmegasite, nrFilme, lansare);
                            break;
                        }
                        else
                            if (cautarea == "serial")
                        {
                            Console.WriteLine("Introduceti anul de cautare:");
                            string _lansare = Console.ReadLine();
                            int lansare = Convert.ToInt32(_lansare);
                            Serial[] serialgasit = stocSeriale.GetSerialelansare(out nrSeriale, lansare) ;
                            Serial.AfisareSerialelansare(serialgasit, nrSeriale, lansare);
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
            int lansare = int.Parse(_lansare); // sau: int lansare = Convert.ToInt32(lansareStr);

            Console.WriteLine("Introduceti durata filmului:");
            string _durata = Console.ReadLine();
            float durata = float.Parse(_durata); // sau: float lansare = Convert.ToSingle(lansareStr);

            Film film = new Film(nume, regizor, gen, lansare, durata);

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

            Console.WriteLine("Introduceti durata unui episod:");
            string _durata = Console.ReadLine();
            float durata = float.Parse(_durata); // sau: float an_lansare = Convert.ToSingle(lansareStr);

            Serial serial = new Serial(nume, regizor, gen, lansare, episoade, sezoane, durata);

            return serial;
        }

    }
    
}


