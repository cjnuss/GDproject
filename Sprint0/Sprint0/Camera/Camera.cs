using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    // DEBUG: MAGIC NUMBERS!
    public class Camera
    {
        public Vector2 Position { get; set; }
        public float Zoom { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Camera(int width, int height)
        {
            Width = width;
            Height = height;
            Zoom = 1f;
        }

        public void MoveLeft(float distance)
        {
            Position += new Vector2(distance, 0f);
        }

        public void MoveRight(float distance)
        {
            Position -= new Vector2(distance, 0f);
        }

        public void MoveUp(float distance)
        {
            Position -= new Vector2(0f, distance);
        }

        public void MoveDown(float distance)
        {
            Position += new Vector2(0f, distance);
        }

        public Matrix GetViewMatrix()
        {
            return Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0f)) * Matrix.CreateScale(Zoom) * Matrix.CreateTranslation(new Vector3(Width / 2f, Height / 2f, 0f));
        }
    }
}
