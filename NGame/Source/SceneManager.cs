using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGame.Source
{
    public class SceneManager : Entity, IUpdate, IDraw
    {
        private Dictionary<String, Scene> _SceneCollection;

        public bool Visible { get; set; } = true;
        public Scene ActiveScene { get; private set; }

        public SceneManager()
        {
            _SceneCollection = new Dictionary<string, Scene>();
        }

        public void AddScene(Scene newScene)
        {
            if (_SceneCollection.Count > 0)
            {
                if (_SceneCollection.ContainsKey(newScene.Name))
                    throw new Exception("_SceneCollection already contains " + newScene.Name);
                else
                    if (_SceneCollection.ContainsValue(newScene))
                        throw new Exception("_SceneCollection already contains this Scene object");
                else
                {
                    _SceneCollection.Add(newScene.Name, newScene);
                    newScene.SetOwner(this);
                }
            }
            else
            {
                _SceneCollection.Add(newScene.Name, newScene);
                ActiveScene = newScene;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (Enabled && _SceneCollection.Count > 0)
            {
                if (ActiveScene != null)
                    ActiveScene.Update(gameTime);
            }
        }
        public void Draw(GameTime gameTime)
        {
            if (Visible && _SceneCollection.Count > 0)
                if (ActiveScene != null)
                    ActiveScene.Draw(gameTime);
        }
    }
}
