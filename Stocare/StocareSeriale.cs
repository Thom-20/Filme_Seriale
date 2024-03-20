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