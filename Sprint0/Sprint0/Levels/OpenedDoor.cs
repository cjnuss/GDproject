using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class OpenedDoor
    {

        Texture2D doors = LevelsTextureStorage.Instance.Doors();

        Rectangle northDoor = LevelsTextureStorage.northDoor;
        Rectangle southDoor = LevelsTextureStorage.southDoor;
        Rectangle eastDoor = LevelsTextureStorage.eastDoor;
        Rectangle westDoor = LevelsTextureStorage.westDoor;

        Rectangle brokenNorthDoor = LevelsTextureStorage.brokenNorthDoor;
        Rectangle brokenSouthDoor = LevelsTextureStorage.brokenSouthDoor;

        Rectangle doorOne;
        Rectangle doorTwo;

        Rectangle targetOne;
        Rectangle targetTwo;

        private int direction;

        private int yCount;
        private int xCount;

        private int X;
        private int Y;

        public OpenedDoor(int direction) 
        {
            this.direction = direction; 

            switch (direction)
            {
                case 0:
                    doorOne = westDoor;
                    doorTwo = eastDoor;

                    targetOne = new Rectangle(0, 346, 100, 87);
                    targetTwo = new Rectangle(-100, 346, 100, 87);
                    break;
                case 1:
                    doorOne = northDoor;
                    doorTwo = southDoor;

                    targetOne = new Rectangle(350, 150, 100, 87);
                    targetTwo = new Rectangle(350, 63, 100, 87);
                    break;
                case 2:
                    doorOne = eastDoor;
                    doorTwo = westDoor;

                    targetOne = new Rectangle(700, 346, 100, 87);
                    targetTwo = new Rectangle(800, 346, 100, 87);
                    break;
                case 3:
                    doorOne = southDoor;
                    doorTwo = northDoor;

                    targetOne = new Rectangle(350, 543, 100, 87);
                    targetTwo = new Rectangle(350, 630, 100, 87);
                    break;
                default:
                    break;
            }
        }

        public void transition(int direction)
        {
            this.direction = direction;

            X = targetOne.X;
            Y = targetOne.Y;

            xCount = 1;
            yCount = 1;
        }

        public void Update()
        {
            switch (direction)
            {
                case 0:
                    if (!(targetOne.X - X == 800))
                    {
                        if (xCount == 4)
                        {
                            xCount = 1;
                            targetOne.X += 7;
                            targetTwo.X += 7;
                        }
                        else
                        {
                            xCount++;
                            targetOne.X += 6;
                            targetTwo.X += 6;
                        }
                    }
                    break;
                case 1:
                    if (!(targetOne.Y - Y == 480))
                    {
                        if (yCount % 2 != 0)
                        {
                            yCount++;
                            targetOne.Y += 5;
                            targetTwo.Y += 5;

                            if (yCount == 11)
                            {
                                yCount = 1;
                            }
                        }
                        else
                        {
                            yCount++;
                            targetOne.Y += 6;
                            targetTwo.Y += 6;
                        }
                    }
                    break;
                case 2:
                    if (!(X - targetOne.X == 800))
                    {
                        if (xCount == 4)
                        {
                            xCount = 1;
                            targetOne.X -= 7;
                            targetTwo.X -= 7;
                        }
                        else
                        {
                            xCount++;
                            targetOne.X -= 6;
                            targetTwo.X -= 6;
                        }
                    }
                    break;
                case 3:
                    if (!(Y - targetOne.Y == 480))
                    {
                        if (yCount % 2 != 0)
                        {
                            yCount++;
                            targetOne.Y -= 5;
                            targetTwo.Y -= 5;

                            if (yCount == 11)
                            {
                                yCount = 1;
                            }
                        }
                        else
                        {
                            yCount++;
                            targetOne.Y -= 6;
                            targetTwo.Y -= 6;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(doors, targetOne, doorOne, Color.White);
            _spriteBatch.Draw(doors, targetTwo, doorTwo, Color.White);
        }
    }
}
