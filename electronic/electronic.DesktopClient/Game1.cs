using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace electronic.DesktopClient
{
    public class Game1 : Game
    {
        Texture2D resTexture;
        Vector2 resPosition;
        float resSpeed;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            resPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            resSpeed = 100f;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            resTexture = Content.Load<Texture2D>("res");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up))
                resPosition.Y -= resSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Down))
                resPosition.Y += resSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Left))
                resPosition.X -= resSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Right))
                resPosition.X += resSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkRed);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(
                    resTexture,
                    resPosition,
                    null,
                    Color.White,
                    0f,
                    new Vector2(resTexture.Width / 2, resTexture.Height / 2),
                    Vector2.One,
                    SpriteEffects.None,
                    0f
                );
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
