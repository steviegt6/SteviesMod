using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Consumables
{
    public class StickyDynamiteCrate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sticky Dynamite Crate");
            Tooltip.SetDefault("'Tossing may be difficult.'");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.StickyDynamite);
            item.consumable = false;
            item.width = 22;
            item.height = 40;
            item.value = Item.sellPrice(0, 2);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StickyDynamite, 60);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}