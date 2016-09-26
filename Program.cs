using System.Collections.Generic;

namespace Monopoly
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Game game = new Game();
            List<Player> players = new List<Player>();
            players.Add(new Player());
            players.Add(new Player());
            players.Add(new Player());
            players.Add(new Player());

            Banker banker = new Banker();
            banker.SetUp(game, players);

            game.Start();
        }
    }
}
