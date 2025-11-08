using MagicStorage.Components;
using MagicStorage.Common.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.GameContent.Drawing;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ModLoader;
using MagicStorageAddons.Contents.UI;

namespace MagicStorageAddons.Contents.Components
{
    public class ChestInterface : StorageComponent
    {
        // Tells tmod what this tiles tile entity is
        public override ModTileEntity GetTileEntity() => ModContent.GetInstance<TEChestInterface>();

        // Tells tmod what the item that places this tile is
        public override int ItemType(int frameX, int frameY) => ModContent.ItemType<Items.ChestInterface>();

        // Tells tmod that the block can be interacted with the smart cursor
        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => true;

        // Gets the heart connected to the chest interface (returns null if it doesn't exist)
        public virtual TEStorageHeart GetHeart(int i, int j)
        {
            if (TileEntity.ByPosition.TryGetValue(new Point16(i, j), out TileEntity te) && te is TEStorageComponent component)
                return component.GetHeart();

            return null;
        }

        // Shows the block when moused over and when your inventory is open and the block is
        // moused over you cannot throw out items
        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            Tile tile = Main.tile[i, j];
            player.cursorItemIconEnabled = true;
            player.cursorItemIconID = ItemType(tile.TileFrameX, tile.TileFrameY);
            player.noThrow = 2;

            base.MouseOver(i, j);
        }

        // After drawing the initial tile then draw the glow if not hidden by echo paint
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            if (!TileDrawing.IsVisible(tile))
                return;  // Hidden by Echo Coating

            Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
            Vector2 drawPos = zero + 16f * new Vector2(i, j) - Main.screenPosition;
            Rectangle frame = new(tile.TileFrameX, tile.TileFrameY, 16, 16);
            Color lightColor = Lighting.GetColor(i, j, Color.GhostWhite);
            Color color = Color.Lerp(lightColor, Color.GhostWhite, Main.essScale);
            spriteBatch.Draw(ModContent.Request<Texture2D>(Texture + "_Glow").Value, drawPos, frame, color);
        }

        // Right click adjustments
        public override bool RightClick(int i, int j)
        {
            if (Main.tile[i, j].TileFrameX % 36 == 18)
                i--;
            if (Main.tile[i, j].TileFrameY % 36 == 18)
                j--;

            if (GetHeart(i, j) == null)
            {
                Main.NewText("Storage Heart is not connected", Color.DarkRed);
                return true;
            }

            // Here we go
            if (Main.netMode == NetmodeID.Server)
                return false;

            Main.playerInventory = true;
            // This opens the Magic Storage UI for this tile


            // If you want to open your own UI instead of the normal storage UI,
            // you can replace the line above with your own MagicUI state call:
            MagicUI.uiInterface.SetState(new ChestInterfaceUI());

            // Here we go
            return true;
        }

        internal static void OpenChestInterface(Player player, int i, int j, bool remoteCrafting = false)
        {

        }
    }
}
