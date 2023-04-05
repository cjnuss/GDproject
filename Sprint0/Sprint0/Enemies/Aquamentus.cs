using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0;

namespace Sprint0
{
    public class Aquamentus : ISprite
    {
        public int totalFrames = AquamentusConstants.TotalFrames;
        public int textureFrame1 = AquamentusConstants.TextureFrames;
        public Vector2 location;
        public int frame, currentFrame, textureFrame, random, projectileCount;
        public bool projectile;
        private ISprite projectileSprite;
        public System.Random RNG = new System.Random();

        private static List<Rectangle> frames = new List<Rectangle>
        {
            EnemyTextureStorage.Aquamentus1,
            EnemyTextureStorage.Aquamentus2,
            EnemyTextureStorage.Aquamentus3,
            EnemyTextureStorage.Aquamentus4,
        };

        public Aquamentus(Vector2 coords)
        {
            currentFrame = GameConstants.Zero;
            textureFrame = GameConstants.Zero;
            projectileCount = GameConstants.Zero;
            location = coords;
            random = AquamentusConstants.InitialRandom;
            projectile = true;
        }

        public void Update()
        {
            if (projectileCount == GameConstants.Zero)
            {
                projectileSprite = new AquamentusProjectile(location);
            }
            projectileCount++;
            textureFrame++;
            currentFrame++;
            if (textureFrame == textureFrame1)
            {
                textureFrame = GameConstants.Zero;
            }
            if (currentFrame == totalFrames)
            {
                currentFrame = GameConstants.Zero;
                random = RNG.Next(AquamentusConstants.NextRandom1, AquamentusConstants.NextRandom2);
                totalFrames = RNG.Next(AquamentusConstants.NextRandomFrame1, AquamentusConstants.NextRandomFrame2);
            }
            if (currentFrame % GameConstants.Ten == GameConstants.Zero)
            {
                switch (random)
                {
                    case AquamentusConstants.Case1:
                        location.X -= AquamentusConstants.PosChange;
                        break;
                    case AquamentusConstants.Case2:
                        location.X += AquamentusConstants.PosChange;
                        break;
                }
            }
            if (projectileCount == AquamentusConstants.MaxProjectile)
            {
                projectileCount = GameConstants.Zero;
            }
            projectileSprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (textureFrame < AquamentusConstants.Phase1)
                frame = GameConstants.Frame0;
            else if (textureFrame >= AquamentusConstants.Phase1 && textureFrame < AquamentusConstants.Phase2)
                frame = GameConstants.Frame1;
            else if (textureFrame >= AquamentusConstants.Phase2 && textureFrame < AquamentusConstants.Phase3)
                frame = GameConstants.Frame2;
            else if (textureFrame >= totalFrames)
                frame = GameConstants.Frame3;

            Texture2D texture = EnemyTextureStorage.Instance.GetEnemies();
            Rectangle source = frames[frame];
            Rectangle destinaton = new Rectangle((int)location.X, (int)location.Y, source.Width * GameConstants.Sizing, source.Height * GameConstants.Sizing);
            spriteBatch.Draw(texture, destinaton, source, Color.White);
            projectileSprite.Draw(spriteBatch);
        }
    }
}
