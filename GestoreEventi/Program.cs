using GestoreEventi;

Console.WriteLine("BENVENUTI NEL MIO PROGARMMA!\n");

//-------MILESTONE 4--------
Console.Write("Inserisci il nome del tuo pragamma Eventi: ");
string nomeProgramma = Console.ReadLine();
Console.Write("Indica il numero di eventi da inserire: ");
int nEventi = int.Parse(Console.ReadLine());

ProgrammaEventi listaProgramma = new ProgrammaEventi(nomeProgramma);
List<Evento> listaEvento = listaProgramma.GetEventi();

int iterazione = 0;
while(iterazione < nEventi) //aggiungo eventi alla mia lista
{
    Console.WriteLine("\nVuoi aggiungere un evento o una conferenza? ");
    string risposta = Console.ReadLine();

    if(risposta == "evento")
    {
        EventoNuovo();
        iterazione++;
    } else if (risposta == "conferenza")
    {
        ConferenzaNuova();
        iterazione++;
    }

}

Console.Clear();

//------MILESTONE 1--------
while(true)
{
    Console.WriteLine("\nCosa vuoi fare?");

    Console.WriteLine("0 - Visualizza tutti gli eventi della lista");
    Console.WriteLine("1 - Visualizza gli eventi di una data");
    Console.WriteLine("2 - Aggiungi un nuovo evento alla lista");
    Console.WriteLine("3 - Rimuovi tutti gli eventi del programma");

    int risposta = int.Parse(Console.ReadLine());
    
    switch(risposta)
    {
        case 0:

            Console.Clear();

            Console.WriteLine("Il numero di eventi nel programma è: " + listaProgramma.nEventi());

            Console.WriteLine(listaProgramma.stampaListaConTitolo());

            selezionaEvento();

            Console.ReadKey();
            Console.Clear();
            break;

        case 1:

            Console.Clear();

            Console.WriteLine("Inserisci una data per sapere che eventi ci saranno (gg/mm/yyyy): ");
            DateTime FindData = DateTime.Parse(Console.ReadLine());

            ProgrammaEventi.stampaLista(listaProgramma.EventiInData(FindData));

            selezionaEvento();

            Console.ReadKey();
            Console.Clear();

            break;

        case 2:

            Console.Clear();

            Console.WriteLine("\nVuoi aggiungere un evento o una conferenza? ");
            string risp = Console.ReadLine();

            if(risp == "evento")
            {
                EventoNuovo();
            } else if(risp == "conferenza")
            {
                ConferenzaNuova();
            }

            Console.ReadKey();
            Console.Clear();
            break;
        case 3:
            Console.Clear();

            listaProgramma.SvuotaLista();
            Console.WriteLine("Hai rimosso tutti gli eventi di questo programma!");
            break;

        default:
            Console.WriteLine("Errore");
            break;
    }
}






//-------FUNZIONI-------

void Prenotazione(Evento evento)
{
    Console.Write("\nQuanti posti desideri prenotare? ");
    int nPrenotazioni = int.Parse(Console.ReadLine());
    try
    {
        evento.PrenotaPosti(nPrenotazioni);
    } catch(InvalidTimeZoneException ex)
    {
        Console.WriteLine("La data inserita è nel passato");
    } catch(ArgumentOutOfRangeException ex)
    {
        Console.WriteLine(ex.Message);
    } catch (ArgumentNullException ex)
    {
        Console.WriteLine(ex.Message);
    }

    evento.stampaPosti();
}

void Disdire(Evento evento)
{
    Console.WriteLine("Quanti posti desideri disdire? ");
    int nCancellazioni = int.Parse(Console.ReadLine());
    try
    {
        evento.DisdiciPosti(nCancellazioni);
    } catch(InvalidTimeZoneException e)
    {
        Console.WriteLine("La data di questo evento è nel passato");
    } catch(ArgumentNullException e)
    {
        Console.WriteLine(e.Message);
    } catch (ArgumentOutOfRangeException e)
    {
        Console.WriteLine(e.Message);
    }

    evento.stampaPosti();
}

void selezionaEvento()
{
    Console.WriteLine("Vuoi selezionare un evento? (si/no) ");
    string scelta = Console.ReadLine();

    int indiceEvento = -1;

    if(scelta == "si")
    {
        bool nomeGiusto = true;
        do
        {
            Console.WriteLine("Inserisci il nome dell'evento da selezionare: ");
            string nomeEvento = Console.ReadLine();

            try
            {
                nomeGiusto = true;
                indiceEvento = listaProgramma.selezionaEvento(nomeEvento);
            } catch(ArgumentNullException e)
            {
                Console.WriteLine("Nome selezionato non valido.");
                nomeGiusto = false;
            }
        } while(!nomeGiusto);


        Console.WriteLine(listaEvento[indiceEvento].ToString());

        listaEvento[indiceEvento].stampaPosti();

        Console.WriteLine("\n0 - Prenotare posti");
        Console.WriteLine("1 - Disdire posti");
        Console.WriteLine("2 - Ritorna indietro");

        int risposta = int.Parse(Console.ReadLine());
        switch(risposta)
        {
            case 0:
                Prenotazione(listaEvento[indiceEvento]);
                break;
            case 1:
                Disdire(listaEvento[indiceEvento]);
                break;
            case 2:
                break;
        }
    }
}

void EventoNuovo()
{
    try
    {
        Console.WriteLine("------- Nuovo Evento --------");
        Console.Write("Inserisci il nome del nuovo evento: ");
        string nome = Console.ReadLine();
        Console.Write("Inserisci la data dell'evento (gg/mm/yyyy): ");
        DateTime data = DateTime.Parse(Console.ReadLine());
        Console.Write("Inserisci il numero di posti totali: ");
        int postiTotali = int.Parse(Console.ReadLine());

        Evento nuovoEvento = new Evento(nome, data, postiTotali);
        listaProgramma.AggiungiEvento(nuovoEvento);
        
    } catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

}

void ConferenzaNuova()
{
    try
    {
        Console.WriteLine("------- Nuova Conferenza --------");
        Console.Write("Inserisci il nome della nuova conferenza: ");
        string nome = Console.ReadLine();
        Console.Write("Inserisci la data della conferenza (gg/mm/yyyy): ");
        DateTime data = DateTime.Parse(Console.ReadLine());
        Console.Write("Inserisci il numero di posti totali: ");
        int postiTotali = int.Parse(Console.ReadLine());
        Console.Write("Inserisci il relatore della conferenza: ");
        string relatore = Console.ReadLine();
        Console.Write("Inserisci il prezzo del biglietto della conferenza: ");
        double prezzo = double.Parse(Console.ReadLine());

        Evento nuovaConferenza = new Conferenza(nome, data, postiTotali, relatore, prezzo);
        listaProgramma.AggiungiEvento(nuovaConferenza);
    }catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

