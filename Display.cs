using System;

namespace PongGame
{
    public class Display
    {
        // top and bottom walls are '-' and the player is '|' and the ball is 'o'
        // it starts as a 15x30 grid with everything ' ' exept the walls
        public char[,] DisplayValues;
        private Paddle PlayerLeft;
        private Paddle PlayerRight;
        private Ball _ball;
        public int DisplayWidth;
        public int DisplayHeight;

        public Display(Paddle playerLeft, Paddle playerRight, Ball ball, int displayWidth, int displayHeight)
        {
            PlayerLeft = playerLeft;
            PlayerRight = playerRight;
            _ball = ball;
            
            if (displayWidth < 3 || displayHeight < 3)
            {
                throw new Exception("Display width and height must be at least 3");
            }
            DisplayWidth = displayWidth;
            DisplayHeight = displayHeight;
            DisplayValues = new char[DisplayWidth, DisplayHeight];
            Initialize();
        }
        
        private void Initialize()
        {
            for (var i = 0; i < DisplayHeight; i++)
            {
                for (var j = 0; j < DisplayWidth; j++)
                {
                    if(i == 0 || i == DisplayHeight-1)
                    {
                        DisplayValues[j, i] = '-';
                    }
                    else
                    {
                        DisplayValues[j, i] = ' ';
                    }
                }
            }
            DisplayValues[0, PlayerLeft.Y] = '|';
            DisplayValues[DisplayWidth-1, PlayerRight.Y] = '|';
        }

        public void Update()
        {
            Console.Clear();
            Console.WriteLine("Score: " + PlayerLeft.Score + " - " + PlayerRight.Score);
            for (int i = 0; i < DisplayHeight; i++)
            {
                string output = "";
                for (var j = 0; j < DisplayWidth; j++)
                {
                    output += DisplayValues[j, i];
                }
                Console.WriteLine(output);
            }
            try
            {
                // Console.WriteLine("PlayerLeft: X: " + PlayerLeft.X + " Y: " + PlayerLeft.Y);
                // Console.WriteLine("PlayerRight: X: " + PlayerRight.X + " Y: " + PlayerRight.Y);
                // Console.WriteLine("Ball: X: " + _ball.X + " Y: " + _ball.Y);
                Console.WriteLine("Press 'q' to quit");
            }
            catch (System.Exception)
            {
                throw;
            }
  

        }
    }
}