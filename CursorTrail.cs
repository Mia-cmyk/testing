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
    class CursorTrail
    {
        public Texture2D texture;
        public float scale;
        List<Vector2> listCursorTrail;

        public CursorTrail(Texture2D _texture) 
        {
            texture = _texture;
        }

        public void Init()
        {
            listCursorTrail = new List<Vector2>();
        }
        public void Update()
        {
            listCursorTrail.Add(new Vector2(Mouse.GetState().X, Mouse.GetState().Y));

            if (listCursorTrail.Count >= 80)
            {
                listCursorTrail.Remove(listCursorTrail[0]);
            }
        }

        public void Draw(SpriteBatch sp)
        {
            Vector2 followOrigin = new Vector2(texture.Bounds.Center.X, texture.Bounds.Center.Y);
            foreach (var pos in listCursorTrail)
            {
                sp.Draw(texture, pos, null, Color.White, 0, followOrigin, scale, 0, 0);
            }
        }
    }
}
