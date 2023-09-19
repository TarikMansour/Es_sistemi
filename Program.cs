using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_PosizionamentoNumerico
{
    internal class Program
    {
        static void Inserimento(int[] targa)
        {
            //inserimento
            Console.WriteLine("Inserire i 3 numeri della targa");
            for (int i = 0; i < 3; i++)
            {
                targa[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Inserire le 4 lettere della targa nella stessa linea");
            string lettere = Console.ReadLine().ToUpper(); //inserimento delle lettere come un array di carattere (stringa)
            for (int i = 0; i < lettere.Length; i++)
            {
                char lettera = lettere[i]; //lettere della stringa vengono salvate dentro un char 
                int posizione = lettera - 'A' + 1; //calcolo della posizione della lettere sull'alfabeto sottraendo il valore ASCII di A dalla lettera inserita e + 1 per partire da 1 invece di 0
                targa[i + 3] = posizione; //partendo dall'indice 3 riempio l'array con le lettere
            }

        }
        static void MoltiplicaECopia(int[] targa, long[] multinumeri, long[] multilettere) 
        {
            for (int i = 0; i < targa.Length; i++) 
            {
                int index = i;
                targa[i] *= (int)Math.Pow(10, index); //funzione che moltiplica i numeri dentro l'array per 10 alla potenza del loro indice
                //queste due metodi servono per copiare sia la parte numerica che letterale su due array di tipo long che hanno una capacita maggiore e anche per rendere piu facile i calcoli
                Array.Copy(targa, 0, multinumeri, 0, 3); 
                Array.Copy(targa, 3, multilettere, 0, 4);
            }
            for (int i = 0; i < multilettere.Length; i++)
            {
                int index = i;
                multilettere[i] *= (int)Math.Pow(26, index); //funzione che moltiplica i numeri dentro l'array di lettere per 26 alla potenza del loro indice
            }


        }
        static void Main(string[] args)
        {
            int[] targa = new int[7];
            long[] multilettere = new long[4];
            long[] multinumeri = new long[3];
            Inserimento(targa);
            Console.WriteLine("Targa originale:");
            for (int i = 0; i < targa.Length; i++)
            {
                Console.Write(targa[i] + " ");
            }
            Console.WriteLine();
            MoltiplicaECopia(targa, multinumeri, multilettere);
            Console.WriteLine("Targa completa:");
            for (int i = 0; i < multinumeri.Length; i++)
            {
                Console.Write(multinumeri[i] + " ");
            }
            for (int i = 0; i < multilettere.Length; i++)
            {
                Console.Write(multilettere[i] + " ");
            }
            Console.ReadLine();
        }
    }
}
