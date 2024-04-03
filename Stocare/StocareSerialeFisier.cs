using Seriale;
using System.IO;

namespace StocareFisier
{
    public class StocareSerialeFisier
    {

        private const int NR_MAX_SERIALE = 50;
        private string numeFisier;

        public StocareSerialeFisier(string numeFisier)
        {
            this.numeFisier = numeFisier;
            /* se incearca deschiderea fisierului in modul OpenOrCreate
            astfel incat sa fie creat daca nu exista */
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
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
        public Serial[] GetSeriale(out int nrSeriale)
        {
            Serial[] seriale = new Serial[NR_MAX_SERIALE];
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
                    // verificare pentru nrSeriale < NR_MAX_SERIALE!
                }
            }
            return seriale;
        }
    }
}
