using GestoreEventi;

Console.WriteLine("BENVENUTI NEL MIO PROGARMMA!\n");

//-------MILESTONE 4--------
Console.Write("Inserisci il nome del tuo pragamma Eventi: ");
string nomeProgramma = Console.ReadLine();
Console.Write("Indica il numero di eventi da inserire: ");
int nEventi = int.Parse(Console.ReadLine());

ProgrammaEventi listaProgramma = new ProgrammaEventi(nomeProgramma);

int iterazione = 0;
while(iterazione < nEventi)
{
    Console.WriteLine("------- Nuovo Evento --------");
    Console.Write("Inserisci il nome del" + (iterazione + 1) + "° evento: ");
    string nome = Console.ReadLine();
    Console.Write("Inserisci la data dell'evento (gg/mm/yyyy): ");
    DateTime data = DateTime.Parse(Console.ReadLine());
    Console.Write("Inserisci il numero di posti totali: ");
    int postiTotali = int.Parse(Console.ReadLine());

    Evento nuovoEvento = new Evento(nome, data, postiTotali);

    if(nuovoEvento.eventoValido)
    {
        listaProgramma.AggiungiEvento(nuovoEvento);
        iterazione++;
    } else
    {
        Console.WriteLine("\nRiprovare");
    }
}

Console.WriteLine("Il numero di eventi nel programma è: " + listaProgramma.nEventi());

listaProgramma.stampaListaConTitolo();

Console.WriteLine("Inserisci una data per sapere che eventi ci saranno (gg/mm/yyyy): ");
DateTime FindData = DateTime.Parse(Console.ReadLine());

ProgrammaEventi.stampaLista(listaProgramma.EventiInData(FindData));

//------MILESTONE 1--------
while(true)
{
    Console.WriteLine("\nVuoi prenotare o disdire un posto? (si/no)");
    string risposta = Console.ReadLine();

    Console.WriteLine("0 - Prenota");
    Console.WriteLine("1 - Disdici");

    risposta = Console.ReadLine();
    switch(risposta)
    {
        case "0":

            //Console.Clear();

            Console.Write("\nQuanti posti desideri prenotare? ");
            int nPrenotazioni = int.Parse(Console.ReadLine());

            nuovoEvento.PrenotaPosti(nPrenotazioni);

            nuovoEvento.stampaPosti();
        break;

        case "1":

            //Console.Clear();

            Console.WriteLine("Quanti posti desideri disdire? ");
            int nCancellazioni = int.Parse(Console.ReadLine());
            
            nuovoEvento.DisdiciPosti(nCancellazioni);

            nuovoEvento.stampaPosti();            
        break;

        default:
            Console.WriteLine("Errore");
        break;
    }
}

