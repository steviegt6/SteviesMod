using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Consumables
{
    public class DynamiteCrate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dynamite Crate");
            Tooltip.SetDefault("A large explosion that will destroy most tiles");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Dynamite);
            item.width = 22;
            item.height = 40;
            item.consumable = false;
            item.value = Item.sellPrice(0, 2);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Dynamite, 60);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}