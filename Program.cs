using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_PosizionamentoNumerico
{
    internal class Program
    {
        static int InserimentoLet()
        {
            //inserimento
            Console.WriteLine("Inserire le 4 lettere della targa nella stessa linea");
            int vallettere=0;
            string lettere = Console.ReadLine().ToUpper(); //inserimento delle lettere come un array di carattere (stringa)
            //controllo: stringa deve essere avere 4 lettere in totale
            if (lettere.Length < 4 || lettere.Length > 4)
            {
                Console.WriteLine("stringa invalida!");
            }
            else
            {
                for (int i = 0; i < lettere.Length; i++)
                {

                    char lettera = lettere[i];  
                    int posizione = (lettera - 'A') * (int)Math.Pow(26, i);
                    vallettere += posizione * (int)Math.Pow(10, 3);

                }
            }
            return vallettere;
        }
        static int InserimentoNum()
        {
            Console.WriteLine("Inserire i 3 numeri della targa");
            int valnumeri = 0;
            for (int i = 0; i < 3; i++)
            {
                int numero = Convert.ToInt32(Console.ReadLine());
                valnumeri = numero * (int)Math.Pow(10, i);

            }
            return valnumeri;
        }
        static long Calcolo(int valnumeri, int vallettere)
        {
            long valore = valnumeri + vallettere;
            return valore;
        }

    
        static void Main(string[] args)
        {
            int valnumeri = InserimentoNum();
            int vallettere = InserimentoLet();
            long valore;
          
            valore = Calcolo(valnumeri,vallettere);
            Console.WriteLine($"il risultato: {valore}");
          
            Console.ReadLine();
        }
    }
}
