using System;

namespace Exercicio5
{
    class Program
    {
        static void Main(string[] args)
        {
            #if DEBUG
                #warning We're running in Debug mode
            #elif RELEASE
                #error Code not ready for Release!
            #else
                #error Unknown build configuration!
            #endif
        }
    }
}
