using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Consumables
{
    public class BombCrate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bomb Crate");
            Tooltip.SetDefault("A small explosion that will destroy some tiles");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Bomb);
            item.consumable = false;
            item.width = 22;
            item.height = 36;
            item.value = Item.sellPrice(0, 2);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bomb, 60);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}