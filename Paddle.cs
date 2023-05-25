using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PongGame
{
    public class Paddle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Score { get; set; } = 0;

        public Paddle(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void MoveUp(Display display)
        {
            if (Y <= 1)
            {
                return;
            }
            display.DisplayValues[X, Y] = ' ';
            Y--;
            display.DisplayValues[X, Y] = '|';
        }

        public void MoveDown(Display display)
        {
            if (Y >= display.DisplayHeight - 2)
            {
                return;
            }
            display.DisplayValues[X, Y] = ' ';
            Y++;
            display.DisplayValues[X, Y] = '|';
        }
    }
}