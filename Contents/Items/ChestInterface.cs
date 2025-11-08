using MagicStorage.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicStorageAddons.Contents.Items
{
    public class ChestInterface : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 26;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.sellPrice(gold: 1, silver: 20);
            Item.createTile = ModContent.TileType<Components.ChestInterface>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<StorageComponent>(), 1);
            recipe.AddIngredient(ItemID.Wire, 50);
            recipe.AddIngredient(ItemID.Obsidian, 5);
            recipe.AddIngredient(ItemID.MeteoriteBar, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
