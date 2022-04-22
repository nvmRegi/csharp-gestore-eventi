using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    internal class Conferenza : Evento
    {
        private string relatore;
        private double prezzo;

        public Conferenza(string titolo, DateTime data, int maxCapienza, string relatore, double prezzo) : base(titolo, data, maxCapienza)
        {
            this.relatore = relatore;
            this.prezzo = prezzo;
        }

        public string GetRelatore()
        {
            return this.relatore;
        }

        public double GetPrezzo()
        {
            return this.prezzo;
        }

        public string DataEOraFormattata()
        {
            return GetDataEvento().ToString("dd/MM/yyyy");
        }

        public string PrezzoFormattato()
        {
            return GetPrezzo().ToString("0.00");
        }

        public override string ToString()
        {
            string stampaConferenza = "";

            stampaConferenza += DataEOraFormattata() + " - ";
            stampaConferenza += GetTitoloEvento() + " - ";
            stampaConferenza += GetRelatore() + " - ";
            stampaConferenza += PrezzoFormattato();

            return stampaConferenza;
        }
    }
}
