
using CoreGame.UI;

namespace CoreGame.Managers
{
    public class UIManager
    {

        public static UIManager Instance { get; } = new UIManager();

        private UIManager() { }

        public UICanvas currentCanvas;

        /// <summary>
        /// Changes out the current canvas for a new one
        /// </summary>
        /// <param name="canvas">The canvas we want to change to</param>
        public void ChangeCanvas(UICanvas canvas)
        {
            currentCanvas = canvas;
            if (canvas != null)
            {
                currentCanvas.Initialize();
                currentCanvas.LoadContent();
            }
        }

    }
}
