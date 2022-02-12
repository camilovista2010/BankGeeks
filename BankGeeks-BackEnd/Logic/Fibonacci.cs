using System.Collections.Generic;

namespace BankGeeks_BackEnd.Logic
{
    public static class Fibonacci 
    {
        public static List<int> listFibonacci = new List<int>();

        public static void InstanceFibonacci()
        {
            int a, b, i, aux;
            a = 0;
            b = 1;
            for (i = 0; i < 100; i++)
            {
                aux = a;
                a = b;
                b = aux + a;
                listFibonacci.Add(a);
            }
        }
    }
}
