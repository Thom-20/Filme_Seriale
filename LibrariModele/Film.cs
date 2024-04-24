using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filme
{

    public class Film
    {
        // data membra privata
        int []nota;

        // proprietati auto-implemented
        public int idfilm { get; set; } //identificator unic film
        public string nume { get; set; }
        public string regizor { get; set; }
        public string genFilm { get; set; }
        public float durata { get; set; }
        public int lansare { get; set; }
        
        //constante
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const char SEPARATOR_SECUNDAR_FISIER = ' ';
        private const bool SUCCES = true;
        public const int NOTA_MINIMA = 1;
        public const int NOTA_MAXIMA = 5;

        private const int IDFILM = 0;
        private const int NUME = 1;
        private const int REGIZOR = 2;
        private const int GEN = 3;
        private const int DURATA = 4;
        private const int LANSARE = 5;


    //	Constructor fara parametri
    public Film()
        { 
            idfilm = 0;
            nume = string.Empty;
            regizor = string.Empty;
            genFilm = string.Empty;
            lansare = 0;
            durata = 0;
        }

        //	Constructor cu parametri
        public Film(string _nume, string _regizor, string _gen, int _lansare, float _durata)
        {
            nume = _nume;
            regizor = _regizor;
            genFilm = _gen;
            lansare = _lansare;
            durata = _durata;
        }
       

        //	Metoda care returneaza informatiile despre film sub forma unui sir de caractere
        public string Info()
        {
            string info = $"ID: {idfilm}\n Numele filmului: {nume}\n Regizor: {regizor}\n Gen: {genFilm}\n An lansare: {lansare}\n Durata: {durata}\n";
            return info;
        }

        //constructor cu un singur parametru de tip string care reprezinta o linie dintr-un fisier text
        public Film(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            this.idfilm = Convert.ToInt32(dateFisier[IDFILM]);
            this.nume = dateFisier[NUME];
            this.regizor = dateFisier[REGIZOR];
            this.genFilm = dateFisier[GEN];
            this.lansare = Convert.ToInt32(dateFisier[LANSARE]);
            this.durata = Convert.ToInt32(dateFisier[DURATA]);
        }
        public string ConversieLaSir_PentruFisier()
        {
            string obiectFilmPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                (Convert.ToString(idfilm) ?? "0"),
                (nume ?? " NECUNOSCUT "),
                (regizor ?? " NECUNOSCUT "),
                (genFilm ?? " NECUNOSCUT "),
                (Convert.ToString(lansare) ?? " 0 "),
                (Convert.ToString(durata) ?? " 0 "));

            return obiectFilmPentruFisier;
        }
    }
}