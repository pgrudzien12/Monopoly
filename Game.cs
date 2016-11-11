using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    public class Game
    {
        private List<Player> myPlayers;
        private List<PlayerController> myPlayerControllers;
        public void Start()
        {

            const int MaxTurns = 10;
            for (int i = 0; i < MaxTurns; i++)
            {
                foreach (var pc in myPlayerControllers)
                {
                    pc.MakeMove();
                }

            }
        }

        public void SetPlayers(List<Player> players)
        {
            Dice dice = new Dice(6);
            myPlayers = players;
            myPlayerControllers = myPlayers.Select(p => new PlayerController(p, dice)).ToList();
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

        public List<Pawn> GetPawns()
        {
            var list = new List<Pawn>();
            for (int i = 0; i < myPlayers.Count; i++)
            {
                var pawn = new Pawn("red", i.ToString());

                list.Add(pawn);
            }

            return list;
        }
    }
}