using System;

using CoreGame.UI;

namespace CoreGame.Managers
{
    public class UIManager
    {

        public static UIManager Instance { get; } = new UIManager();

        private UIManager() { }

        public UICanvas currentCanvas;

        public void ChangeCanvas(UICanvas canvas)
        {
            currentCanvas = canvas;
            currentCanvas.Initialize();
            currentCanvas.LoadContent();
        }

    }
}
