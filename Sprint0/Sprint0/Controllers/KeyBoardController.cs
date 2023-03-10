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
        

        public KeyBoardController(Game1 game1, SpriteBatch spriteBatch)
        {
            this.game1 = game1;

            linkSprite = new Link(game1);

            controllerMapping = new Dictionary<Keys, ICommand>();
            mappingCommands = new MapCommands(this, controllerMapping, game1, linkSprite);
            mappingCommands.createCommands();
            controllerMapping = mappingCommands.getControllerMapping(controllerMapping);

            

            linkMovementCollision = new LinkMovementCollision(this, linkSprite);

            dir = 0; linkState = 0;
            _spriteBatch = spriteBatch;
        }
        public void Update(GameTime gameTime)
        {
            linkState = 0; // reset link state

            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            Array.Sort(pressedKeys);
            Array.Reverse(pressedKeys);

            if (pressedKeys.Length != 0 && controllerMapping.ContainsKey(pressedKeys[0]))
                controllerMapping[pressedKeys[0]].Execute(gameTime);

            foreach (CollisionBlock block in game1.currentRoom.GetBlocks())
            {
                linkMovementCollision.Update(block);          
            }
            
            linkSprite.Update(linkState, dir, location);
            linkSprite.Draw(_spriteBatch);
        }

    }
}
