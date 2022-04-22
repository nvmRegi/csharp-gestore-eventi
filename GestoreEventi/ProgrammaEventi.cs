using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    internal class ProgrammaEventi
    {
        private string Titolo;
        private List<Evento> Eventi;

        public List<Evento> GetEventi()
        {
            return Eventi;
        }

        public ProgrammaEventi(string titolo)
        {
            this.Titolo = titolo;
            this.Eventi = new List<Evento>();
        }

        public void AggiungiEvento(Evento nuovoEvento)
        {
            Eventi.Add(nuovoEvento);
        }

        //metodo che restituisce una lista con tutti gli elementi di una certa data
        public List<Evento> EventiInData(DateTime data)
        {
            List<Evento> lista = new List<Evento>();

            for(int i = 0; i < Eventi.Count; i++)
            {
                if(Eventi[i].GetDataEvento() == data)
                {
                    lista.Add(Eventi[i]);
                }
            }
            return lista;
        }

        public static void stampaLista(List<Evento> lista)
        {
            foreach(Evento evento in lista)
            {
                Console.WriteLine(evento.ToString());
            }
        }

        public int nEventi()
        {
            return Eventi.Count;
        }

        public void SvuotaLista()
        {
            Eventi.Clear();
        }

        public string stampaListaConTitolo()
        {
            string stampaLista = "";

            foreach(Evento evento in Eventi)
            {
                stampaLista += evento.ToString() + "\n";
            }
            
            return stampaLista;
        }

        public int selezionaEvento(string nomeEvento)
        {
            int indiceNome = -1;
            List<Evento> listaEvento = GetEventi();

            for(int i = 0; i < listaEvento.Count; i++) //trovo evento tramite nome
            {
                if(listaEvento[i].GetTitoloEvento() == nomeEvento)
                {
                    indiceNome = i;
                    break;
                }
            }
            if(indiceNome == -1)
            {
                throw new ArgumentNullException(nomeEvento);
            }

            return indiceNome;
        }
    }
}
