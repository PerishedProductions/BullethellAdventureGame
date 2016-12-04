using System;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CoreGame.UI
{
    public class UIPanel : UIElement
    {
        Rectangle size;

        String textureName;
        Texture2D sprite;

        ContentManager content;

        public List<UIElement> elements = new List<UIElement>();

        public UIPanel(Rectangle size)
        {
            this.size = size;
        }

        public override void Initialize()
        {
            textureName = "Window";
        }

        public override void LoadContent(ContentManager content)
        {
            this.content = content;
            sprite = content.Load<Texture2D>(textureName);
            CreateUIElement(new UIText(new Vector2(11, 11), "Cobo"));
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, size, Color.White);
            for (int i = 0; i < elements.Count; i++)
            {
                elements[i].Draw(spriteBatch);
            }
        }

        public UIElement CreateUIElement(UIElement element)
        {
            elements.Add(element);
            element.Initialize();
            element.LoadContent(content);
            return element;
        }

    }
}
