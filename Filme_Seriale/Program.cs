using System;
using System.Runtime.InteropServices;
using System.Threading;
using Filme;
using Seriale;
using StocareDate;

namespace Filme_Seriale
{
    class Program
    {
        static void Main()
        {
            StocareFilme stocFilme = new StocareFilme();
            Film filmnou = new Film();
            int nrFilme = 0;

            StocareSeriale stocSeriale = new StocareSeriale();
            Serial serialnou = new Serial();
            int nrSeriale = 0;

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
                Console.WriteLine("S. Salvare filme/seriale in lista");
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
                            filmnou = StocareFilme.CitireFilmTastatura();
                            ok = 1;
                        }
                        else if(cautare1 == "serial")
                        {
                            serialnou = StocareSeriale.CitireSerialTastatura();
                            ok = 2;
                        }

                        break;


                    case "A":
                        Console.WriteLine("Introduceti ce vreti lista vreti sa vedeti ('filme'/'seriale'):");
                        string afisare = Console.ReadLine();
                        if (afisare == "filme")
                        {
                            Film[] filme = stocFilme.GetFilme(out nrFilme);
                            StocareFilme.AfisareFilme(filme, nrFilme);
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
                            int idfilm = nrFilme + 1;
                            filmnou.idfilm = idfilm;
                            //adaugare film in lista
                            stocFilme.AddFilm(filmnou);

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
        

       
      
    }
}


