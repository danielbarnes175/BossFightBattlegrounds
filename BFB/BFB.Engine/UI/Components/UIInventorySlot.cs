using System;
using System.Collections.Generic;
using BFB.Engine.Content;
using BFB.Engine.Event;
using BFB.Engine.Helpers;
using BFB.Engine.Inventory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BFB.Engine.UI.Components
{
    public class UIInventorySlot : UIComponent
    {
        private const int Padding = 10;
        private bool _hover;
        private readonly int _slotId;
        private readonly ClientInventory _inventory;
        
        
        public UIInventorySlot(ClientInventory inventory, int slotId) : base(nameof(UIInventorySlot))
        {
            _inventory = inventory;
            _slotId = slotId;
            _hover = false;

            this.AspectRatio(1)
                .Background(new Color(0,0,0,0.5f))
                .Border(3, Color.Silver)
                .FontSize(0.5f);
            
            AddEvent("hover", e =>
            {
                RenderAttributes = DefaultAttributes.CascadeAttributes(new UIAttributes
                {
                    Background = new Color(0,0,0,0.2f)
                });
            });
            AddEvent("mouseenter", e => _hover = true);
            AddEvent("mouseleave", e => _hover = false);
        }
        
        #region Render
        
        public override void Render(SpriteBatch graphics, BFBContentManager content)
        {
            base.Render(graphics, content);

            Dictionary<int, InventorySlot> slots = _inventory.GetSlots();
            if (slots.ContainsKey(_slotId))
            {
                InventorySlot slot = slots[_slotId];
                
                int padding = Padding;
                if (_hover)
                    padding -= 3;

                //Draw item
                graphics.DrawAtlas(
                    content.GetAtlasTexture(slot.TextureKey),
                    new Rectangle(
                        RenderAttributes.X + padding, 
                        RenderAttributes.Y + padding, 
                        RenderAttributes.Width - padding*2, 
                        RenderAttributes.Height - padding*2), 
                    Color.White);

                //draw count
                if (slot.Count <= 1) 
                    return;
                
                SpriteFont font = content.GetFont(RenderAttributes.FontKey);
                graphics.DrawString(
                    font,
                    slot.Count.ToString(),
                    new Vector2(
                        RenderAttributes.X + padding,
                        RenderAttributes.Y + padding ),
                    Color.White,
                    0,
                    Vector2.Zero,
                    RenderAttributes.FontSize * (graphics.GraphicsDevice.Viewport.Width/25f)/font.MeasureString(" ").Y,
                    SpriteEffects.None,
                    1);
            }
        }
        
        #endregion
    }
}