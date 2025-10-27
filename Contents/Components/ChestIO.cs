using MagicStorage;
using MagicStorage.Components;
using MagicStorage.Common.Players;
using MagicStorage.Common.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.GameInput;
using Terraria.Localization;
using Terraria.DataStructures;
using Terraria.GameContent.Drawing;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ModLoader;

namespace ChestInterface.Contents.Components
{
    public class ChestIO : StorageComponent
    {
        // Tells tmod what this tiles tile entity is
        public override ModTileEntity GetTileEntity() => ModContent.GetInstance<TEChestIO>();

        // Tells tmod what the item that places this tile is
        public override int ItemType(int frameX, int frameY) => ModContent.ItemType<Items.ChestIO>();

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

            OpenChestInterface(Main.LocalPlayer, i, j);

            return true;
        }

        internal static void OpenChestInterface(Player player, int i, int j, bool remoteCrafting = false)
        {
            StoragePlayer modPlayer = player.GetModPlayer<StoragePlayer>();
            Main.mouseRightRelease = false;
            if (player.sign > -1)
            {
                SoundEngine.PlaySound(SoundID.MenuClose);
                player.sign = -1;
                Main.editSign = false;
                Main.npcChatText = string.Empty;
            }

            if (Main.editChest)
            {
                SoundEngine.PlaySound(SoundID.MenuTick);
                Main.editChest = false;
                Main.npcChatText = string.Empty;
            }

            if (player.editedChestName)
            {
                NetMessage.SendData(MessageID.SyncPlayerChest, -1, -1, NetworkText.FromLiteral(Main.chest[player.chest].name), player.chest, 1f);
                player.editedChestName = false;
            }

            if (player.talkNPC > -1)
            {
                player.SetTalkNPC(-1);
                Main.npcChatCornerItem = 0;
                Main.npcChatText = string.Empty;
            }

            if (MagicUI.IsSecurityUIOpen())
            {
                // Either the Security UI is being opened, or the player is switching to a new UI
                // Prevent the UI from being closed by later conditions
                modPlayer.CloseStorage();
            }

            bool hadChestOpen = player.chest != -1;
            player.chest = -1;
            Main.stackSplit = 600;
            Point16 toOpen = new(i, j);
            Point16 prevOpen = modPlayer.ViewingStorage();
            if (prevOpen == toOpen)
            {
                modPlayer.CloseStorage();
                SoundEngine.PlaySound(SoundID.MenuClose);
                Recipe.FindRecipes();
            }
            else
            {
                bool hadOtherOpen = prevOpen.X >= 0 && prevOpen.Y >= 0;
                if (hadOtherOpen)
                    modPlayer.CloseStorage();

                modPlayer.OpenStorage(toOpen);
                modPlayer.remoteCrafting = remoteCrafting;
                modPlayer.timeSinceOpen = 0;
                if (PlayerInput.GrappleAndInteractAreShared)
                    PlayerInput.Triggers.JustPressed.Grapple = false;
                Main.playerInventory = true;
                Main.recBigList = false;
                Main.CreativeMenu.CloseMenu();
                if (TileEntity.ByPosition.TryGetValue(toOpen, out TileEntity te) && te is TEStorageComponent)
                    player.tileEntityAnchor.Set(te.ID, i, j);
                SoundEngine.PlaySound(hadChestOpen || hadOtherOpen ? SoundID.MenuTick : SoundID.MenuOpen);
                Recipe.FindRecipes();
            }
        }
        
        internal static void UIClose()
        {
            
        }
    }
}
