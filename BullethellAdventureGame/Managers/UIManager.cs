using System;

using CoreGame.UI;

namespace CoreGame.Managers
{
    public class UIManager
    {

        public static UIManager Instance { get; } = new UIManager();

        private UIManager() { }

        public UICanvas currentCanvas;

        //TODO: Make it able to store multiple canvases

        /// <summary>
        /// Changes out the current canvas for a new one
        /// </summary>
        /// <param name="canvas">The canvas we want to change to</param>
        public void ChangeCanvas(UICanvas canvas)
        {
            currentCanvas = canvas;
            currentCanvas.Initialize();
            currentCanvas.LoadContent();
        }

    }
}
