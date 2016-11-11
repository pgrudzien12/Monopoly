using System;

namespace Monopoly
{
    public class Dice
    {
        private readonly Random r = new Random();
        private readonly int myMaxScore;
        public Dice (int maxScore)
        {
            this.myMaxScore = maxScore;
        }
        public int RollTwice()
        {
            return Roll() + Roll();
        }

        public int Roll()
        {
            return r.Next(1, 6);
        }
    }
}