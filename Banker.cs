using System.Collections.Generic;

namespace Monopoly
{

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
                player.ChoosePawn(pawns);
            }
        }

        public void GiveMoneyTo(Player player, int amount)
        {
            DomainEvent.Publish($"Banker gives money to Player", player, amount);
            player.TakeMoney(1500);
        }
    }

}