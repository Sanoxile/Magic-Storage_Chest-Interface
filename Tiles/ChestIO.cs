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
            // Tile stats
            Main.tileSolid[Type] = false;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = false;
            Main.tileSolidTop[Type] = true;
            TileID.Sets.Platforms[Type] = true;

            // 2x2 tile setup
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Origin = new Point16(1, 1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.addTile(Type);

            // Map stuff
            AddMapEntry(new Color(200, 200, 200));

            // Sound and particles
            DustType = DustID.Iron;
            HitSound = SoundID.Dig;
        }
    }
}