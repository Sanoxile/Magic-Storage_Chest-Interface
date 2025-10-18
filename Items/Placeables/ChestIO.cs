using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using MagicStorage;

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
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient<StorageComponent>();
			recipe.AddRecipeGroup("MagicStorage:AnyDiamond");
			recipe.AddRecipeGroup("IronBar", 3);
			recipe.AddTile(TileID.WorkBenches);
			// Mechs must be defeated in order to shimmer this item
			// While the item can't be decrafted, this condition is still checked for item transformations
			recipe.AddDecraftCondition(Condition.DownedMechBossAll);
			recipe.Register();
		}
    }
}
