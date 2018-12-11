using System;
using System.Collections.Generic;

namespace Donjon
{
    internal class Messages
    {
        private List<string> messages = new List<string>();

        public Messages()
        {
        }

        internal void Add(string message)
        {
            messages.Add(message);            
        }

        internal IEnumerable<string> GetAll()
        {
            return messages.ToArray();
        }

        internal void Clear()
        {
            messages.Clear();
        }
    }
}