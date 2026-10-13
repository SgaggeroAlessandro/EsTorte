using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsTorte
{
    public class CCrostate : CDolci
    {
        public CCrostate(string Nome, int Punteggio) : base(Nome, Punteggio)
        {

        }

        public override string Descrizione()
        {
            return $"Nome del dolce: {Nome} - Tipologia: crostata - Punteggio attuale: {Punteggio}";
        }
        public int ProvaCroccantezza()
        {
            if(Punteggio <= 4)
            {
                Punteggio = 0;
            }
            else
            {
                Punteggio -= 4;
            }
            return Punteggio;
        }
    }
}
