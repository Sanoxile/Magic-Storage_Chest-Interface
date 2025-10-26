using Terraria;
using Terraria.ModLoader;
using MagicStorage.Components;

namespace ChestInterface.Contents.Components
{
    public class TEChestIO : TEStorageComponent
    {
        public override void Update()
        {
            
        }

        public override bool ValidTile(in Tile tile)
        {
            // Ensure this TE only works with your ChestIO tile
            return tile.HasTile && tile.TileType == ModContent.TileType<ChestIO>();
        }
    }
}
