using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MagicStorage.Components;
using Terraria.DataStructures;
using System.Drawing;
using System.Collections.Generic;

namespace ChestInterface.Contents.Components
{
    public class TEChestInterface : TEStorageComponent
    {
        // Internal vars
        public const int maxChestStorage = 5;
        internal Point16[] chestsCoords = new Point16[maxChestStorage];
        internal List<ModItem>[] filter = new List<ModItem>[maxChestStorage];

        // Tells tmod that the tile accosiated with the tile entity is ChestInterface
        public override bool ValidTile(in Tile tile) => tile.HasTile && tile.TileType == ModContent.TileType<ChestInterface>();

        // 
        public override void Update()
        {

        }

        // 
        internal void AddChest(Point16 newChest)
        {
            for (int i = 0; i < chestsCoords.Length; i++)
            {
                if (chestsCoords[i].X == -1)
                {
                    chestsCoords[i] = newChest;
                    break;
                }
            }
        }

        // Re-adjusts the chests and chest if they are still chests
        internal void AreChestsValid()
        {
            for (int i = 0; i < chestsCoords.Length; i++)
            {
                if (chestsCoords[i].X == -1) break; // Point is null

                Tile tile = Framing.GetTileSafely(chestsCoords[i].X, chestsCoords[i].Y);
                if (!tile.HasTile || !TileID.Sets.BasicChest[tile.TileType])
                {
                    for (int j = i; j < chestsCoords.Length; j++)
                    {
                        if (chestsCoords[j].X == -1) break; // Point is null
                        if (j == chestsCoords.Length-1) // At end of chestCoords
                        {
                            chestsCoords[j] = new Point16(-1, -1);
                            break;
                        }
                        chestsCoords[j] = chestsCoords[j+1];
                    }
                }
            }
        }
    }
}
