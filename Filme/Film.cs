using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filme
{

    public class Film
    {
        


        string nume, regizor, gen;
        float durata;
        int lansare;


        //	Constructor fara parametri
        public Film()
        {
            nume = string.Empty;
            regizor = string.Empty;
            gen = string.Empty;
            lansare = 0;
            durata = 0;
        }

        //	Constructor cu parametri
        public Film(string _nume, string _regizor, string _gen, int _lansare, float _durata)
        {
            nume = _nume;
            regizor = _regizor;
            gen = _gen;
            lansare = _lansare;
            durata = _durata;
        }

        //	Metoda care returneaza informatiile despre film sub forma unui sir de caractere
        public string Info()
        {
            string info = $"Numele filmului: {nume}, Regizor: {regizor}, Gen: {gen}, An lansare: {lansare}, Durata: {durata}.";
            return info;
        }
    }
}