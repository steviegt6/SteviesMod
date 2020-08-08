using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Weapons.Ranged.Darts
{
    public class CursedDartCase : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endless Cursed Dart Case");
            Tooltip.SetDefault("Drops cursed flames on the ground");
        }

        public override void SetDefaults()
        {
            item.shoot = ProjectileID.CursedDart;
            item.damage = 10;
            item.width = 24;
            item.height = 28;
            item.ammo = AmmoID.Dart;
            item.knockBack = 2.2f;
            item.shootSpeed = 3f;
            item.value = Item.sellPrice(0, 2);
            item.ranged = true;
            item.rare = ItemRarityID.Orange;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CursedDart, 3996);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}