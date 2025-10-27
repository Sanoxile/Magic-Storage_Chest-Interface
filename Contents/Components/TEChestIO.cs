using Terraria;
using Terraria.ModLoader;
using MagicStorage.Components;

namespace ChestInterface.Contents.Components
{
    public class TEChestIO : TEStorageComponent
    {
        // Tells tmod that the tile accosiated with the tile entity is ChestIO
        public override bool ValidTile(in Tile tile) => tile.HasTile && tile.TileType == ModContent.TileType<ChestIO>();
        
        // 
        public override void Update()
        {
            
        }
    }
}
