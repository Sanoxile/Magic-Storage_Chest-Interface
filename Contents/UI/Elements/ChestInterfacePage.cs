using MagicStorage.UI.States;
using Microsoft.Xna.Framework;
using Terraria.GameContent.UI.Elements;

namespace MagicStorageAddons.Contents.UI.Elements
{
    public class ChestInterfacePage(BaseStorageUI parent) : BaseStorageUIPage(parent, "Bozo")
    {
        private UIText text;

        public override void OnInitialize()
        {
            text = new UIText("Hello from Custom Magic Storage UI!");
            text.Top.Set(4f, 0f);
            text.Left.Set(4f, 0f);
            Append(text);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            // You can update elements here (like item slots)
        }
    }
}