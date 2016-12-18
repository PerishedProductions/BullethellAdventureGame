using System.Collections.Generic;
using CoreGame.Utilities;
using LitJson;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace CoreGame.UI
{
    public class UICanvas
    {
        public string name;
        public List<UIElement> uiElements = new List<UIElement>();

        ContentManager content;

        public virtual void Initialize()
        {
            for (int i = 0; i < uiElements.Count; i++)
            {
                uiElements[i].Initialize();
            }
        }

        public virtual void LoadContent(ContentManager content)
        {
            this.content = content;
            ReadJson jsonReader = new ReadJson();
            JsonData data = jsonReader.ReadData("Data/UI/Hud.json");
            LoadUIFromJson(data);
            for (int i = 0; i < uiElements.Count; i++)
            {
                uiElements[i].LoadContent(content);
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            for (int i = 0; i < uiElements.Count; i++)
            {
                uiElements[i].Update(gameTime);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
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

        public void LoadUIFromJson(JsonData data)
        {
            name = data["Name"].ToString();
            Debug.WriteLine(data["Elements"].Count.ToString());
            for (int i = 0; i < (int)data["Elements"].Count; i++)
            {
                switch (data["Elements"]["Element" + i]["Type"].ToString())
                {
                    case "UIText":
                        CreateUIElement(new UIText(new Vector2((int)data["Elements"]["Element" + i]["Position"][0], (int)data["Elements"]["Element" + i]["Position"][1]), data["Elements"]["Element" + i]["String"].ToString()));
                        break;
                    case "UIButton":
                        Debug.WriteLine("UIButton");
                        CreateUIElement(new UIButton(data["Elements"]["Element" + i]["String"].ToString(), new Rectangle((int)data["Elements"]["Element" + i]["Position"][0], (int)data["Elements"]["Element" + i]["Position"][1], (int)data["Elements"]["Element" + i]["Size"][0], (int)data["Elements"]["Element" + i]["Size"][1]), new Vector2(10, 5)));
                        break;
                    case "UIPanel":
                        UIPanel temp = (UIPanel)CreateUIElement(new UIPanel(new Rectangle((int)data["Elements"]["Element" + i]["Position"][0], (int)data["Elements"]["Element" + i]["Position"][1], (int)data["Elements"]["Element" + i]["Size"][0], (int)data["Elements"]["Element" + i]["Size"][1])));
                        //TODO: Add items inside panels
                        break;
                }
            }
        }

    }
}
