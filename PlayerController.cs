namespace Monopoly
{
        public class PlayerController
    {
        private readonly Player me;
        private readonly Dice myDice;

        public PlayerController(Player me, Dice dice)
        {
            this.me = me;
            this.myDice = dice;
        }

        public void MakeMove()
        {
            var dice = new Dice(6);
            var rollScore = dice.RollTwice();
        }
    }
}