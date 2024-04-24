using Filme;
using Seriale;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocareFisier
{
    public class StocareMediaFisier
    {
        private const int NR_MAX_MEDIA = 100;
        private string numeFisier;

        public StocareMediaFisier(string numeFisier)
        {
            this.numeFisier = numeFisier;
            /* se incearca deschiderea fisierului in modul OpenOrCreate
            astfel incat sa fie creat daca nu exista */
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }
        public void AddFilm(Film film)
        {
            /* al doilea parametru al constructorului StreamWriter indica
            daca va fi folosit modul 'append' la deschiderea fisierului (true)
            sau suprascriere (false) */
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(film.ConversieLaSir_PentruFisier());
            }

            /* la iesirea din blocul instructiunii 'using'
            se va apela implicit streamWriterFisierText.Close(); */
        }
        public void AddSerial(Serial serial)
        {
            /* al doilea parametru al constructorului StreamWriter indica
            daca va fi folosit modul 'append' la deschiderea fisierului (true)
            sau suprascriere (false) */
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(serial.ConversieLaSir_PentruFisier());
            }

            /* la iesirea din blocul instructiunii 'using'
            se va apela implicit streamWriterFisierText.Close(); */
        }
        public Film[] GetFilme(out int nrFilme)
        {
            Film[] filme = new Film[NR_MAX_MEDIA];
            /* se va apela implicit streamReader.Close()
            la iesirea din blocul instructiunii ”using” */
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrFilme = 0;
                /* citeste cate o linie si creaza un obiect de tip Film
                pe baza datelor din linia citita */
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    filme[nrFilme++] = new Film(linieFisier);
                    // verificare pentru nrFilme < NR_MAX_Filme!
                }
                Array.Resize(ref filme, nrFilme);
            }
            return filme;
        }

        public Serial[] GetSeriale(out int nrSeriale)
        {
            Serial[] seriale = new Serial[NR_MAX_MEDIA];
            /* se va apela implicit streamReader.Close()
            la iesirea din blocul instructiunii ”using” */
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrSeriale = 0;
                /* citeste cate o linie si creaza un obiect de tip Film
                pe baza datelor din linia citita */
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    seriale[nrSeriale++] = new Serial(linieFisier);
                    // verificare pentru nrSeriale < NR_MAX_MEDIA!
                }
                Array.Resize(ref seriale, nrSeriale);
            }
            return seriale;
        }
        public void AfisareFilme(Film[] filme, int nrFilme)
        {
            Console.WriteLine("Filmele sunt:");
            for (int contor = 0; contor < nrFilme; contor++)
            {
                string infoFilm = filme[contor].Info();
                Console.WriteLine(infoFilm);
            }
        }
        public void AfisareSeriale(Serial[] seriale, int nrSeriale)
        {
            Console.WriteLine("Serialele sunt:");
            for (int contor = 0; contor < nrSeriale; contor++)
            {
                string infoFilm = seriale[contor].Info();
                Console.WriteLine(infoFilm);
            }
        }
    }
}
