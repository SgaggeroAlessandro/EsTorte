using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsTorte
{
    public abstract class CDolci
    {
        public string Nome { get; set; }
        public int Punteggio { get; set; }
        

        public CDolci(string Nome, int Punteggio)
        {
            this.Nome = Nome;
            this.Punteggio = Punteggio;
            
        }

        public abstract string Descrizione();

        public int Raffina()
        {
            
            Random rnd = new Random();
            int p = rnd.Next(3,8);

            if(p + Punteggio > 10)
            {
                Punteggio = 10;
            }
            else
            {
                Punteggio += p;
            }
            return  Punteggio;
        }

        
    }
}
