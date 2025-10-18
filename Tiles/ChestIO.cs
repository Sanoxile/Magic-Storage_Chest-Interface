using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace chest_compadability.Tiles // ✅ this part is crucial
{
    public class ChestIO : ModTile // ✅ must inherit ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = false;
            Main.tileSolidTop[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = false;
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = false;
            TileID.Sets.Platforms[Type] = true;
            Main.tileBlockLight[Type] = false;
            Main.tileNoSunLight[Type] = false;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.CoordinateHeights = new[] { 16 }; // 1 tile tall
            TileObjectData.addTile(Type);

            var itemName = CreateMapEntryName();
            itemName.Format("Chest I/O");
            AddMapEntry(new Color(200, 200, 200), itemName);

            DustType = DustID.Copper;
            HitSound = SoundID.Dig;
        }
    }
}