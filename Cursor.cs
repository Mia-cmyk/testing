using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmnuiTesting
{
    class Cursor 
    {
        public Texture2D texture;
        private Vector2 Position;
        public float scale;
        private float scaleMultiplier;

        public Cursor(Texture2D _texture)
        {
            texture = _texture;
        }

        public void Update()
        {
            Position = new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y);

            if (Keyboard.GetState().IsKeyDown(Keys.K) || Keyboard.GetState().IsKeyDown(Keys.OemPeriod))
            {
                scaleMultiplier = scale + scale / 10;
            }
            else
            {
                scaleMultiplier = scale;
            }
        }

        public void Draw(SpriteBatch sp)
        {
            Vector2 Origin = new Vector2(texture.Bounds.Center.X, texture.Bounds.Center.Y);
            sp.Draw(texture, Position, null, Color.White, 0, Origin, scaleMultiplier, 0, 0);
        }
    }
}
