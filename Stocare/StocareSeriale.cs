using System;
using Filme;
using Seriale;
namespace StocareDate
{
    public class StocareSeriale
    {
        private const int NR_MAX_SERIALE = 50;

        private  Serial[] seriale;
        private int nrSeriale;


        public StocareSeriale()
        {
            seriale = new Serial[NR_MAX_SERIALE];
            nrSeriale = 0;
        }


        public void AddSerial(Serial serial)
        {
            seriale[nrSeriale] = serial;
            nrSeriale++;
        }


        public Serial[] GetSeriale(out int nrSeriale)
        {
            nrSeriale = this.nrSeriale;
            return seriale;
        }
        public Seriale.Serial[] GetSerialelansare(out int nrSeriale, int lansare)
        {
            nrSeriale = 0;
            Serial[] serialeGasite = new Serial[this.nrSeriale]; // Inițializăm un vector pentru a stoca serialele găsite
            for (int i = 0; i < this.nrSeriale; i++)
            {
                if (seriale[i] != null && seriale[i].lansare == lansare)
                {
                    serialeGasite[nrSeriale++] = seriale[i]; // Adăugăm serialul găsit în vectorul de filme și incrementăm numărul de seriale găsite
                }
            }
            return serialeGasite; 
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
        public Serial GetSerialeGen(string genSerial)
        {
            int contor = 0;
            for (int i = 0; i < nrSeriale; i++)
            {
                if (seriale[i] != null && seriale[i].genSerial == genSerial)
                {
                    contor += 1;
                    return seriale[i];
                }
            }
            return null; // Returnăm null dacă nu găsim niciun gen de serial dat
        }
    }
}