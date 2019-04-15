using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        
        static void Main(string[] args)

        {
        int n;
        int[] TFIBONACCI = new int[9000000];
        TFIBONACCI[0] = 0;
        TFIBONACCI[1] = 1;
        int TERMFIB=1;
        int S1 = Convert.ToInt32(TFIBONACCI[0]);
        int S2 = Convert.ToInt32(TFIBONACCI[1]);

            Console.WriteLine("El Numero de Termino de la Serie de Fibonacci :");
            n = int.Parse(Console.ReadLine());

          //foreach (int i= 0; i <= n; i++)
         for (int i=0;i<=n;i++)
                 
            {
                TFIBONACCI[i + 2] = TFIBONACCI[i + 1] + TFIBONACCI[i];
                TERMFIB = Convert.ToInt32(TFIBONACCI[i]);
                Console.WriteLine("El termino de la serie fibonacci es:" +TERMFIB);          
            }


            Console.ReadKey();
        
        
        }
    }
}
