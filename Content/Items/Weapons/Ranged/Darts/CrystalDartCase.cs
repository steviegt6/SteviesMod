using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Weapons.Ranged.Darts
{
    public class CrystalDartCase : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endless Crystal Dart Case");
            Tooltip.SetDefault("Bounces between enemies");
        }

        public override void SetDefaults()
        {
            item.shoot = ProjectileID.CrystalDart;
            item.damage = 15;
            item.width = 24;
            item.height = 28;
            item.ammo = AmmoID.Dart;
            item.knockBack = 3.5f;
            item.shootSpeed = 1f;
            item.value = Item.sellPrice(0, 2);
            item.ranged = true;
            item.rare = ItemRarityID.Orange;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrystalDart, 3996);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}