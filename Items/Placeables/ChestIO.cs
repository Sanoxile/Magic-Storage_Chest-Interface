using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChestInterface.Items.Placeables
{
    public class ChestIO : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 1, 16, 25);
            Item.createTile = ModContent.TileType<Tiles.ChestIO>();
        }

        public override void AddRecipes()
        {
            // Stuff
            Mod magicStorage = ModLoader.GetMod("MagicStorage");

            // Recipe
            Recipe recipe = CreateRecipe();
			recipe.AddIngredient(magicStorage.Find<ModItem>("StorageComponent").Type, 1);
			recipe.AddRecipeGroup("MagicStorage:AnyDiamond", 2);
			recipe.AddRecipeGroup("IronBar", 5);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
    }
}
