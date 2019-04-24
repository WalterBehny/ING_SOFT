using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciTesting21042019
{
    class Program
    {
        private static object length;

        static void Main(string[] args)
        {
            {
                int n ;
                int i ;
                //int[] TFIBONACCI = new int[800000];
                long [] TFIBONACCI = new long[8000000];// Se usar long o ulong
                TFIBONACCI[0] = 0;
                TFIBONACCI[1] = 1;
                //int  TERMFIB = 0;
              
              
                Console.WriteLine(" \n \t \t El Numero de Termino de la Serie de Fibonacci :");

                n = Convert.ToInt32(Console.ReadLine());

                  //n = int.Parse(Console.ReadLine());
                  
                if (n<=0)
                { Console.WriteLine(" \n \t \t  SOLO VALORES POSITIVOS"); }


                //foreach (int i= 0; i <= n; i++)
                for ( i = 0; i <n; i++)

                {
                 
                    TFIBONACCI[i+2] = TFIBONACCI[i+1] + TFIBONACCI[i];

                    //TERMFIB =  Convert.ToInt32(TFIBONACCI[i]);
                    
                    Console.WriteLine(" \n \t\t El termino de la serie Fibonacci " + "F(" + (i+1) + ")" + "\t : \t" +TFIBONACCI[i+1]);

                }

                Console.ReadKey();





            }
        }
    }
}
