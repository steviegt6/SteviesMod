using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Consumables
{
    public class StickyBombCrate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sticky Bomb Crate");
            Tooltip.SetDefault("'Tossing may be difficult.'");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.StickyBomb);
            item.consumable = false;
            item.width = 22;
            item.height = 36;
            item.value = Item.sellPrice(0, 2);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StickyBomb, 60);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}