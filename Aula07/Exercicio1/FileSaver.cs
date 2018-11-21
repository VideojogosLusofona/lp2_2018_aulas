using System;
using System.IO;
using System.Text;

namespace Exercicio1
{
    public class FileSaver : IObserver
    {
        // File where to put pressed keys
        private readonly string filename;

        // Constructor
        public FileSaver(string filename)
        {
            this.filename = filename;
        }

        // Update, called by the subject when something new is happening
        public void Update(ISubject sub)
        {
            // Get the last key pressed
            ConsoleKeyInfo keyInfo = (sub as KeyReader).KeyInfo;

            // Save it to a file
            File.AppendAllText(
                filename, keyInfo.KeyChar.ToString(), Encoding.UTF8);
        }
    }
}
