using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace ChestInterface.Tiles
{
    public class ChestIO : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true; // solid block
            Main.tileFrameImportant[Type] = true; // crucial for multi-tiles
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;

            // 2x2 tile setup
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Origin = new Point16(1, 1); // bottom-left placement
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 }; // two rows
            TileObjectData.addTile(Type);

            AddMapEntry(new Color(200, 200, 200));

            DustType = DustID.Iron;
            HitSound = SoundID.Dig;
        }
    }
}