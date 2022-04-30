using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Events01
{
    internal class Uhr
    {
        private int _sekunde;

        public int Sekunde
        {
            get { 
                return _sekunde; 
            }
            set { 
                _sekunde = value;
                // ZeitGeändert?.Invoke(_sekunde);
                if(ZeitGeändert != null)
                    ZeitGeändert(_sekunde); // Event feuern! Methode ausführen
            }
        }

        // public int Sekunde { get; set; }
        public event Action<int> ZeitGeändert;
        public Uhr()
        {
            Sekunde = 0;
            // Run();
        }
        public void Run()
        {
            while(true)
            {
                Sekunde += 1;
                Thread.Sleep(1000);
            }
        }
    }
}
