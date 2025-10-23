using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChestInterface.Items.Placeables
{
    public class ChestIO : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Journey mode research
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            // Deals with basic item appearence
            Item.width = 26;
            Item.height = 26;
            Item.maxStack = 99;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(gold: 1, silver: 20);

            // Deals with animation
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;

            // Deals with tile placement
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.ChestIO>();
        }

        public override void AddRecipes()
        {
            // Adds the recipe
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<MagicStorage.Items.StorageComponent>(), 1);
            recipe.AddIngredient(ItemID.Wire, 50);
            recipe.AddIngredient(ItemID.Obsidian, 5);
            recipe.AddIngredient(ItemID.MeteoriteBar, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
