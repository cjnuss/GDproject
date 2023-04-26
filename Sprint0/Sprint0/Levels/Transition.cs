using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace Sprint0
{
    public class Transition
    {
        int direction;

        int X;
        int Y;

        Boolean transition;

        private Link linkSprite;

        GameManager gameManager;

        public Transition(GameManager gameManager, Link linkSprite)
        {
            this.gameManager = gameManager;
            this.linkSprite = linkSprite;
            transition = false;
        }
        
        public void StartTransition(Door door, List<int> rooms)
        {
            transition = true;

            X = gameManager.source.X;
            Y = gameManager.source.Y;

            if (door.location.X < 75)
            {
                direction = 0;
                gameManager.roomNum = rooms[0];
            }
            else if (door.location.Y < 215)
            {
                direction = 1;
                gameManager.roomNum = rooms[1];
            }
            else if (door.location.X > 715)
            {
                direction = 2;
                gameManager.roomNum = rooms[2];
            }   
            else if (door.location.Y > 550)
            {
                direction = 3;
                gameManager.roomNum = rooms[3];
            }
        }

        public void MoveScreen()
        {
            switch (direction)
            {
                case 0:
                    if (X - gameManager.source.X == 256)
                    {
                        transition = false;
                        gameManager.SetState(1);
                        linkSprite.location = new Microsoft.Xna.Framework.Vector2(650, 365);
                    } else
                    {
                        gameManager.source.X -= 2;
                    }
                    break;
                case 1:
                    if (Y - gameManager.source.Y == 176)
                    {
                        transition = false;
                        gameManager.SetState(1);
                        linkSprite.location = new Microsoft.Xna.Framework.Vector2(375, 493);
                    }
                    else
                    {
                        gameManager.source.Y -= 2;
                    }
                    break;
                case 2:
                    if (gameManager.source.X - X == 256)
                    {
                        transition = false;
                        gameManager.SetState(1);
                        linkSprite.location = new Microsoft.Xna.Framework.Vector2(100, 365);
                    }
                    else
                    {
                        gameManager.source.X += 2;
                    }
                    break;
                case 3:
                    if (gameManager.source.Y - Y == 176)
                    {
                        transition = false;
                        gameManager.SetState(1);
                        linkSprite.location = new Microsoft.Xna.Framework.Vector2(375, 238);
                    }
                    else
                    {
                        gameManager.source.Y += 2;
                    }
                    break;
            }
        }

    }
}
