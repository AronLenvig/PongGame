using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PongGame
{
    public class Ball
    {
        public int X;
        public int Y;
        public int XSpeed;
        public int YSpeed;
        public int DisplayWidth;
        public int DisplayHeight;
        public int AmountOfPlayerBounces = 0;
        public Random random = new Random();

        public Ball(int displayWidth, int displayHeight)
        {
            DisplayWidth = displayWidth;
            DisplayHeight = displayHeight;
            X = displayWidth/2;
            Y = displayHeight/2;
            // random number either 1 or -1
            XSpeed = random.Next(2) * 2 - 1;
            YSpeed = random.Next(2) * 2 - 1;
        }

        public void Update(Display display, Paddle playerLeft, Paddle playerRight)
        {
            display.DisplayValues[X, Y] = ' ';
            Move();
            CheckWallCollision();
            CheckPlayerCollision(playerLeft, playerRight);
            display.DisplayValues[X, Y] = 'O';
        }

        public bool CheckIfPlayerScored(Display display, Paddle playerLeft, Paddle playerRight)
        {
            if (X == 0)
            {
                playerRight.Score++;
                display.DisplayValues[X, Y] = ' ';
                Reset();
                return true;
            }
            if (X == DisplayWidth-1)
            {
                playerLeft.Score++;
                display.DisplayValues[X, Y] = ' ';
                Reset();
                return true;
            }
            return false;
        }

        private void Reset()
        {
            X = DisplayWidth/2;
            Y = DisplayHeight/2;
            XSpeed = random.Next(2) * 2 - 1;
            YSpeed = random.Next(2) * 2 - 1;
            AmountOfPlayerBounces = 0;
        }

        private void Move()
        {
            X += XSpeed;
            Y += YSpeed;
        }
        
        private void CheckWallCollision()
        {
            if (Y == 0 || Y == DisplayHeight-1)
            {
                YSpeed = YSpeed * -1;
                Y += YSpeed;
                Y += YSpeed;
            }
        }
            
        private void CheckPlayerCollision(Paddle playerLeft, Paddle playerRight)
        {
            if (X == playerLeft.X && Y == playerLeft.Y)
            {
                XSpeed = XSpeed * -1;
                X += XSpeed;
                X += XSpeed;
                AmountOfPlayerBounces++;
            }
            if (X == playerRight.X && Y == playerRight.Y)
            {
                XSpeed = XSpeed * -1;
                X += XSpeed;
                X += XSpeed;
                AmountOfPlayerBounces++;
            }
        }
    }
}