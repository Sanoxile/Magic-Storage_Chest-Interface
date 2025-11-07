using MagicStorage.UI.States;
using Microsoft.Xna.Framework;
using Terraria.GameContent.UI.Elements;

namespace ChestInterface.Contents.UI
{
    public class ChestInterfacePage : BaseStorageUIPage
    {
        private UIText text;

        public ChestInterfacePage(BaseStorageUI parent) : base(parent, "Main") { }

        public override void OnInitialize()
        {
            text = new UIText("Hello from Custom Magic Storage UI!");
            text.Top.Set(20f, 0f);
            text.Left.Set(20f, 0f);
            Append(text);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            // You can update elements here (like item slots)
        }
    }
}