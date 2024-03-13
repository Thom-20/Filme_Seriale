﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seriale
{
    public class Serial
    {
        public int idserial { get; set; }


        string nume, regizor, gen;
        float durata;
        int an_lansare, sezoane, episoade;


        //	Constructor fara parametri
        public Serial()
        {
            nume = string.Empty;
            regizor = string.Empty;
            gen = string.Empty;
            an_lansare = 0;
            durata = 0;
            sezoane = 0;
            episoade = 0;
        }

        //	Constructor cu parametri
        public Serial(string _nume, string _regizor, string _gen, int _lansare, int _episoade, int _sezoane, float _durata)
        {
            nume = _nume;
            regizor = _regizor;
            gen = _gen;
            an_lansare = _lansare;
            episoade = _episoade;
            sezoane = _sezoane;
            durata = _durata;
        }

        //	Metoda care returneaza informatiile despre film sub forma unui sir de caractere
        public string Info()
        {
            string info = $"Numele serialului: {nume}, Regizor: {regizor}, Gen: {gen}, An lansare: {an_lansare}, Sezoane: {sezoane}, Episoade: {episoade}, Durata: {durata}.";
            return info;
        }
    }

}

