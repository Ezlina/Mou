using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using Microsoft.Xna.Framework.Input;

namespace MouseMobile
{
    public class ModEntry : Mod
    {
        private int lastScroll = 0;

        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.UpdateTicked += OnUpdate;
        }

        private void OnUpdate(object sender, UpdateTickedEventArgs e)
        {
            if (!Context.IsWorldReady)
                return;

            MouseState mouse = Mouse.GetState();

            // Left click = use tool
            if (mouse.LeftButton == ButtonState.Pressed)
            {
                Game1.didPlayerJustLeftClick(true);
            }

            // Right click = action
            if (mouse.RightButton == ButtonState.Pressed)
            {
                Game1.didPlayerJustRightClick(true);
            }

            // Scroll wheel = change item
            if (mouse.ScrollWheelValue != lastScroll)
            {
                if (mouse.ScrollWheelValue > lastScroll)
                    Game1.player.CurrentToolIndex++;
                else
                    Game1.player.CurrentToolIndex--;

                lastScroll = mouse.ScrollWheelValue;
            }
        }
    }
}
