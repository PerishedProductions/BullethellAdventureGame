using Microsoft.Xna.Framework;

namespace CoreGame.UI
{
    public class PlayerHudCanvas : UICanvas
    {

        UIText hp;

        public override void LoadContent()
        {
            hp = (UIText)CreateUIElement(new UIText(new Vector2(10, 10), "Health: 100%"), UILayer.Middle);
            base.LoadContent();
        }

    }
}
