using Filme;
using Seriale;
using System;
namespace StocareDate
{
    public class Stocare
    {
        private const int NR_MAX_FILME = 50;
        private const int NR_MAX_SERIALE = 50;

        private Film[] filme;  Serial[] seriale;
        private int nrFilme, nrSeriale;


        public Stocare()
        {
            filme = new Film[NR_MAX_FILME];
            nrFilme = 0;
            seriale = new Serial[NR_MAX_SERIALE];
            nrSeriale = 0;
        }

        public void AddFilm(Film film)
        {
            filme[nrFilme] = film;
            nrFilme++;
        }

        public void AddSerial(Serial serial)
        {
            seriale[nrSeriale] = serial;
            nrSeriale++;
        }

        public Film[] GetFilme(out int nrFilme)
        {
            nrFilme = this.nrFilme;
            return filme;
        }

        public Serial[] GetSeriale(out int nrSeriale)
        {
            nrSeriale = this.nrSeriale;
            return seriale;
        }
        public Film GetFilm(string nume)
        {
            for(int i = 0;i<nrFilme;i++)
            {
                if (filme[i]!=null && filme[i].nume == nume)
                {
                    return filme[i];
                }
            }
            return null; // Returnăm null dacă nu găsim niciun film cu numele dat
        }
        public Serial GetSerial(string nume)
        {
            for (int i = 0; i < nrSeriale; i++)
            {
                if (seriale[i] != null && seriale[i].nume == nume)
                {
                    return seriale[i];
                }
            }
            return null; // Returnăm null dacă nu găsim niciun film cu numele dat
        }

    }
}