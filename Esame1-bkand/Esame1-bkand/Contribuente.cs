using System;

namespace Esame1_bkand
{
    internal class Contribuente
    {
        //creo le proprietà per i dati personali

        private string _nome;
        public string Nome { get { return _nome; } set { _nome = value; } }

        private string _cognome;

        public string Cognome { get { return _cognome; } set { _cognome = value; } }

        private DateTime _dataDiNascita;

        public DateTime DataDiNascita
        {
            get { return _dataDiNascita; }
            set { _dataDiNascita = value; }
        }

        private string _codiceFiscale;

        public string CodiceFiscale
        {
            get { return _codiceFiscale; }
            set { _codiceFiscale = value; }
        }

        private string _sesso;

        public string Sesso { get { return _sesso; } set { _sesso = value; } }

        private string _comuneResidenza;

        public string ComuneResidenza { get { return _comuneResidenza; } set { _comuneResidenza = value; } }

        private string _cittaResidenza;

        public string CittaResidenza { get { return _cittaResidenza; } set { _cittaResidenza = value; } }

        private decimal _redditoannuale;

        public decimal Redditoannuale { get { return _redditoannuale; } set { _redditoannuale = value; } }

        // Creo un menu di benvenuto in cuo poi inserirò i metodi per inserire i dati del contribuente
        public void Menu()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("Benvenuto Pollo da spennare");
            Console.WriteLine("Inserisci i tuoi dati così capiamo quanto ti dobbiamo sfilare");
            Console.WriteLine("\n");
            GetName();
            Console.WriteLine("\n");
            GetCognome();
            Console.WriteLine("\n");
            GetDataDiNascita();
            Console.WriteLine("\n");
            GetCF();
            Console.WriteLine("\n");
            GetSex();
            Console.WriteLine("\n");
            GetResidenza();
            Console.WriteLine("\n");
            GetReddito();
            Console.WriteLine("\n");
            Esci();

        }


        // Creo il metodo per l'inserimento del nome
        public void GetName()
        {
            Console.WriteLine("Inserisci Nome");
            _nome = Console.ReadLine();

        }

        // Creo il metodo per l'inserimento del cognome
        public void GetCognome()
        {
            Console.WriteLine("Inserisci Cognome");
            _cognome = Console.ReadLine();

        }

        // Creo il metodo per l'inserimento della data di nascita
        public void GetDataDiNascita()
        {
            do
            {
                Console.WriteLine("Inserisci la tua data di nascita:"); //Controllo che la data sia valida sia nel formato sia che l'anno sia quello di un'essere umano in vita.

                // Effettuo un controllo della validità dell'input convertendo  l'input del contribuente
                // in un oggetto DateTime. 
                //Se la data è valida viene assegnato il valore assegnato ad inputDate, 
                //altrimenti TryParse restituisce false ed il programma va su else.

                if (DateTime.TryParse(Console.ReadLine(), out DateTime inputDate))
                {
                    //metto degli if con delle date simboliche per attestare che l'utente non metta date obsolete
                    if (inputDate.Year < 1800)
                    {
                        Console.WriteLine("Wasted");
                    }
                    else if (inputDate.Year > 2030)
                    {
                        Console.WriteLine("Vieni dal futuro?");
                    }
                    //controllo che il giorno non vada oltre il 32 ed il mese oltre il 12
                    else if (inputDate.Day > 31 || inputDate.Month > 12)
                    {
                        Console.WriteLine("Formato Data non valido.");
                    }
                    else
                    {
                        Console.WriteLine("Data inserita correttamente.");

                        _dataDiNascita = inputDate;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Formato data non valido. Riprova.");
                }

            } while (true);

        }


        //creo il metodo per l'inserimento del codice fiscale
        public void GetCF()
        {
            Console.WriteLine("Inserisci il tuo codice fiscale");
            _codiceFiscale = Console.ReadLine();
            if (_codiceFiscale.Length == 16)
            {
                Console.WriteLine("CF corretto");

            }
            else
            {
                Console.WriteLine("CF non valido");

                GetCF();
            }

        }

        //Creo il metodo GetSex per far inserire il sesso dell'utente
        public void GetSex()
        {
            Console.WriteLine("Inserisci il tuo sesso (Maschio/Femmina o M/F)");
            _sesso = Console.ReadLine();
            {
                //Faccio un if per controlla che l'utente inserisca un sesso esistente
                if (_sesso == "Maschio" || _sesso == "M")
                {
                    Console.WriteLine($"Ciao Sg. {_nome} {_cognome}");
                }

                else if (_sesso == "Femmina" || _sesso == "F")
                {
                    Console.WriteLine($"Ciao Sg. {_nome} {_cognome}");
                }
                else
                {
                    Console.WriteLine("Inserci il genere con la prima lettera maiuscola o il carattere F/M in maiuscolo");
                    GetSex();
                }
            }
        }

        //creo il metodo per inserire il comune e la relativa provinca di residenza
        public void GetResidenza()
        {
            Console.WriteLine("inserisci il tuo comune di residenza");
            _comuneResidenza = Console.ReadLine();
            Console.WriteLine("inserisci la provincia");
            _cittaResidenza = Console.ReadLine();
        }

        //creo il metodo del reddito per calcolare al suo interno l'imposta che il contribuente dovrà versare
        public void GetReddito()
        {
            Console.WriteLine("Inserisci il tuo reddito annuo");
            _redditoannuale = decimal.Parse(Console.ReadLine());
            decimal imposta = 0;

            //faccio una serie di if per valutare l'imposta in base alle diferenti fasce di reddito annuale

            if (_redditoannuale <= 15000)
            {

                imposta = _redditoannuale * 0.23m;

            }
            if (_redditoannuale > 15000 && _redditoannuale <= 28000)
            {
                imposta = 3450 + (_redditoannuale - 15000) * 0.27m;

            }
            if (_redditoannuale > 28000 && _redditoannuale <= 55000)
            {
                imposta = 6960 + (_redditoannuale - 28000) * 0.38m;

            }
            if (_redditoannuale > 55000 && _redditoannuale <= 75000)
            {
                imposta = 17220 + (_redditoannuale - 55000) * 0.41m;

            }
            if (_redditoannuale > 75000)
            {
                imposta = 25520 + (_redditoannuale - 75000) * 0.43m;

            }
            Console.WriteLine($"L'imposta da pagare corrisponde a: {imposta}");

            // Faccio un piccolo resoconto di tutti i dati inseriti

            Console.WriteLine("\n");
            Console.WriteLine("Resoconto");
            Console.WriteLine($"Grandissimo contribuente {_nome} {_cognome}");
            Console.WriteLine($"nato il: {_dataDiNascita}; sesso: {_sesso}");
            Console.WriteLine($"Residente a: {_comuneResidenza} in provincia di {_cittaResidenza}");
            Console.WriteLine($"Numero C.F.: {_codiceFiscale}");
            Console.WriteLine($"le cucuzze da versare sono: {imposta}");
        }

        public void Esci()
        {
            Console.WriteLine("Premi qualsiasi tasto per uscire");
            Console.ReadLine();
        }

    }
}
