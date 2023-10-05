using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionDecPunt
{
    internal class Program
    {
        static bool[] Convert_Dp_To_Binario(int[] dp)
        {
            bool[] bn = new bool[32]; //ARRAY BOOL 32BIT
            int ultimoElemento = bn.Length - 1; 
            for (int j = 0; j < dp.Length; j++)
            {
                int otetto = dp[j]; //ASSEGNO OTETTI
                for (int i = 7; i >= 0; i--) //CICLO INVERSO
                {

                    bn[ultimoElemento] = otetto % 2 == 1; //SE RESTO DELLA DIVISIONE RISULTA 1 (TRUE) INSERIRE, ALTRIMENTI DEFAULT VALUE (0)
                    otetto /= 2; //DIVISIONE BASE
                    ultimoElemento--; //CON OGNI ITERAZIONE L'ARRAY 'DIMINUISCE'

                }
            }

            return bn;
        }
        static long Convert_Dp_To_Intero(int[] dp)
        {
            long num = 0;
            int pos = dp.Length-1; //TIENE TRACCIA DELLA POSIZIONE E ULTIMO ELEMENTO 
            for (int i = 0; i < dp.Length; i++)
            {
                num += (long)dp[i] * (int)Math.Pow(256, pos); //CIFRA * BASE ^ POSIZIONE OTETTO
                pos--;
            }
            return num;
        }
        static long Convert_Bin_To_Intero(bool[] bn)
        {
            long intero = 0;
            int ultimoElemento = bn.Length - 1;
            for (int i = 0; i < bn.Length; i++)
            {
                if (bn[i]) //SE BN[I] RISULTA TRUE OVVERO 1 
                {
                    intero += (long)Math.Pow(2, ultimoElemento - i);  //CIFRA * 2^ POSIZIONE IN BASE DELLE 32 CIFRE
                }
            }
            return intero;
        }
        static int[] Convert_Bin_To_Dec(bool[] bn)
        {
           
            int calcolo = 0, ultimoElemento = 7;
            int[] dp = new int[4];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = 0;
               
                for (int j = 0; j < 8; j++)
                {
                    int pos = i * 8 + j;
                    if (bn[pos])
                    {
                        dp[i] += (int)(Convert.ToInt32(bn[i]) * Math.Pow(10, i)); //CIFRA * 10^ POSIZIONE IN BASE DELLE 32 CIFRE
                    }
                }
               
            }
            return dp;
        }
        static void Main(string[] args)
        {
            int[] dp = new int[4];
            for (int i = 0; i < 4; i++)
            {
                do
                {
                    Console.WriteLine($"inserisce il {i + 1} otteto");
                    dp[i] = Convert.ToInt32(Console.ReadLine());
                    if (dp[i] < 0 || dp[i] > 255)
                    {
                        Console.WriteLine("errore di range");
                        Console.ReadLine();
                    }
                } while (dp[i] < 0 || dp[i] > 255);

            }
            bool[] bn = Convert_Dp_To_Binario(dp);
            Console.WriteLine("Decimale puntata in binario:");
            for (int i = 0; i < bn.Length; i++)
            {
                Console.Write(Convert.ToInt32(bn[i]));
            }
            Console.WriteLine();
            int[] binnum = Convert_Bin_To_Dec(bn);
            Console.WriteLine("Binario in decimale:");
            for (int i = 0; i< binnum.Length; i++)
            {
                Console.Write(binnum[i]);
            }
            Console.WriteLine() ;
            Console.WriteLine("Decimale puntata in intero:");
            Console.WriteLine(Convert_Dp_To_Intero(dp));
       
            Console.WriteLine("Binario in intero:");
            Console.WriteLine(Convert_Bin_To_Intero(bn));
            Console.ReadLine();


        }
    }
}