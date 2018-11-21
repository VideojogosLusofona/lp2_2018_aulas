using System;
using System.Collections.Generic;

namespace Exercicio1
{
    public class KeyReader : ISubject
    {
        // The last key read from the console
        public ConsoleKeyInfo KeyInfo
        {
            get
            {
                // Return the latest key read
                return keyInfo;
            }
            private set
            {
                // Set the latest key read
                keyInfo = value;
                // Notify observers that we have a new key read
                NotifyObservers();
            }
        }

        // Support variable for the KeyInfo property
        private ConsoleKeyInfo keyInfo;

        // Our current observers are kept here
        private readonly ICollection<IObserver> observers;

        // Constructor
        public KeyReader()
        {
            // Instantiate the set of observers
            observers = new HashSet<IObserver>();
        }

        // Register an observer
        public void RegisterObserver(IObserver obs)
        {
            observers.Add(obs);
        }

        // Remover an observer
        public void RemoveObserver(IObserver obs)
        {
            observers.Remove(obs);
        }

        // Notify observers
        public void NotifyObservers()
        {
            foreach (IObserver obs in observers)
            {
                obs.Update(this);
            }
        }

        // Read keys from console
        public void ReadKeys()
        {
            // Ask for keys while user does not press Escape
            do
            {
                // Read key
                KeyInfo = Console.ReadKey(true);
            }
            while (KeyInfo.Key != ConsoleKey.Escape);
        }
    }
}
