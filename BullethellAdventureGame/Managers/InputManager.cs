using Microsoft.Xna.Framework.Input;

namespace CoreGame.Managers
{
    class InputManager
    {

        private static InputManager instance;

        private InputManager() { }

        public static InputManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InputManager();
                }
                return instance;
            }
        }

        KeyboardState oldKeyState;
        KeyboardState newKeyState;

        //MouseState mouseState;

        public void Update()
        {
            oldKeyState = newKeyState;
            newKeyState = Keyboard.GetState();
        }

        public bool isPressed(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (newKeyState.IsKeyDown(key) && oldKeyState.IsKeyUp(key))
                {
                    return true;
                }
            }
            return false;
        }

        public bool isReleased(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (newKeyState.IsKeyUp(key) && oldKeyState.IsKeyDown(key))
                {
                    return true;
                }
            }
            return false;
        }

        public bool isDown(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (newKeyState.IsKeyDown(key))
                {
                    return true;
                }
            }
            return false;
        }

        public bool isUp(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (newKeyState.IsKeyUp(key))
                {
                    return true;
                }
            }
            return false;
        }
    }
}