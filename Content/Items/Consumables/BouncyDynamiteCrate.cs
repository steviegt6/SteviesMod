using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Consumables
{
    public class BouncyDynamiteCrate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bouncy Dynamite Crate");
            Tooltip.SetDefault("'This will prove to be a terrible idea'");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.BouncyDynamite);
            item.consumable = false;
            item.width = 22;
            item.height = 40;
            item.value = Item.sellPrice(0, 2);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BouncyDynamite, 60);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}