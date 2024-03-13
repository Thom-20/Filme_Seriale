using Filme;
using Seriale;
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
    }
}