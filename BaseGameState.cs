using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter04
{
    internal class BaseGameState
    {
        private readonly List<BaseGameObject> gameObjects = new List<BaseGameObject>();

        // Interface for loading content
        public abstract void LoadContent(ContentManager contentManager);
        // Interface for unloading content
        public abstract void UnloadContent(ContentManager contentManager);
        // State spefic input handling
        public abstract void HandleInput();
        //

        public event EventHandler<BaseGameState> OnStateSwitched;
        protected void SwitchState(BaseGameState newGameState)
        {
            OnStateSwitched?.Invoke(this, newGameState);
        }
        protected void AddGameObject(BaseGameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }
        public void Render(SpriteBatch spriteBatch)
        {
            foreach (var gameObject in gameObjects.OrderBy(a => a.zIndex))
            {
                gameObject.Render(spriteBatch);
            }
        }
    }
}
