using Filme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StocareFisier
{
    public class StocareFilmeFisier
    {

        private const int NR_MAX_FILME = 50;
        private string numeFisier;

        public StocareFilmeFisier(string numeFisier)
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
        public Film[] GetFilme(out int nrFilme)
        {
            Film[] filme = new Film[NR_MAX_FILME];
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
            }
            return filme;
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
    }
}
