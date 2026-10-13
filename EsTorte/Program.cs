using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EsTorte
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<CDolci> DolciInGara = new List<CDolci>();
            int scelta;
            do
            {
                do
                {
                    Console.WriteLine("Scrivi il numero relativo alla funzione che si vuole richiamare tra quelle proposte");
                    Console.WriteLine("\t1. Visualizzare lo stato di tutti i dolci in gara\n" +
                        "\t2.Scegliere una crostata e fare la prova della croccantezza\n" +
                        "\t3.Scegliere una torta e fare la prova della sofficezza\n" +
                        "\t4.Scegliere un dolce qualsiasi e raffinarlo\n" +
                        "\t5.Finale di degustazione, raffinando tutti i dolci\n" +
                        "\t6.Aggiungere un nuovo dolce\n" +
                        "\t7. Fine del programma\n");
                    Console.Write("Numero scelto:");
                } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 7);

                switch (scelta)
                {
                    case 1:
                        Console.WriteLine("E' stato scelto di visualizzare lo stato di tutti i dolci in gara");
                        VisualizzaDolci(DolciInGara);
                        break;
                    case 2:
                        Console.WriteLine("E' stato scelto di fare la prova di croccantezza ad una crostata scelta");
                        Croccantezza(DolciInGara);
                        break;
                    case 3:
                        Console.WriteLine("E' stato scelto di fare la prova della sofficezza ad una torta scelta");
                        Sofficezza(DolciInGara);
                        break;
                    case 4:
                        Console.WriteLine("E' stato scelto di raffinare un dolce");
                        RaffinaDolce(DolciInGara);
                        break;
                    case 5:
                        Console.WriteLine("E' stato scelto di raffinare tutti i dolci");
                        FinaleDegustazione(DolciInGara);
                        break;
                    case 6:
                        Console.WriteLine("E' stato scelto di aggiungere un nuovo dolce");
                        AggiungiDolce(DolciInGara);
                        break;
                    case 7:
                        Console.WriteLine("E' stato scelto di terminare il programma");
                        break;
                }
            } while (scelta != 7);
        }
        public static void VisualizzaDolci(List<CDolci> dolci)
        {
            if (dolci.Count == 0)
            {
                Console.WriteLine("Non ci sono dolci in gara");
                return;
            }
            foreach (CDolci c in dolci)
            {
                Console.WriteLine(c.Descrizione());
            }
        }

        public static void Croccantezza(List<CDolci> dolci)
        {
            if (dolci.Count == 0)
            {
                Console.WriteLine("Non ci sono dolci in gara");
                return;
            }
            string nome = "";
            for (int i = 0; i < dolci.Count; i++)
            {
                CDolci crostata = dolci[i];
                if (crostata is CCrostate)
                {
                    Console.WriteLine(dolci[i].Descrizione());
                }
            }
            do
            {
                Console.WriteLine("Scrivi il nome della crostata");
                nome = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(nome));
            bool trovato = false;
            CCrostate crostataScelta = null;
            for (int i = 0; i < dolci.Count; i++)
            {


                if (dolci[i].Nome.ToLower() == nome.ToLower() && dolci[i] is CCrostate)
                {
                    trovato = true;
                    crostataScelta = (CCrostate)dolci[i];
                    break;
                }
            }

            if (trovato == false)
            {
                Console.WriteLine("Non è stata trovata alcuna crostata con questo nome");
            }
            else
            {
                int vecchio = crostataScelta.Punteggio;
                crostataScelta.ProvaCroccantezza();
                Console.WriteLine($"Prova di croccantezza effettuata. Vecchio punteggio: {vecchio} --> Nuovo punteggio: {crostataScelta.Punteggio}");
            }
        }
        public static void Sofficezza(List<CDolci> dolci)
        {
            if (dolci.Count == 0)
            {
                Console.WriteLine("Non ci sono dolci in gara");
                return;
            }

            string nome = "";
            for (int i = 0; i < dolci.Count; i++)
            {
                CDolci crostata = dolci[i];
                if (crostata is CTorte)
                {
                    Console.WriteLine(dolci[i].Descrizione());
                }
            }

            do
            {
                Console.WriteLine("Scrivi il nome della torta");
                nome = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(nome));
            bool trovato = false;
            CTorte torta = null;

            for (int i = 0; i < dolci.Count; i++)
            {


                if (dolci[i].Nome.ToLower() == nome.ToLower() && dolci[i] is CTorte)
                {
                    trovato = true;
                    torta = (CTorte)dolci[i];
                    break;
                }
            }
            if (trovato == false)
            {
                Console.WriteLine("Non è stata trovata alcuna torta con questo nome");
            }
            else
            {
                int vecchio = torta.Punteggio;
                torta.ProvaSofficezza();
                Console.WriteLine($"Prova di sofficezza effettuata. Vecchio punteggio: {vecchio} --> Nuovo punteggio: {torta.Punteggio}");
            }
        }

        public static void RaffinaDolce(List<CDolci> dolci)
        {
            if (dolci.Count == 0)
            {
                Console.WriteLine("Non ci sono dolci in gara");
                return;
            }

            foreach (CDolci d in dolci)
            {
                Console.WriteLine(d.Descrizione());
            }
            string nome = "";

            do
            {
                Console.WriteLine("Scrivi il nome della torta da raffinare");
                nome = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(nome));
            bool trovato = false;
            CDolci dolce = null;
            for (int i = 0; i < dolci.Count; i++)
            {
                if (dolci[i].Nome.ToLower() == nome.ToLower())
                {
                    dolce = dolci[i];
                    trovato = true;
                    break;
                }

            }

            if (trovato == false)
            {
                Console.WriteLine("Non ci sono dolci con questo nome");
            }
            else
            {
                int vecchio = dolce.Punteggio;
                Console.WriteLine("Vecchio punreggio raggiunto");
                dolce.Raffina();
                Console.WriteLine(dolce.Descrizione());
            }
        }
        public static void FinaleDegustazione(List<CDolci> dolci)
        {
            if (dolci.Count == 0)
            {
                Console.WriteLine("Non ci sono dolci in gara");
                return;
            }

            foreach (CDolci d in dolci)
            {
                int vecchio = d.Punteggio;

                d.Raffina();

                Console.WriteLine($"Dolce: {d.Nome}");
                Console.WriteLine($"Punteggio precedente: {vecchio}");
                Console.WriteLine($"Punteggio attuale: {d.Punteggio}");

            }
        }
        public static void AggiungiDolce(List<CDolci> dolci)
        {
            string nome;
            int tipologia;
            int punteggio;

            do
            {
                Console.WriteLine("Inserisci il nome del dolce:");
                nome = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(nome));

            do
            {
                Console.WriteLine("Scegli la tipologia:");
                Console.WriteLine("1. Crostata");
                Console.WriteLine("2. Torta");
                Console.Write("Scelta: ");
            } while (!int.TryParse(Console.ReadLine(), out tipologia) || tipologia < 1 || tipologia > 2);

            do
            {
                Console.WriteLine("Inserisci il punteggio iniziale (da 1 a 10):");
            } while (!int.TryParse(Console.ReadLine(), out punteggio)|| punteggio < 1 || punteggio > 10);

            if (tipologia == 1)
            {
                dolci.Add(new CCrostate(nome, punteggio));
            }
            else
            {
                dolci.Add(new CTorte(nome, punteggio));
            }

            Console.WriteLine("Dolce aggiunto correttamente");
            Console.WriteLine(dolci[dolci.Count - 1].Descrizione());
        }


    }
}
