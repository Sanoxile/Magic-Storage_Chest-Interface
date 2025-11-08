using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using ChestInterface.Contents.UI; // Your custom UI namespace

namespace ChestInterface.Contents.Systems
{
    public class MagicStorageAddonsSystem : ModSystem
    {
        // Core tModLoader UI interface
        public static UserInterface UIInterface;

        // Register all your custom UI states here
        public static ChestInterfaceUI ChestUI;
        // Future UIs you’ll add later:
        // public static FilterUI FilterUI;
        // public static PipeConfigUI PipeUI;

        public override void Load()
        {
            if (Main.dedServ)
                return;

            UIInterface = new UserInterface();

            // Initialize UIs
            ChestUI = new ChestInterfaceUI();
            ChestUI.Activate();
        }

        public override void Unload()
        {
            UIInterface = null;
            ChestUI = null;
        }

        public override void UpdateUI(GameTime gameTime)
        {
            if (UIInterface?.CurrentState != null)
                UIInterface.Update(gameTime);
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int inventoryIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));
            if (inventoryIndex != -1)
            {
                layers.Insert(inventoryIndex + 1, new LegacyGameInterfaceLayer(
                    "ChestInterface: UIs",
                    delegate
                    {
                        if (UIInterface?.CurrentState != null)
                            UIInterface.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI));
            }
        }

        // --------------------------
        // 🔹 UI CONTROL HELPERS
        // --------------------------

        public static void OpenUI(UIState ui)
        {
            if (ui == null)
                return;

            Main.playerInventory = true; // keeps UI stable
            UIInterface?.SetState(ui);
        }

        public static void CloseUI()
        {
            UIInterface?.SetState(null);
        }

        public static bool IsUIOpen(UIState ui)
        {
            return UIInterface?.CurrentState == ui;
        }

        public static bool IsAnyUIOpen => UIInterface?.CurrentState != null;
    }
}