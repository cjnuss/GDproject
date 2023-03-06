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
using Sprint0.Classes;
using Sprint0.Link_Classes;

namespace Sprint0
{
    public class KeyBoardController : IController
    {
        //implement
        private Game1 game1;
        public Link linkSprite;

        public Texture2D Texture { get; set; }
        public SpriteBatch _spriteBatch;

        public int dir, linkState;
        public Vector2 location;

        public MapCommands mappingCommands;

        //public ExitCommand exitCommand;
        //private ResetCommand resetCommand;
        
        //// player movement commands
        //private LinkMoveLeftCommand moveLeftCommand;
        //private LinkMoveRightCommand moveRightCommand;
        //private LinkMoveUpCommand moveUpCommand;
        //private LinkMoveDownCommand moveDownCommand;

        //private LinkDamageCommand linkDamageCommand;
        //private LinkAttackingCommand linkAttackingCommand;
        //private LinkThrowGreenArrowCommand linkThrowGreenArrowCommand;

        public Dictionary<Keys, ICommand> controllerMapping;

        public KeyBoardController(Game1 game1, SpriteBatch spriteBatch)
        {
            //need to change atlas and these calls
            this.game1 = game1;

            controllerMapping = new Dictionary<Keys, ICommand>();

            mappingCommands = new MapCommands(this, controllerMapping, game1, linkSprite);
            mappingCommands.createCommands();
            controllerMapping = mappingCommands.getControllerMapping(controllerMapping);

            //exitCommand = new ExitCommand(game1);
            //resetCommand = new ResetCommand(this, linkSprite, game1);
            
            //moveLeftCommand = new LinkMoveLeftCommand(this, linkSprite);
            //moveRightCommand = new LinkMoveRightCommand(this, linkSprite);
            //moveDownCommand = new LinkMoveDownCommand(this, linkSprite);
            //moveUpCommand = new LinkMoveUpCommand(this, linkSprite);

            //linkDamageCommand = new LinkDamageCommand(this, linkSprite);
            //linkAttackingCommand = new LinkAttackingCommand(this, linkSprite);
            //linkThrowGreenArrowCommand = new LinkThrowGreenArrowCommand(this, linkSprite);

            //#region Mapping Commands
            //// master commands
            //controllerMapping.Add(Keys.Q, exitCommand);
            //controllerMapping.Add(Keys.R, resetCommand);

            ////player movement
            //controllerMapping.Add(Keys.W, moveUpCommand);
            //controllerMapping.Add(Keys.S, moveDownCommand);
            //controllerMapping.Add(Keys.A, moveLeftCommand);
            //controllerMapping.Add(Keys.D, moveRightCommand);
            //controllerMapping.Add(Keys.Up, moveUpCommand);
            //controllerMapping.Add(Keys.Down, moveDownCommand);
            //controllerMapping.Add(Keys.Left, moveLeftCommand);
            //controllerMapping.Add(Keys.Right, moveRightCommand);

            //controllerMapping.Add(Keys.E, linkDamageCommand);
            //controllerMapping.Add(Keys.Z, linkAttackingCommand);
            //controllerMapping.Add(Keys.N, linkAttackingCommand);
            //controllerMapping.Add(Keys.D1, linkThrowGreenArrowCommand);
            //#endregion

            // draw and update sprites
            linkSprite = new Link(game1);

            dir = 0;
            linkState = 0;//mine
            _spriteBatch = spriteBatch;
        }
        public void Update()
        {
            linkState = 0;

            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                if (controllerMapping.ContainsKey(key))
                    controllerMapping[key].Execute();
            }

            linkSprite.Update(linkState, dir, location);
            linkSprite.Draw(_spriteBatch);
        }

    }
}
