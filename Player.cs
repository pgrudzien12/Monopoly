using System;
using System.Collections.Generic;

namespace Monopoly
{
    public class Player
    {
        private int myMoney;
        private Role myRole;
        private Pawn myPawn;
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

        public void ChoosePawn(List<Pawn> pawns)
        {
            myPawn = pawns[0];
            pawns.RemoveAt(0);
        }
    }
}