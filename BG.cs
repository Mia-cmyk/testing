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
    class BG
    {
        private Vector2 Position;
        private Texture2D texture;
        public int parallaxVelo;
        public int pictureScaleWidth;
        public int pictureScaleHeight;
        public float imageScale;
        private Rectangle startingPos;

         public BG(Texture2D _texture)
        {
            texture = _texture;
        }

        public void Update()
        {
            Position = new Vector2(Mouse.GetState().Position.X / parallaxVelo, Mouse.GetState().Position.Y / parallaxVelo);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            startingPos = new Rectangle(0, 0, 1920 * 3, 1080 * 3);
            Vector2 Origin = new Vector2(-500, -100);
            spriteBatch.Draw(texture, Position, startingPos, Color.White, 0, Origin, imageScale, 0, 0);
        }
    }
}
