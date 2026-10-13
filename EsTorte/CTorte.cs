using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsTorte
{
    public class CTorte : CDolci
    {
        public CTorte(string Nome, int Punteggio) : base(Nome, Punteggio)
        {

        }

        public override string Descrizione()
        {
            return $"Nome del dolce: {Nome} - Tipologia: torta - Punteggio attuale: {Punteggio}";
        }

        public int ProvaSofficezza()
        {
            if (Punteggio <= 6)
            {
                Punteggio = 0;
            }
            else
            {
                Punteggio -= 6;
            }



            return Punteggio;
        }
    }
}
