using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using Microsoft.Xna.Framework.Input;

namespace MouseMobile
{
    public class ModEntry : Mod
    {
        private bool mouseMode = true;
        private int lastScroll = 0;

        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.UpdateTicked += OnUpdate;
        }

        private void OnUpdate(object sender, UpdateTickedEventArgs e)
        {
            if (!Context.IsWorldReady || !mouseMode)
                return;

            MouseState mouse = Mouse.GetState();
            KeyboardState keyboard = Keyboard.GetState();
            GamePadState gamepad = GamePad.GetState(PlayerIndex.One);

            // Left click = Use tool
            if (mouse.LeftButton == ButtonState.Pressed)
            {
                Game1.pressUseToolButton(keyboard, mouse, gamepad);
            }

            // Right click = Action
            if (mouse.RightButton == ButtonState.Pressed)
            {
                Game1.pressActionButton(keyboard, mouse, gamepad);
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
