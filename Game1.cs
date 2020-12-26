using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OmnuiTesting
{
 
    public class Game1 : Game
    {
        BG background;
        private float initSize = 2;
        Cursor cursor;
        CursorTrail cursorTrail;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            IsFixedTimeStep = false;
            graphics.IsFullScreen = true;
            graphics.SynchronizeWithVerticalRetrace = false;
            
        }

        protected override void Initialize()
        {
            base.Initialize();
            cursorTrail.Init();

        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            background = new BG(Content.Load<Texture2D>("menu-background"))
            {
                //lower here is actually faster so be careful!
                parallaxVelo = 150,
                pictureScaleWidth = graphics.PreferredBackBufferWidth * 2,
                pictureScaleHeight = graphics.PreferredBackBufferHeight * 2,
                imageScale = .5f
            };

            cursor = new Cursor(Content.Load<Texture2D>("cursor"))
            {
                scale = initSize
            };

            cursorTrail = new CursorTrail(Content.Load<Texture2D>("cursortrail"))
            {
                scale = initSize / 2
            };
        }

        protected override void UnloadContent()
        {
        }
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            cursor.Update();
            cursorTrail.Update();
            background.Update();

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            background.Draw(spriteBatch);
            cursorTrail.Draw(spriteBatch);
            cursor.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
