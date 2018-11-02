using System;
using System.Collections.Generic;

namespace Aula04
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Use our enumerator directly

            // 1.1 Instantiate the enumerator
            IEnumerator<int> enumer = new MyEnumerator();

            // 1.2 Use it in a while loop, old school style
            while (enumer.MoveNext())
            {
                Console.Write($"{enumer.Current} ");
            }
            Console.WriteLine();

            // 2. Get our enumerator from a fake collection

            // 2.1 Instantiate our fake collection
            IEnumerable<int> fakeCollection = new FakeCollection();

            // 2.2 Use it a foreach, new school style
            foreach (int i in fakeCollection)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

        }
    }
}
