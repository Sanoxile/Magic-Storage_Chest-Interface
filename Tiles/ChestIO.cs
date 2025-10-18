using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.Localization;

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
            Main.tileSolidTop[Type] = true;
            Main.tileLavaDeath[Type] = false;

            // 2x2 tile setup
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Origin = new Point16(1, 1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.addTile(Type);

            // Map stuff
            AddMapEntry(new Color(200, 200, 200), CreateMapEntryName());

            // Sound and particles
            DustType = DustID.Iron;
            HitSound = SoundID.Dig;
        }
    }
}