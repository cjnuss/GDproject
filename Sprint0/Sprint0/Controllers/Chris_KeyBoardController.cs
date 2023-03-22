using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;
using System.ComponentModel.Design;
using Sprint0.Link_Classes;
using static System.Reflection.Metadata.BlobBuilder;

namespace Sprint0
{
    public class KeyBoardController : IController
    {
        private Game1 game1;
        public Link linkSprite;

        public Texture2D Texture { get; set; }
        public SpriteBatch _spriteBatch;

        public int dir, linkState;
        public Vector2 location;

        public MapCommands mappingCommands;
        public Dictionary<Keys, ICommand> controllerMapping;


        private LinkMovementCollision linkMovementCollision;
        //for repeats
        Keys[] prevPressedKeys;
        Boolean first;



        public BlockCollisionCheck blockCollisionCheck;


        public KeyBoardController(Game1 game1, SpriteBatch spriteBatch)
        {
            this.game1 = game1;

            linkSprite = new Link(game1);

            controllerMapping = new Dictionary<Keys, ICommand>();
            mappingCommands = new MapCommands(this, controllerMapping, game1, linkSprite);

            mappingCommands.CreateCommands();
            controllerMapping = mappingCommands.getControllerMapping(controllerMapping);
            //take out repeats
            prevPressedKeys = new Keys[400];
            first = true;

            mappingCommands.CreateCommands();
            controllerMapping = mappingCommands.GetControllerMapping(controllerMapping);


            blockCollisionCheck = new BlockCollisionCheck(this, new LinkBlockCollision(this, linkSprite), game1, linkSprite);

            dir = 0; linkState = 0;
            _spriteBatch = spriteBatch;
        }
        private Boolean KeyHeld(Keys check, Keys[] prev)
        {
            for(int i = 0; i < prev.Length;i++)
            {
                if(check == prev[i])
                {
                    return true;
                }

            }
            return false;
        }
        public void Update(GameTime gameTime)
        {
            linkState = 0; // reset link state
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            Keys[] newKeys = new Keys[400];
            int count = 0;
            if(!first)
            {
                for(int i = 0; i < pressedKeys.Length; i++)
                {
                    //does not add previously pressed keys to new array
                    if(!KeyHeld(pressedKeys[i], prevPressedKeys))
                    {
                        newKeys[count] = pressedKeys[i];
                        count++;
                    }
                    else if (pressedKeys[i] == Keys.W || pressedKeys[i] == Keys.S || pressedKeys[i] == Keys.D || pressedKeys[i] == Keys.A ||
                        pressedKeys[i] == Keys.Up || pressedKeys[i] == Keys.Down || pressedKeys[i] == Keys.Right || pressedKeys[i] == Keys.Left)
                    {
                        //we want to add the movement keys anyway because they can be held
                        newKeys[count] = pressedKeys[i];
                        count++;
                    }
                }
            }
            else
            {
                newKeys = pressedKeys;
            }

            prevPressedKeys = pressedKeys;
            first = false;

            Array.Sort(newKeys);
            Array.Reverse(newKeys);

            if (newKeys.Length != 0 && controllerMapping.ContainsKey(newKeys[0]))
                controllerMapping[newKeys[0]].Execute(gameTime);

            // collision checks
            blockCollisionCheck.CheckCollision();
            // more to follow..
            
            linkSprite.Update(linkState, dir, location);
            linkSprite.Draw(_spriteBatch);
        }

    }
}
