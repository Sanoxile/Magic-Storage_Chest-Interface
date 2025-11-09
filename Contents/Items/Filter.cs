using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicStorageAddons.Contents.Items
{
    public class Filter : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 26;
            Item.maxStack = 1;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.rare = ItemRarityID.Red;
            Item.value = Item.sellPrice(silver: 80);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(RecipeGroupID.IronBar, 5);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddIngredient(ItemID.Wire, 50);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
