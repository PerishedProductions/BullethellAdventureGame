using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CoreGame.Managers
{

    public enum MouseButton { Left, Middle, Right }

    public class InputManager
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

        //Keyboard Inputs
        KeyboardState oldKeyState;
        KeyboardState newKeyState;

        //Controller Inputs
        GamePadState oldControllerState;
        GamePadState newControllerState;

        //Mouse Inputs
        MouseState mouseState;
        MouseState oldMouseState;

        /// <summary>
        /// Sets the oldstates of the last update pefore getting the new input
        /// </summary>
        public void Update()
        {
            oldMouseState = mouseState;
            mouseState = Mouse.GetState();

            oldKeyState = newKeyState;
            newKeyState = Keyboard.GetState();

            oldControllerState = newControllerState;
            newControllerState = GamePad.GetState(PlayerIndex.One);
        }

        /// <summary>
        /// Gets The state of the mouse wheel
        /// </summary>
        /// <returns></returns>
        public int getMouseWheelState()
        {
            return mouseState.ScrollWheelValue;
        }

        /// <summary>
        /// Gets the state of the mouse wheel from the last frame
        /// </summary>
        /// <returns></returns>
        public int getOldMouseWheelState()
        {
            return oldMouseState.ScrollWheelValue;
        }

        /// <summary>
        /// Gets the mouse position
        /// </summary>
        /// <returns></returns>
        public Vector2 getMousePos()
        {
            return mouseState.Position.ToVector2();
        }

        /// <summary>
        /// Gets the mouse position according to the camera
        /// </summary>
        /// <param name="viewmatrix">The viewmatrix of the camera we are currently using</param>
        /// <returns></returns>
        public Vector2 getMouseWorldPos(Matrix viewmatrix)
        {
            return Vector2.Transform(mouseState.Position.ToVector2(), Matrix.Invert(viewmatrix));
        }

        /// <summary>
        /// Returns if a mouse specific mouse button was pressed
        /// </summary>
        /// <param name="mouseButton">What button are we going to check</param>
        /// <returns></returns>
        public bool mouseIsPressed(MouseButton mouseButton)
        {
            switch (mouseButton)
            {
                case MouseButton.Left:
                    if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
                    {
                        return true;
                    }
                    break;
                case MouseButton.Middle:
                    if (mouseState.MiddleButton == ButtonState.Pressed && oldMouseState.MiddleButton == ButtonState.Released)
                    {
                        return true;
                    }
                    break;
                case MouseButton.Right:
                    if (mouseState.RightButton == ButtonState.Pressed && oldMouseState.RightButton == ButtonState.Released)
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }

        /// <summary>
        /// Returns if a specific key has been pressed
        /// </summary>
        /// <param name="keys">The keys we want to check</param>
        /// <returns></returns>
        public bool isPressed(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (newKeyState.IsKeyDown(key) && oldKeyState.IsKeyUp(key))
                {
                    oldKeyState = newKeyState;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns if specific keys has been released
        /// </summary>
        /// <param name="keys">The keys we want to check</param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns if specific keys is being held down
        /// </summary>
        /// <param name="keys">The key we want to check</param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns if specific keys is not being held down
        /// </summary>
        /// <param name="keys">The key we want to check</param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns if specific controller button is being pressed
        /// </summary>
        /// <param name="button">The button we want to check</param>
        /// <returns></returns>
        public bool controllerIsPressed(params Buttons[] buttons)
        {
            foreach (Buttons button in buttons)
            {
                if (newControllerState.IsButtonDown(button) && oldControllerState.IsButtonUp(button))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns if specific controller button is being released
        /// </summary>
        /// <param name="button">The button we want to check</param>
        /// <returns></returns>
        public bool controllerIsReleased(params Buttons[] buttons)
        {
            foreach (Buttons button in buttons)
            {
                if (newControllerState.IsButtonUp(button) && oldControllerState.IsButtonDown(button))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns if specific controller button is being held down
        /// </summary>
        /// <param name="button">The button we want to check</param>
        /// <returns></returns>
        public bool controllerIsDown(params Buttons[] buttons)
        {
            foreach (Buttons button in buttons)
            {
                if (newControllerState.IsButtonDown(button))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns if specific controller button is not being held down
        /// </summary>
        /// <param name="button">The button we want to check</param>
        /// <returns></returns>
        public bool controllerIsUp(params Buttons[] buttons)
        {
            foreach (Buttons button in buttons)
            {
                if (newControllerState.IsButtonUp(button))
                {
                    return true;
                }
            }
            return false;
        }

    }
}