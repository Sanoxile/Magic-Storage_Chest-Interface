using Terraria;
using Terraria.ModLoader;
using MagicStorage.Components;
using MagicStorageAddons.Contents.DataStructures;

namespace MagicStorageAddons.Contents.Components
{
    public class TEChestInterface : TEStorageComponent
    {
        // Internal vars
        internal FilterDataStructure connectedChests;

        // Tells tmod that the tile accosiated with the tile entity is ChestInterface
        public override bool ValidTile(in Tile tile) => tile.HasTile && tile.TileType == ModContent.TileType<ChestInterface>();

        // 
        public override void Update()
        {
            
        }
    }
}
