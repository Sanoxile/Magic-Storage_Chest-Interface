using Terraria;
using Terraria.ModLoader;
using MagicStorageAddons.Contents.UI;

namespace MagicStorageAddons.Contents
{
    public class MagicStorageAddonsUI : ModSystem
    {
        // Store all addon UIs here
        public static ChestInterfaceUI ChestUI;
        // You can easily add more later
        // public static AnotherCustomUI AnotherUI;

        public override void Load()
        {
            if (Main.dedServ)
                return;

            // Do NOT initialize the UI here yet — the player array isn't ready
        }

        public override void OnWorldLoad()
        {
            if (Main.dedServ)
                return;

            InitializeUIs();
        }

        private static void InitializeUIs()
        {
            // Initialize all UIs here once the world (and players) exist
            ChestUI = new ChestInterfaceUI();
            // AnotherUI = new AnotherCustomUI();
        }

        public override void OnWorldUnload()
        {
            ChestUI = null;
            // AnotherUI = null;
        }

        public override void Unload()
        {
            ChestUI = null;
            // AnotherUI = null;
        }
    }
}
