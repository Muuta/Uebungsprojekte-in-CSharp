using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Übung_Exception
{
//    class AlterOutOfBoundException : Exception 
//    {
//        public AlterOutOfBoundException(string message) : base(message)
//        {
//        }
//    }

//    class Person
//    {
//        private int _alter;

//        public int Alter
//        {
//            get { return _alter; }
//            set {
//                if (value >= 0 && value <= 120)
//                    _alter = value;
//                else
//                    throw new AlterOutOfBoundException("Alter nicht im Bereich 0..120");

////                throw new ArgumentException("Alter nicht im Bereich 0..120");
//            }
//        }

//    }

    class NoBinaryNumberException : ArgumentException
    {
        public List<int> Errors { get;  set; }
        public int Position { get; set; }
        public string Binary { get; set; }

        public NoBinaryNumberException(string message, int position) : base(message)
        {
            Position = position;

        }
        public NoBinaryNumberException(string bin, IEnumerable<int> errors) : base()
        {
            Errors = errors.ToList();
            Binary = bin;
        }

        public override string Message
        { 
         get
            {
                //string strError = "";
                //for (int i = Binary.Length-1; i >=0 ; i--)
                //{
                //    if(Errors.IndexOf(i) > -1) // Gefunden => Fehler
                //    {
                //        strError = strError + "x"  ;
                //    }else
                //    {
                //        strError = strError + "_";
                //    }
                //}
                //StringBuilder s = new StringBuilder(100000);
                //StringBuilder s2 = new StringBuilder("-_____-");
                StringBuilder strError = new StringBuilder(new string('_', Binary.Length));
                
                // strError.GetHashCode();
                
                // char[] strError2 = new string('_', Binary.Length).ToCharArray();

                foreach (int epos in Errors)
                {
                    strError[Binary.Length - 1 - epos] = 'X';
                }
                // string s3 = new string(strError2);

                string result = $"Error\n{Binary}\n{strError}";
                //result = "ERRRRROOOORRRR ..." + Errors.Count + " Fehler an Pos " + string.Join(',',Errors);
                return result;
            }
        }

    }

    internal class BinaryString
    {
        public static long BinaryToDecimal2(string input)
        {
            long m = 1;
            long res = 0;
            List<int> errors = new List<int>();
            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (input[i] >= '0' && input[i] <= '1')
                {
                    res += (input[i] - '0') * m;
                    m *= 2;
                }
                else
                {
                    int fehlerPos = input.Length - 1 - i;
                    errors.Add(fehlerPos); 
                }
            }
            if(errors.Count > 0)
                throw new NoBinaryNumberException(input,errors);
            
            return res;
        }



        public static long BinaryToDecimal(string input)
        {
            long m = 1;
            long res = 0;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                // char[] gueltig = { '0', '1','o','O' }; // ("0","1")
                // if(Array.BinarySearch(gueltig,input[i]) >=0)
                // if (input[i] == '0' || input[i] == '1')

                if (input[i] >= '0' && input[i] <= '1')
                {
                    res += (input[i] - '0') * m;
                    m *= 2;
                }
                else
                {
                    int fehlerPos = input.Length - 1 - i;
                    throw new NoBinaryNumberException("Fehler an Position " + fehlerPos, fehlerPos);
                    // FEHLERHAFTES ZEICHEN !!!
                }
            }
            return res;
        }

    }
}
