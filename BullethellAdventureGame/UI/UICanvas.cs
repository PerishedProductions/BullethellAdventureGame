using System.Collections.Generic;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace CoreGame.UI
{
    public class UICanvas
    {

        public List<UIElement> uiElements = new List<UIElement>();

        ContentManager content;

        public void Initialize()
        {
            for (int i = 0; i < uiElements.Count; i++)
            {
                uiElements[i].Initialize();
            }
        }

        public void LoadContent(ContentManager content)
        {
            this.content = content;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < uiElements.Count; i++)
            {
                uiElements[i].Draw(spriteBatch);
            }
        }

        public UIElement CreateUIElement(UIElement element)
        {
            uiElements.Add(element);
            element.Initialize();
            element.LoadContent(content);
            return element;
        }

    }
}
