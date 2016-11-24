
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace CoreGame.Managers
{
    public class Camera
    {

        private readonly Viewport viewport;

        public Camera(Viewport viewport)
        {
            this.viewport = viewport;

            rotation = 0;
            zoom = 2f;
            origin = new Vector2(viewport.Width / 2, viewport.Height / 2);
            position = Vector2.Zero;
        }

        public Vector2 position { get; set; }
        public float rotation { get; set; }
        public float zoom { get; set; }
        public Vector2 origin { get; set; }

        public Matrix GetViewMatrix()
        {
            return
                Matrix.CreateTranslation(new Vector3(-position, 0.0f)) *
                Matrix.CreateTranslation(new Vector3(-origin, 0.0f)) *
                Matrix.CreateRotationZ(rotation) *
                Matrix.CreateScale(zoom, zoom, 1) *
                Matrix.CreateTranslation(new Vector3(origin, 0.0f));
        }

        public void LookAt(Vector2 position)
        {
            this.position = position - new Vector2(viewport.Width / 2f, viewport.Height / 2f);
        }
    }
}
