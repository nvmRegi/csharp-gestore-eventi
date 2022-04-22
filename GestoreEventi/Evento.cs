using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    internal class Evento
    {
        private string titoloEvento; //lettura e scrittura
        private DateTime dataEvento; //lettura e scrittura
        private int MaxCapienza; //lettura
        private int nPostiPrenotati; //lettura

        //------getter e setter-----
        private void SetTitoloEvento(string titolo)
        {
            if(titolo == null)
            {
                throw new ArgumentNullException(nameof(titolo));
            } else
            {
                this.titoloEvento = titolo;
            }
        }

        public string GetTitoloEvento()
        {
            return this.titoloEvento;
        }

        private void SetDataEvento(DateTime data)
        {
            if(data < DateTime.Now)
            {
                throw new InvalidTimeZoneException(nameof(data));
            } else
            {
                this.dataEvento = data;
            }
        }

        public DateTime GetDataEvento()
        {
            return this.dataEvento;
        }

        private void SetMaxCapienza(int maxCapienza)
        {
            if(maxCapienza < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxCapienza));
            } else
            {
                this.MaxCapienza = maxCapienza;
            }
        }

        public int GetMaxCapienza()
        {
            return this.MaxCapienza;
        }

        public int GetNPostiPrenotati()
        {
            return this.nPostiPrenotati;
        }

        //------costruttore-------
        public Evento(string titolo, DateTime data, int maxCapienza)
        {
            try
            {
                SetTitoloEvento(titolo);
            } catch (ArgumentNullException e)
            {
                Console.WriteLine("Non hai inserito nessun titolo! ERRORE:" + e.ParamName);
            }

            try
            {
                SetDataEvento(data);
            } catch(InvalidTimeZoneException e)
            {
                Console.WriteLine("La data inserita è nel passato!");
            }

            try
            {
                SetMaxCapienza(maxCapienza);
            } catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Il numero inserito è negativo! ERRORE: " + e.ParamName);
            }

            this.nPostiPrenotati = 0;
        }

        //----------metodi---------
        public int nPostiDisponibili()
        {
            return this.MaxCapienza - this.nPostiPrenotati;
        }

        public void PrenotaPosti(int nPrenotazioni)
        {
            if(this.dataEvento < DateTime.Now)
            {
                throw new InvalidTimeZoneException();
            } else if(this.nPostiPrenotati + nPrenotazioni > this.MaxCapienza || this.nPostiPrenotati == this.MaxCapienza)
            {
                throw new ArgumentOutOfRangeException(nameof(MaxCapienza), "Limite posti disponibili");
            } else if(nPrenotazioni == null)
            {
                throw new ArgumentNullException(nameof(nPrenotazioni));
            } else
            {
                this.nPostiPrenotati += nPrenotazioni;
            }
        }

        public void DisdiciPosti(int nCancellazioni)
        {
            if(this.dataEvento < DateTime.Now)
            {
                throw new InvalidTimeZoneException();
            } else if(this.nPostiPrenotati - nCancellazioni < 0 || nPostiDisponibili() == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(MaxCapienza), "Non ci sono prenotazioni da disdire");
            } else if(nCancellazioni == null)
            {
                throw new ArgumentNullException(nameof(nCancellazioni));
            } else
            {
                this.nPostiPrenotati -= nCancellazioni;
            }
        }

        public override string ToString()
        {
            string stampaEvento = "";

            
            stampaEvento += this.dataEvento.ToString("dd/MM/yyyy") + " - " + this.titoloEvento;

            return stampaEvento;
        }
    }
}
