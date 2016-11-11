using System;
using System.Collections.Generic;

namespace Monopoly
{
    public class DomainEvent
    {
        private static List<DomainEvent> domainEvents = new List<DomainEvent>();
        private object[] arguments;
        private string name;

        public DomainEvent(string name, object[] arguments)
        {
            this.name = name;
            this.arguments = arguments;
        }

        public static void Publish(string s, params object[] args)
        {
            System.Console.WriteLine("Event: " + s);

            domainEvents.Add(new DomainEvent(s, args));
        }
    }
}