using System;
using System.Collections.Generic;
using System.Text;

namespace game
{
    class WinCondition
    {
        int y;
        int x;
        int movescount;
     
        public WinCondition(int computermove, int gamermove, int movescount)
        {
            this.y = computermove;
            this.x = gamermove;
            this.movescount = movescount;
        }

        public void CheckWinner()
        {
            int c = movescount / 2;
            if ((x <= c && y > x && y <= x + c)||(x > c && (y > x || y < x - c)))
            {
                Console.WriteLine("You lose!");
            }
            else if (x == y)
                Console.WriteLine("Draw");
            else Console.WriteLine("You win!");
        }

        public static string CheckWinner(int x,int y,int movescount)
        {
            int c = movescount / 2;
            if (x == y)
                return "draw";
            if ((x <= c && y > x && y <= x + c) || (x > c && (y > x || y < x - c)))
                return "lose";
            else return "win";
        }
    }
}
