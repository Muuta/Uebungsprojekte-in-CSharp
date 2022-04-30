using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Model.Neues
{
    //Schnittstellen / interfaces
    /* funktionieren ähnlich wie abstrakte Klassen, die aus rein abstrakten bestehen
     * 
     * Schnittstellen werden implementiert - ein Klient implementiert die Schnittstelle
     * Schnittellen ersetzen fehlende Mehrfachvererbung
     * 
     * Klient verpflichtet sich dazu, die vorgeschriebenen Member zu implementieren
     * 
     * VERTRAG / contract
     * 
     * */
    interface iSchnittstelle
    {
        public void Tuwas();
        public int Zahl { get; set; }
    }

    class Klient : iSchnittstelle
    {
        private int _zahl;
        public int Zahl {
            get { return _zahl; }
            set { _zahl = value; }
        }

        public void Tuwas()
        {
            throw new NotImplementedException();
        }
    }

    class Klient2 : iSchnittstelle
    {
        private int _zahl;
        public int Zahl
        {
            get { return _zahl; }
            set { _zahl = value; }
        }

        public void Tuwas()
        {
            throw new NotImplementedException();
        }
    }
}
