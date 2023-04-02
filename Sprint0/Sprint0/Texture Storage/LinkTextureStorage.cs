using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
	public class LinkTextureStorage : ISpriteFactory
	{
		private static LinkTextureStorage instance = null;
		public static LinkTextureStorage Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new LinkTextureStorage();
				}
				return instance;
			}
		}

		private static Texture2D linkTextures = null;
        private static Texture2D upsideDownTextures = null;

		public void Load(ContentManager content)
		{
			linkTextures = content.Load<Texture2D>("linksprites");
            upsideDownTextures = content.Load<Texture2D>("upsidedownlinksprites");
        }

		public Texture2D GetLinkTextures()
		{
			return linkTextures;
		}

        public Texture2D GetUpsideDown()
        {
            return upsideDownTextures;
        }

        #region Link Looking
        public static Rectangle LinkLookingDown = new Rectangle(1, 11, 16, 16);
		public static Rectangle LinkLookingLeft = new Rectangle(691, 11, 16, 16);
		public static Rectangle LinkLookingRight = new Rectangle(35, 11, 16, 16);
		public static Rectangle LinkLookingUp = new Rectangle(69, 11, 16, 16);
        #endregion

        #region Link Moving
		public static Rectangle LinkMovingDown = new Rectangle(18, 11, 16, 16);
        public static Rectangle LinkMovingDown1 = new Rectangle(1, 11, 16, 16);
        public static Rectangle LinkMovingLeft = new Rectangle(674, 11, 16, 16);
        public static Rectangle LinkMovingLeft1 = new Rectangle(691, 11, 16, 16);
        public static Rectangle LinkMovingRight = new Rectangle(35, 11, 16, 16);
        public static Rectangle LinkMovingRight1 = new Rectangle(52, 11, 16, 16);
        public static Rectangle LinkMovingUp = new Rectangle(69, 11, 16, 16);
        public static Rectangle LinkMovingUp1 = new Rectangle(86, 11, 16, 16);
        #endregion

        #region Link Damaged
		public static Rectangle LinkTakingDamage = new Rectangle(35, 232, 16, 16);
        public static Rectangle LinkTakingDamage1 = new Rectangle(18, 232, 16, 16);
        public static Rectangle LinkTakingDamage2 = new Rectangle(1, 232, 16, 16);
        #endregion

        #region Link Sword Attack
        public static Rectangle LinkAttackingDown = new Rectangle(1, 47, 16, 16);
        public static Rectangle LinkAttackingDown1 = new Rectangle(18, 47, 16, 27);
        public static Rectangle LinkAttackingDown2 = new Rectangle(35, 47, 16, 23);
        public static Rectangle LinkAttackingDown3 = new Rectangle(52, 47, 16, 19);
        public static Rectangle LinkAttackingLeft = new Rectangle(725, 77, 16, 16);
        public static Rectangle LinkAttackingLeft1 = new Rectangle(697, 77, 27, 17);
        public static Rectangle LinkAttackingLeft2 = new Rectangle(673, 77, 23, 17);
        public static Rectangle LinkAttackingLeft3 = new Rectangle(653, 77, 19, 17);
        public static Rectangle LinkAttackingRight = new Rectangle(1, 77, 16, 16);
        public static Rectangle LinkAttackingRight1 = new Rectangle(18, 77, 27, 17);
        public static Rectangle LinkAttackingRight2 = new Rectangle(46, 77, 23, 17);
        public static Rectangle LinkAttackingRight3 = new Rectangle(70, 77, 19, 17);
        public static Rectangle LinkAttackingUp = new Rectangle(1, 109, 16, 16);
        public static Rectangle LinkAttackingUp1 = new Rectangle(18, 97, 16, 28);
        public static Rectangle LinkAttackingUp2 = new Rectangle(35, 98, 16, 27);
        public static Rectangle LinkAttackingUp3 = new Rectangle(52, 106, 16, 19);
        #endregion

        #region Link Throwing
        public static Rectangle LinkThrowDown = new Rectangle(107, 11, 16, 16);
        public static Rectangle LinkThrowLeft = new Rectangle(603, 11, 16, 16);
        public static Rectangle LinkThrowRight = new Rectangle(124, 11, 16, 16);
        public static Rectangle LinkThrowUp = new Rectangle(141, 11, 16, 16);
        #endregion

        #region Link Green Arrow
        public static Rectangle LinkGreenArrowDown = new Rectangle(734, 185, 5, 16);
        public static Rectangle LinkGreenArrowDown1 = new Rectangle(53, 189, 8, 8);
        public static Rectangle LinkGreenArrowDown2 = new Rectangle(0, 0, 0, 0);
        public static Rectangle LinkGreenArrowLeft = new Rectangle(716, 185, 16, 16);
        public static Rectangle LinkGreenArrowLeft1 = new Rectangle(53, 189, 8, 8);
        public static Rectangle LinkGreenArrowLeft2 = new Rectangle(0, 0, 0, 0);
        public static Rectangle LinkGreenArrowRight = new Rectangle(10, 185, 16, 16);
        public static Rectangle LinkGreenArrowRight1 = new Rectangle(53, 189, 8, 8);
        public static Rectangle LinkGreenArrowRight2 = new Rectangle(0, 0, 0, 0);
        public static Rectangle LinkGreenArrowUp = new Rectangle(3, 185, 5, 16);
        public static Rectangle LinkGreenArrowUp1 = new Rectangle(53, 189, 8, 8);
        public static Rectangle LinkGreenArrowUp2 = new Rectangle(0, 0, 0, 0);
        #endregion

        #region Link Fire Attack
        public static Rectangle LinkFire1 = new Rectangle(191, 185, 16, 16);
        public static Rectangle LinkFire2 = new Rectangle(535, 185, 16, 16);
        #endregion

        #region Link Bomb Attack
        public static Rectangle LinkBomb = new Rectangle(129, 185, 8, 14);
        public static Rectangle LinkBombExplode = new Rectangle(138, 185, 16, 16);
        public static Rectangle LinkBombExplode1 = new Rectangle(155, 185, 16, 16);
        public static Rectangle LinkBombExplode2 = new Rectangle(174, 187, 14, 14);
        #endregion

        #region Link Blue Arrow
        public static Rectangle LinkBlueArrowDown = new Rectangle(29, 109, 5, 16); // upside down
        public static Rectangle LinkBlueArrowDown1 = new Rectangle(53, 113, 8, 8); // poof
        public static Rectangle LinkBlueArrowDown2 = new Rectangle(0, 0, 0, 0);
        public static Rectangle LinkBlueArrowLeft = new Rectangle(690, 190, 16, 5);
        public static Rectangle LinkBlueArrowLeft1 = new Rectangle(53, 189, 8, 8);
        public static Rectangle LinkBlueArrowLeft2 = new Rectangle(0, 0, 0, 0);
        public static Rectangle LinkBlueArrowRight = new Rectangle(36, 190, 16, 5);
        public static Rectangle LinkBlueArrowRight1 = new Rectangle(53, 189, 8, 8);
        public static Rectangle LinkBlueArrowRight2 = new Rectangle(0, 0, 0, 04);
        public static Rectangle LinkBlueArrowUp = new Rectangle(29, 185, 5, 16);
        public static Rectangle LinkBlueArrowUp1 = new Rectangle(53, 189, 8, 8);
        public static Rectangle LinkBlueArrowUp2 = new Rectangle(0, 0, 0, 0);
        #endregion

        #region Link Sword Beam
        public static Rectangle LinkSwordBeamDown = new Rectangle(36, 140, 7, 16); // upside down sheet
        public static Rectangle LinkSwordBeamLeft = new Rectangle(681, 159, 16, 7);
        public static Rectangle LinkSwordBeamRight = new Rectangle(45, 159, 16, 7);
        public static Rectangle LinkSwordBeamUp = new Rectangle(36, 154, 7, 16);

        // DEBUG: sword beam should be color of background when flashing? NES playthrough
        public static Rectangle LinkSwordBeamFlashing = new Rectangle(0, 0, 0, 0); // DEBUG: flashing?

        public static Rectangle LinkSwordBeamExplode = new Rectangle(62, 157, 8, 10); // NORM: top left
        public static Rectangle LinkSwordBeamExplode1 = new Rectangle(672, 157, 8, 10); // NORM: top right
        public static Rectangle LinkSwordBeamExplode2 = new Rectangle(62, 143, 8, 10); // FLIP: bottom left
        public static Rectangle LinkSwordBeamExplode3 = new Rectangle(672, 143, 8, 10); // FLIP: bottom right
        #endregion
    }
}