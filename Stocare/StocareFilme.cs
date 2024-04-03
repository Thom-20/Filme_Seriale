﻿using System;
using System.Dynamic;
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