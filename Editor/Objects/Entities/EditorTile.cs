﻿using CoreGame.Objects;
using Microsoft.Xna.Framework;
using CoreGame.Managers;
using Microsoft.Xna.Framework.Graphics;

namespace Editor.Objects
{
    class EditorTile : Tile
    {
        public bool drawId;

        private Camera cam;
        private SpriteFont font;

        public EditorTile(int id, ref Camera cam) : base(id)
        {
            this.cam = cam;
            ResourceManager.Instance.Fonts.TryGetValue("FontSmall", out font);
        }

        public void Update(GameTime gameTime, Tile previewTile)
        {
            if (BoundingBox.Contains(InputManager.Instance.getMouseWorldPos(cam.GetViewMatrix())) && InputManager.Instance.mouseIsPressed(MouseButton.Left))
            {
                this.Id = previewTile.Id;
                this.Initialize();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            if (drawId)
            {
                spriteBatch.DrawString(font, Id.ToString(), Position, Color.Blue);
            }
        }

    }
}