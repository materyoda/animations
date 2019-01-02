using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace animations
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private FrameCounter _frameCounter = new FrameCounter();
        private Camera camera = new Camera();
        private int frame = 0;
        private GraphicsDeviceManager graphics;
        private KeyboardState kbState;
        private SpriteBatch spriteBatch;
        private SpriteAnimation turk;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 780;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _frameCounter.Update(deltaTime);
            var fps = string.Format("FPS: {0}", _frameCounter.AverageFramesPerSecond);

            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            //spriteBatch.Begin(SpriteSortMode.BackToFront,
            //            BlendState.AlphaBlend,
            //                        null,
            //                        null,
            //                        null,
            //                        null,
            //                        camera.get_transformation(GraphicsDevice));
            spriteBatch.Begin();
            turk.Draw(spriteBatch);
            spriteBatch.DrawString(Content.Load<SpriteFont>("Font/Font1"), fps, new Vector2(1, 1), Color.Black);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            turk = new SpriteAnimation(Content.Load<Texture2D>("guy"), 4, 4);
            turk.position = new Vector2(100, 100);

            AnimationClass ani = new AnimationClass();

            turk.AddAnimation("Right", 1, 4, ani.Copy());

            //ani.rotation = MathHelper.PiOver2;
            turk.AddAnimation("Left", 2, 4, ani.Copy());

            //ani.rotation = MathHelper.PiOver2;
            turk.AddAnimation("Up", 3, 4, ani.Copy());

            //ani.rotation = MathHelper.PiOver2;
            turk.AddAnimation("Down", 4, 4, ani.Copy());

            turk.framePerSecond = 1;
            camera.position = new Vector2(200.0f, 200.0f);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            KeyboardState prevKbState = kbState;
            kbState = Keyboard.GetState();

            if (kbState.IsKeyDown(Keys.Left))
            {
                turk.Animation = "Left";
                turk.position.X -= 2;
            }
            else if (kbState.IsKeyDown(Keys.Right))
            {
                turk.Animation = "Right";
                turk.position.X += 2;
            }
            else
            {
                turk.Animation = "Right";
            }

            turk.Update(gameTime);
            base.Update(gameTime);
        }
    }
}