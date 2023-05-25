using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PongGame
{
    public class Game
    {
            //this is a list of tings I need to make a Console Pong Game
            //ticks / while loop
                //keep track of time
                //to update every tick
            //Display
                //most have a width and height
                //most have a way to clear it and update every tick
            //Ball
                //most move every tick
                //most bounce off walls
                //most bounce off paddle
                //has a direction it moves in
            //Paddle
                //most move up and down
                //most not go off screen
                //has a fixed height and width
                //most bounce ball
            //score
                //most keep track of score
                //most display score

            private int ticksSpeed; // 1000 = 1 tick per second
            private int displayWidth;
            private int displayHeight;
            private bool shouldContinue;

            private Paddle playerLeft;
            private Paddle playerRight;
            private Ball ball;
            private Display display;
            public Game()
            {
                ticksSpeed = 200;
                displayWidth = 30;
                displayHeight = 15;
                shouldContinue = true;
                playerLeft = new Paddle(0, displayHeight/2);
                playerRight = new Paddle(displayWidth-1, displayHeight/2);
                ball = new Ball(displayWidth, displayHeight);
                display = new Display(playerLeft, playerRight, ball, displayWidth, displayHeight);
            }

            public void Start()
            {
                // Spawn a new thread to listen for user input
                Thread inputThread = new Thread(ListenForInput);
                // Start the thread and check for input every 10ms
                inputThread.Start();

                while (shouldContinue)
                {
                    ball.Update(display, playerLeft, playerRight);
                    ball.CheckIfPlayerScored(display, playerLeft, playerRight);
                    ticksSpeed = 200 - ball.AmountOfPlayerBounces*30;
                    display.Update();
                    Thread.Sleep(ticksSpeed);
                }
            }

            void ListenForInput()
            {
                while (true)
                {
                    if (Console.KeyAvailable == false)
                    {
                        continue;
                    }
                    var key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.Q)
                    {
                        shouldContinue = false;
                        break;
                    }
                    else if (key.Key == ConsoleKey.W)
                    {
                        if (playerLeft.Y <= 1)
                        {
                            continue;
                        }
                        playerLeft.MoveUp(display);
                        display.Update();

                    }
                    else if (key.Key == ConsoleKey.S)
                    {
                        if (playerLeft.Y >= 13)
                        {
                            continue;
                        }
                        playerLeft.MoveDown(display);
                        display.Update();
                    }
                    else if (key.Key == ConsoleKey.UpArrow)
                    {
                        if (playerRight.Y <= 1)
                        {
                            continue;
                        }
                        playerRight.MoveUp(display);
                        display.Update();
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        if (playerRight.Y >= 13)
                        {
                            continue;
                        }
                        playerRight.MoveDown(display);
                        display.Update();
                    }

                    Thread.Sleep(10);
                }
            }
    }
}