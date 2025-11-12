using System;
using System.Runtime.CompilerServices;  // Importa lo spazio dei nomi System

namespace MioProgetto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---CARTOLERIA---");


            bool stanza_A = true;
            bool stanza_B = true;
            bool stanza_C = true;

            string nome = "";
            string scelta = "";

            string stanza_a_nome = "";
            string stanza_b_nome = "";
            string stanza_c_nome = "";

            do
            {
                Console.Write("inserisci il tuo nome: ");
                nome = Console.ReadLine();

                Console.Write("inserisci la camera che vuoi prenotare la stanza A - B - C: ");
                Console.WriteLine("premi il tasto N per uscire");
                do
                {
                    Console.Write("inserisci la scelta: ");
                    scelta = Console.ReadLine();

                    switch (scelta)
                    {

                        case "A":
                            if (stanza_A)
                            {
                                Console.WriteLine("La stanza A e stata prenotata ");
                                stanza_a_nome = nome;
                                stanza_A = false;

                            }
                            else
                            {
                                Console.WriteLine("la stanza A e occupata");
                            }
                            break;

                        case "B":
                            if (stanza_B)
                            {
                                Console.WriteLine("La stanza B e stata prenotata ");
                                stanza_b_nome = nome;
                                stanza_B = false;

                            }
                            else
                            {
                                Console.WriteLine("la stanza B e occupata");
                            }
                            break;

                        case "C":
                            if (stanza_C)
                            {
                                Console.WriteLine("La stanza C e stata prenotata ");
                                stanza_c_nome = nome;
                                stanza_C = false;

                            }
                            else
                            {
                                Console.WriteLine("la stanza C e occupata");
                            }
                            break;

                        case "N":
                            Console.WriteLine("uscita in corso ciao");

                            Console.Write("premi un tasto per uscire...");
                            Console.ReadLine();

                            Console.Clear();

                            break;



                    }
                }
                while (scelta != "A" && scelta != "B" && scelta != "C" && scelta != "N");
            }
            while (stanza_A == true || stanza_B == true || stanza_C == true);

            Console.WriteLine("L'albergo ha tutte le stanze occupate");
            Console.WriteLine($"La stanza A e stata riservata a {stanza_a_nome}");
            Console.WriteLine($"La stanza B e stata riservata a {stanza_b_nome}");
            Console.WriteLine($"La stanza C e stata riservata a {stanza_c_nome}");



        }
    }
}