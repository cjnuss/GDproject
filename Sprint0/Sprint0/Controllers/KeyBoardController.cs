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
using Sprint0.UI;
using Microsoft.Xna.Framework.Content;

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

        public KeyBoardController(Game1 game1, SpriteBatch spriteBatch, Link linkSprite)
        {
            this.game1 = game1;
            this.linkSprite = linkSprite;

            controllerMapping = new Dictionary<Keys, ICommand>();
            mappingCommands = new MapCommands(this, controllerMapping, game1, linkSprite);
            mappingCommands.CreateCommands();
            controllerMapping = mappingCommands.GetControllerMapping(controllerMapping);

            dir = GameConstants.Down; linkState = LinkConstants.Default;
            _spriteBatch = spriteBatch;
        }

        public void Update(GameTime gameTime)
        {
            linkState = LinkConstants.Default; // reset link state

            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            if (pressedKeys.Length != GameConstants.Zero && controllerMapping.ContainsKey(pressedKeys[GameConstants.Zero]))
                controllerMapping[pressedKeys[GameConstants.Zero]].Execute(gameTime);

            // DEBUG: factor out link into Game1.cs?
            linkSprite.Update(linkState, dir, location);
            linkSprite.Draw(_spriteBatch);
        }

    }
}
