
namespace ProgettoEdicola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Carattere (compreso fra 1-4) corrispondente all'operazione che l'utente desidera compiere
            char sceltaUtente = ' ';

            //Prezzi degli articoli
            const int PREZZO_PENNE = 1;
            const int PREZZO_QUADERNI = 4;
            const int PREZZO_ASTUCCIO = 15;

            //Codici degli articoli
            const char CODICE_PENNE = '1';
            const char CODICE_QUADERNI = '2';
            const char CODICE_ASTUCCI = '3';

            //Istanzio un oggetto della classe Random per generare numeri casuali
            Random generatore = new Random();


            //-----------------------------------------------------------
            //Quantità degli articoli disponibili nel magazzino
            int qtnPenneMagazzino = 0;
            int qtnQuaderniMagazzino = 0;
            int qtnAstucciMagazzino = 0;

            //Quantità degli articoli presenti nel carrello
            int qtnPenneCarrello = 0;
            int qtnQuaderniCarrello = 0;
            int qtnAstucciCarrello = 0;

            //Codice relativo all'articolo che lo studente desidera iserire nel carrello
            char codArticoloUtente = ' ';
            
            //prezzo degli articoli
            int prezzo_car = 0;
            int prezzo_tutto_car= 0;

            //Quantità di un certo articolo che l'utente desidera aggiungere al proprio carrello
            int quantitaArticoloUtente = 0;

            //Questa variabile memorizza il carattere 's' se l'utente desidera pagare e uscire dal programma, 'n' viceversa 
            char rispostaUtentePagamento = ' ';

            //Costante necessaria per allineare i campi del menù
            const int PAR_AL = -10;
            
                do
                {
                    qtnPenneMagazzino = generatore.Next(1, 11);
                    qtnQuaderniMagazzino = generatore.Next(1, 11);
                    qtnAstucciMagazzino = generatore.Next(1, 11);

                    /*
                     * Eseguo il ciclo finché la quantità dei quaderni è maggiore rispetto alla quantità delle penne 
                     * oppure la quantità degli astucci è maggiore della quantità dei quaderni
                     */
                } while ((qtnQuaderniMagazzino > qtnPenneMagazzino) || (qtnAstucciMagazzino > qtnQuaderniMagazzino));

            do 
            { 
                Console.Clear();
                if(qtnPenneMagazzino + qtnQuaderniMagazzino + qtnAstucciMagazzino != 0 ){

                    Console.WriteLine("**Il negozio dispone dei seguenti articoli**");
                    Console.WriteLine($"{"Codice",PAR_AL}{"Nome",PAR_AL}{"Quantità",PAR_AL}{"Prezzo",PAR_AL}");
                    if (qtnPenneMagazzino > 0)
                        Console.WriteLine($"{CODICE_PENNE,PAR_AL}{"Penna",PAR_AL}{qtnPenneMagazzino,PAR_AL}{PREZZO_PENNE:C}");
                    if (qtnQuaderniMagazzino > 0)
                        Console.WriteLine($"{CODICE_QUADERNI,PAR_AL}{"Quaderno",PAR_AL}{qtnQuaderniMagazzino,PAR_AL}{PREZZO_QUADERNI:C}");
                    if (qtnAstucciMagazzino > 0)
                    Console.WriteLine($"{CODICE_ASTUCCI,PAR_AL}{"Astuccio",PAR_AL}{qtnAstucciMagazzino,PAR_AL}{PREZZO_ASTUCCIO:C}");

                }
                else
                {
                    Console.WriteLine("Nessun articolo disponibile in magazzino");
                }

                Console.WriteLine("-------------------------------------------------");
                if(qtnPenneMagazzino + qtnQuaderniMagazzino + qtnAstucciMagazzino != 0 )
                    Console.WriteLine("Premere 1 per aggiungere al carrello un articolo");

                Console.WriteLine("Premere 2 per visualizzare il carrello");
                Console.WriteLine("Premere 3 per svuotare il carrello");
                Console.WriteLine("Premere 4 per procedere con il pagamento");

                /*
                 * * Ripeto finché sceltaUtente NON è compreso fra 2 e 4, 
                 * * ossia è strettamente minore di 2 oppure strettamente maggiore di 4
                 */
                sceltaUtente = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (sceltaUtente)
                {
                    case '1':
                        Console.Write("Inserisci il codice dell'articolo che desideri aggiungere al carrello: ");
                        codArticoloUtente = Console.ReadKey().KeyChar;
                        Console.WriteLine();

                        if ((codArticoloUtente < '1') || (codArticoloUtente > '3'))
                        {
                            Console.WriteLine("Il codice inserito non corrisponde a nessun articolo. Premi un qualunque pulsante per continuare...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.Write("Inserisci la quantità: ");
                            quantitaArticoloUtente = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("");

                            switch (codArticoloUtente)
                            {
                                case CODICE_PENNE:
                                    if (qtnPenneMagazzino < quantitaArticoloUtente)
                                    {
                                        Console.WriteLine("Quantità non disponibile");
                                        Console.WriteLine("Premere invio per visualizzare il menu iniziale");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        //Aggiorno la quantità di penne presenti nel carrello
                                        qtnPenneCarrello = qtnPenneCarrello + quantitaArticoloUtente;

                                        //Aggiorno la quantità di penne disponibili nel magazzino
                                        qtnPenneMagazzino = qtnPenneMagazzino - quantitaArticoloUtente;
                                    }
                                    break;

                                case CODICE_ASTUCCI:
                                    if (qtnAstucciMagazzino < quantitaArticoloUtente)
                                    {
                                        Console.WriteLine("Quantità non disponibile");
                                        Console.WriteLine("Premere invio per visualizzare il menu iniziale");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        //Aggiorno la quantità di astucci presenti nel carrello
                                        qtnAstucciCarrello = qtnAstucciCarrello + quantitaArticoloUtente;

                                        //Aggiorno la quantità di astucci presenti nel magazzino
                                        qtnAstucciMagazzino = qtnAstucciMagazzino - qtnAstucciCarrello; ;
                                    }
                                    break;

                                case CODICE_QUADERNI:
                                    if (qtnQuaderniMagazzino < quantitaArticoloUtente)
                                    {
                                        Console.WriteLine("Quantità non disponibile");
                                        Console.WriteLine("Premere invio per visualizzare il menu iniziale");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        //Aggiorno la quantità di quaderni presenti nel carrello
                                        qtnQuaderniCarrello = qtnQuaderniCarrello + quantitaArticoloUtente;

                                        //Aggiorno la quantità di quaderni presenti nel magazzino
                                        qtnQuaderniMagazzino = qtnQuaderniMagazzino - quantitaArticoloUtente;
                                    }
                                    break;
                            }
                        }
                        break;

                    case '2':
                        if (qtnPenneCarrello + qtnQuaderniCarrello + qtnAstucciCarrello == 0)
                        {
                            Console.WriteLine("il carrello è vuoto");
                            Console.WriteLine();
                            Console.Write("clicca un tasto per continuare...");
                            Console.ReadLine ();
                        }
                        else 
                        {
                            Console.WriteLine("***carrello***");
                            if (qtnQuaderniCarrello != 0)
                            {
                                prezzo_car = PREZZO_QUADERNI * qtnQuaderniCarrello; 

                                Console.WriteLine($"quaderno x {qtnQuaderniCarrello} = {prezzo_car:C}");
                            }
                            if (qtnPenneCarrello != 0)
                            {
                                prezzo_car = PREZZO_PENNE * qtnPenneCarrello; 

                                Console.WriteLine($"penna x {qtnPenneCarrello} = {prezzo_car:C}");
                            }
                            if (qtnAstucciCarrello != 0)
                            {
                                prezzo_car = PREZZO_ASTUCCIO * qtnAstucciCarrello; 

                                Console.WriteLine($"astuccio x {qtnAstucciCarrello} = {prezzo_car:C}");
                            }

                            prezzo_tutto_car = (PREZZO_PENNE * qtnPenneCarrello) + (PREZZO_QUADERNI * qtnQuaderniCarrello) + (PREZZO_ASTUCCIO * qtnAstucciCarrello);
                            Console.WriteLine($"totale carrello = {prezzo_tutto_car:C}");
                        
                            Console.WriteLine();
                            Console.WriteLine("clicca un tasto per continuare...");
                            Console.ReadLine();
                        }
                            
                        break;

                    case '3':
                        if(qtnPenneCarrello + qtnQuaderniCarrello + qtnAstucciCarrello == 0)
                        {
                            Console.WriteLine("non c'é nulla nel carrello");
                        }
                        else
                        {
                            qtnPenneMagazzino += qtnPenneCarrello;
                            qtnQuaderniMagazzino += qtnQuaderniCarrello;
                            qtnAstucciMagazzino += qtnAstucciCarrello;

                            qtnPenneCarrello *= 0;
                            qtnQuaderniCarrello *= 0;
                            qtnAstucciCarrello *= 0;
                            
                            Console.WriteLine("carrello svuotato");
                            
                        }

                        Console.WriteLine("clicca un tasto per continuare...");
                        Console.ReadLine();   

                        break;

                    case '4':
                        if (qtnPenneCarrello + qtnQuaderniCarrello + qtnAstucciCarrello == 0)
                        {
                            Console.WriteLine("Il carrello è vuoto");
                            Console.WriteLine();
                            Console.Write("Clicca un tasto per continuare...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("***Carrello***");
                            if (qtnQuaderniCarrello != 0)
                            {
                                prezzo_car = PREZZO_QUADERNI * qtnQuaderniCarrello;
                                Console.WriteLine($"Quaderno x {qtnQuaderniCarrello} = {prezzo_car:C}");
                            }
                            if (qtnPenneCarrello != 0)
                            {
                                prezzo_car = PREZZO_PENNE * qtnPenneCarrello;
                                Console.WriteLine($"Penna x {qtnPenneCarrello} = {prezzo_car:C}");
                            }
                            if (qtnAstucciCarrello != 0)
                            {
                                prezzo_car = PREZZO_ASTUCCIO * qtnAstucciCarrello;
                                Console.WriteLine($"Astuccio x {qtnAstucciCarrello} = {prezzo_car:C}");
                            }

                            prezzo_tutto_car = (PREZZO_PENNE * qtnPenneCarrello)
                                             + (PREZZO_QUADERNI * qtnQuaderniCarrello)
                                             + (PREZZO_ASTUCCIO * qtnAstucciCarrello);

                            Console.WriteLine($"Totale carrello = {prezzo_tutto_car:C}");
                            Console.WriteLine();
                            Console.Write("Vuoi procedere al pagamento? (s/n): ");
                            rispostaUtentePagamento = Console.ReadKey().KeyChar;
                            Console.WriteLine();

                            if (rispostaUtentePagamento == 's' || rispostaUtentePagamento == 'S')
                            {
                                Console.WriteLine("Pagamento completato! Grazie per l’acquisto!");
                                
                            }
                            else
                            {
                                Console.WriteLine("Pagamento annullato. Torno al menù...");
                                Console.ReadLine();
                            }
                        }
                        break;
                } 
            } while (rispostaUtentePagamento != 's' || rispostaUtentePagamento == 'S'); 
        }
    }
}

