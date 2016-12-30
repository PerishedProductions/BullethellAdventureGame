﻿#region File Description
//-----------------------------------------------------------------------------
// Buttons are clickable entities you can put content inside and respond with 
// callback when clicked. By default, every button is created with an internal
// paragraph to describe it. If you don't want the internal text just set it to 
// empty string.
// 
// Buttons are very basic UI elements and often used for things like "Save Game", 
// "Load", "Exit", etc..
//
// Note that buttons can also behave like checkboxes with the 'ToggleMode' option.
//
// Author: Ronen Ness.
// Since: 2016.
//-----------------------------------------------------------------------------
#endregion
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GeonBit.UI.DataTypes;

namespace GeonBit.UI.Entities
{
    /// <summary>
    /// Button skins.
    /// </summary>
    public enum ButtonSkin
    {
        /// <summary>The default button skin.</summary>
        Default = 0,
        /// <summary>Alternative button skin.</summary>
        Alternative = 1,
        /// <summary>Fancy button skin.</summary>
        Fancy = 2,
    }


    /// <summary>
    /// A clickable button with label on it.
    /// </summary>
    public class Button : Entity
    {
        // button skin
        ButtonSkin _skin;

        /// <summary>Button label. Use this if you want to change the button text or font style.</summary>
        public Paragraph ButtonParagraph;

        /// <summary>If true, button will behave as a checkbox, meaning when you click on it it will stay pressed and have 'checked' value of true.</summary>
        public bool ToggleMode = false;

        // button value when in toggle mode
        private bool _checked = false;

        /// <summary>Default button size for when no size is provided or when -1 is set for either width or height.</summary>
        override public Vector2 DefaultSize { get { return new Vector2(0f, 70f); } }

        /// <summary>Default styling for the button itself. Note: loaded from UI theme xml file.</summary>
        new public static StyleSheet DefaultStyle = new StyleSheet();

        /// <summary>Default styling for buttons label. Note: loaded from UI theme xml file.</summary>
        public static StyleSheet DefaultParagraphStyle = new StyleSheet();

        /// <summary>Optional custom skin that override's the default theme button textures.</summary>
        private Texture2D[] _customSkin = null;
        
        /// <summary>Frame width for when using custom skin.</summary>
        private Vector2 _customFrame = Vector2.Zero;

        /// <summary>
        /// Create the button.
        /// </summary>
        /// <param name="text">Text for the button label.</param>
        /// <param name="skin">Button skin (texture to use).</param>
        /// <param name="anchor">Position anchor.</param>
        /// <param name="size">Button size (if not defined will use default size).</param>
        /// <param name="offset">Offset from anchor position.</param>
        public Button(string text, ButtonSkin skin = ButtonSkin.Default, Anchor anchor = Anchor.Auto, Vector2? size = null, Vector2? offset = null) :
            base(size, anchor, offset)
        {
            // store style
            _skin = skin;

            // update styles
            UpdateStyle(DefaultStyle);

            // create and set button paragraph
            ButtonParagraph = new Paragraph(text, Anchor.Center);
            ButtonParagraph.UpdateStyle(DefaultParagraphStyle);
            AddChild(ButtonParagraph, true);
        }

        /// <summary>
        /// Override the default theme textures and set a custom skin for this specific button.
        /// </summary>
        /// <remarks>You must provide all state textures when overriding button skin.</remarks>
        /// <param name="defaultTexture">Texture to use for default state.</param>
        /// <param name="mouseHoverTexture">Texture to use when mouse hover over the button.</param>
        /// <param name="mouseDownTexture">Texture to use when mouse button is down over this button.</param>
        /// <param name="frameWidth">The width of the custom texture's frame, in percents of texture size.</param>
        public void SetCustomSkin(Texture2D defaultTexture, Texture2D mouseHoverTexture, Texture2D mouseDownTexture, Vector2? frameWidth = null)
        {
            _customSkin = new Texture2D[3];
            _customSkin[(int)EntityState.Default] = defaultTexture;
            _customSkin[(int)EntityState.MouseHover] = mouseHoverTexture;
            _customSkin[(int)EntityState.MouseDown] = mouseDownTexture;
            _customFrame = frameWidth ?? _customFrame;
        }

        /// <summary>
        /// Set / get current button skin.
        /// </summary>
        public ButtonSkin Skin
        {
            get { return _skin; }
            set { _skin = value; _customSkin = null; }
        }

        /// <summary>
        /// Is the button a natrually-interactable entity.
        /// </summary>
        /// <returns>True.</returns>
        override public bool IsNaturallyInteractable()
        {
            return true;
        }

        /// <summary>
        /// When button is in Toggle mode, this is the current value (it button checked or not).
        /// </summary>
        public bool Checked
        {
            get { return _checked == true; }
            set { _checked = value; DoOnValueChange(); }
        }

        /// <summary>
        /// Handle click events. In button we override this so we can toggle button when in Toggle mode.
        /// </summary>
        /// <param name="input">Input helper instance.</param>
        override protected void DoOnClick(InputHelper input)
        {
            // toggle value
            if (ToggleMode)
            {
                Checked = !Checked;
            }

            // call base handler
            base.DoOnClick(input);
        }

        /// <summary>
        /// Draw the entity.
        /// </summary>
        /// <param name="spriteBatch">Sprite batch to draw on.</param>
        override protected void DrawEntity(SpriteBatch spriteBatch)
        {
            // get mouse state for graphics
            EntityState state = _entityState;
            if (Checked) { state = EntityState.MouseDown; }
           
            // get texture based on skin and state
            Texture2D texture = _customSkin == null ? Resources.ButtonTextures[(int)_skin, (int)state] : _customSkin[(int)state];

            // get frame width
            TextureData data = Resources.ButtonData[(int)_skin];
            Vector2 frameSize = _customSkin == null ? new Vector2(data.FrameWidth, data.FrameHeight) : _customFrame;

            // draw the button background with frame
            if (frameSize.Length() > 0)
            {
                float scale = frameSize.Y > 0 ? Scale : 1f;
                DrawUtils.DrawSurface(spriteBatch, texture, _destRect, frameSize, 1, FillColor, scale);
            }
            // draw the button background without frame (just stretch texture)
            else
            {
                DrawUtils.DrawImage(spriteBatch, texture, _destRect, FillColor, 1);
            }

            // call base draw function
            base.DrawEntity(spriteBatch);
        }
    }
}