using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Link_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Sprint0
{
    #region Exit/Reset Commands
    public class ExitCommand : ICommand
    {
        private Game1 game;
        public ExitCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute(GameTime gameTime)
        {
            game.Exit();
        }
    }

    public class ResetCommand : ICommand
    {

        private KeyBoardController KeyBoardController;
        private Link link;
        private Game1 game1;

        public ResetCommand(KeyBoardController KeyBoardController, Link link, Game1 game1)
        {
            this.game1 = game1;
            this.KeyBoardController = KeyBoardController;
            this.link = link;
        }

        public void Execute(GameTime gameTime)
        {

            //mine
            KeyBoardController.linkState = 0;
            KeyBoardController.dir = 0;
            KeyBoardController.linkSprite.location = new Vector2(200, 100); // debug: initial location
            KeyBoardController.linkSprite = new Link(game1);
        }
    }
    #endregion

    #region Link Movement
    public class LinkMoveLeftCommand : ICommand
    {
        private Link link;
        private LinkMoving linkMoving;
        private KeyBoardController KeyBoardController;
        private float linkVelocity;

        public LinkMoveLeftCommand(KeyBoardController KeyBoardController, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkMoving = new LinkMoving();
            linkVelocity = 100f;
        }

        public void Execute(GameTime gameTime)
        {
            KeyBoardController.dir = 1;
            KeyBoardController.linkState = 1; // moving sprite
            KeyBoardController.linkSprite.location.X -= linkVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds; // update with speed later     
        }
    }

    public class LinkMoveRightCommand : ICommand
    {
        private Link link;
        private LinkMoving linkMoving;
        private KeyBoardController KeyBoardController;
        private float linkVelocity;

        public LinkMoveRightCommand(KeyBoardController KeyBoardController, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkMoving = new LinkMoving();
            linkVelocity = 100f;
        }

        public void Execute(GameTime gameTime)
        {
            KeyBoardController.dir = 2;
            KeyBoardController.linkState = 1; // moving sprite
            KeyBoardController.linkSprite.location.X += linkVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }

    public class LinkMoveUpCommand : ICommand
    {
        private Link link;
        private LinkMoving linkMoving;
        private KeyBoardController KeyBoardController;
        private float linkVelocity;

        public LinkMoveUpCommand(KeyBoardController KeyBoardController, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkMoving = new LinkMoving();
            linkVelocity = 100f;
        }

        public void Execute(GameTime gameTime)
        {
            KeyBoardController.dir = 3;
            KeyBoardController.linkState = 1; // moving sprite
            KeyBoardController.linkSprite.location.Y -= linkVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }

    public class LinkMoveDownCommand : ICommand
    {
        private Link link;
        private LinkMoving linkMoving;
        private KeyBoardController KeyBoardController;
        private float linkVelocity;

        public LinkMoveDownCommand(KeyBoardController KeyBoardController, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkMoving = new LinkMoving();
            linkVelocity = 100f;
        }

        public void Execute(GameTime gameTime)
        {
            KeyBoardController.dir = 0;
            KeyBoardController.linkState = 1; // moving sprite
            KeyBoardController.linkSprite.location.Y += linkVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
    #endregion

    // link taking damage
    public class LinkDamageCommand : ICommand
    {
        private Link link;
        private LinkDamaged linkDamaged;
        private KeyBoardController KeyBoardController;

        public LinkDamageCommand(KeyBoardController KeyBoardController, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkDamaged = new LinkDamaged();
        }

        public void Execute(GameTime gameTime)
        {
            // no direction change necessary
            KeyBoardController.linkState = 2; // non-moving sprite
        }
    }

    // sword attack
    public class LinkAttackingCommand : ICommand
    {
        private Link link;
        private LinkAttacking linkAttacking;
        private KeyBoardController KeyBoardController;

        public LinkAttackingCommand(KeyBoardController KeyBoardController, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkAttacking = new LinkAttacking();
        }

        public void Execute(GameTime gameTime)
        {
            KeyBoardController.linkState = 3; // attacking sprites
        }
    }

    #region Link Throwing Items
    // throw green arrow
    public class LinkThrowGreenArrowCommand : ICommand
    {
        private Link link;
        private LinkThrowing linkThrowing;
        private KeyBoardController KeyBoardController;

        public LinkThrowGreenArrowCommand(KeyBoardController KeyBoardController, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkThrowing = new LinkThrowing();
        }

        public void Execute(GameTime gameTime)
        {
            KeyBoardController.linkState = 4;
            KeyBoardController.location = KeyBoardController.linkSprite.location;
        }
    }

    // throw fire
    public class LinkThrowFireCommand : ICommand
    {
        private Link link;
        private LinkThrowing linkThrowing;
        private KeyBoardController KeyBoardController;

        public LinkThrowFireCommand(KeyBoardController KeyBoardController, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkThrowing = new LinkThrowing();
        }

        public void Execute(GameTime gameTime)
        {
            KeyBoardController.linkState = 5;
            KeyBoardController.location = KeyBoardController.linkSprite.location;
        }
    }

    public class LinkThrowBombCommand : ICommand
    {
        private Link link;
        private LinkThrowing linkThrowing;
        private KeyBoardController KeyBoardController;

        public LinkThrowBombCommand(KeyBoardController KeyBoardController, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            linkThrowing = new LinkThrowing();
        }

        public void Execute(GameTime gameTime)
        {
            KeyBoardController.linkState = 6;
            KeyBoardController.location = KeyBoardController.linkSprite.location;
        }
        #endregion
    }
}
