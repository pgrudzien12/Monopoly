using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    public class Player
    {
        private int myMoney;
        private Role myRole;
        public void TakeMoney(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException(nameof(amount));
            }

            myMoney += amount;
        }

        public void ChooseRole(List<Role> roles)
        {
            myRole = roles[0];
            roles.RemoveAt(0);
            DomainEvent.Publish($"Player choose role from available pool", this, myRole);
        }
    }

    public class Banker
    {
        public void SetUp(Game game, List<Player> players)
        {
            DomainEvent.Publish("Banker sets up the Game");
            game.SetPlayers(players);
            List<Role> roles = game.GetListOfRoles();
            List<Pawn> pawns = game.GetPawns();
            foreach (Player player in players)
            {
                GiveMoneyTo(player, 1500);
                player.ChooseRole(roles);
            }
        }

        public void GiveMoneyTo(Player player, int amount)
        {
            DomainEvent.Publish($"Banker gives money to Player", player, amount);
            player.TakeMoney(1500);
        }
    }

    public class Pawn
    {
        string myColor;
        string myShape;

        public Pawn(string color, string shape)
        {
            myColor = color;
            myShape = shape;
        }
    }

    public class Game
    {
        private List<Player> myPlayers;
        public void Start()
        {

        }

        public void SetPlayers(List<Player> players)
        {
            myPlayers = players;
        }

        internal List<Role> GetListOfRoles()
        {
            var list = new List<Role>();
            for (int i = 0; i < myPlayers.Count; i++)
            {
                list.Add(i % 2 == 0 ? Role.Entrepreneur : Role.Monopolist);
            }
            return list;
        }

        internal List<Pawn> GetPawns()
        {
            throw new NotImplementedException();
        }
    }

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

    public enum Role
    {
        Monopolist,
        Entrepreneur
    }
}