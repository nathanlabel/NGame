using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NGame.Source;
using NGame.Source.GUI;

namespace NGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        SceneManager sceneManager;

        public Game1()
        {
            Globals.graphicsDevice = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            sceneManager = new SceneManager();
            Globals.Content = this.Content;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);

            sceneManager.AddScene(new Scene("Test"));
            MenuManager testMainMenu = new MenuManager();
            Menu testBaseMenu = new Menu(new Vector2(50,50));
            Label titleText = new Label("Title Text", new Vector2(50, 50));
            testBaseMenu.AddMenuObject(titleText);
            testMainMenu.AddMenu(testBaseMenu);
            sceneManager.ActiveScene.AddEntity(testMainMenu);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {

            Globals.Update(gameTime);
            sceneManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            Globals.spriteBatch.Begin();

            sceneManager.Draw(gameTime);

            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }
    }

    public class MainGame
    {
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
}
