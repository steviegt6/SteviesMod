using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Consumables
{
    public class BouncyGrenadeCrate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bouncy Grenade Crate");
            Tooltip.SetDefault("A small explosion that will not destroy tiles" +
                "\nVery bouncy");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.BouncyGrenade);
            item.consumable = false;
            item.width = 18;
            item.height = 28;
            item.value = Item.sellPrice(0, 2);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BouncyGrenade, 60);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}