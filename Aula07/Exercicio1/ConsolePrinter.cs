using System;

namespace Exercicio1
{
    public class ConsolePrinter : IObserver
    {
        // Update, called by the subject when something new is happening
        public void Update(ISubject sub)
        {
            // Get the last key pressed
            ConsoleKeyInfo keyInfo = (sub as KeyReader).KeyInfo;

            // Say something about the last key pressed
            Console.WriteLine($"The '{keyInfo.KeyChar}' key was pressed! ");
        }
    }
}
