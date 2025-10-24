using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using MagicStorage;
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
                    Main.NewText($"[ChestIO] Connected to heart at {heart.Position.X}, {heart.Position.Y}", Color.LimeGreen);
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
