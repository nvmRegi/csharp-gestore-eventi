using GestoreEventi;

Console.WriteLine("BENVENUTI NEL MIO PROGARMMA!\n");

Console.WriteLine("------- Nuovo Evento --------");
Console.Write("Inserisci il nome dell'evento: ");
string nome = Console.ReadLine();
Console.Write("Inserisci la data dell'evento (gg/mm/yyyy");
DateTime data = DateTime.Parse(Console.ReadLine());
Console.WriteLine("Inserisci il numero di posti totali: ");
int postiTotali = int.Parse(Console.ReadLine());

Evento nuovoEvento = new Evento(nome, data, postiTotali);

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

