using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using MagicStorage.Components;

namespace ChestInterface.TileEntities
{
    public class TEChestIO : TEStorageComponent
    {
        public override void Update()
        {
            base.Update(); // Keep Magic Storage’s internal network logic alive

            if (Main.GameUpdateCount % 180 == 0) // Every 3 seconds
            {
                var heart = GetHeart();
                if (heart != null)
                {
                    // Convert the TE position to the visible top-left tile of the heart
                    Tile tile = Main.tile[heart.Position.X, heart.Position.Y];
                    Main.NewText($"[ChestIO] Connected to heart at tile coords ({heart.Position.X/16}, {heart.Position.Y/16})", Color.LimeGreen);
                }
            }
        }

        public override bool ValidTile(in Tile tile)
        {
            // Ensure this TE only works with your ChestIO tile
            return tile.HasTile && tile.TileType == ModContent.TileType<Tiles.ChestIO>();
        }
    }
}
