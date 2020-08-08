using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Weapons.Ranged.Arrows
{
    public class EndlessBoneQuiver : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endless Bone Quiver");
        }

        public override void SetDefaults()
        {
            item.shootSpeed = 3.5f;
            item.shoot = ProjectileID.BoneArrowFromMerchant;
            item.damage = 6;
            item.width = 26;
            item.height = 26;
            item.ammo = AmmoID.Arrow;
            item.knockBack = 2.5f;
            item.value = Item.sellPrice(0, 2);
            item.ranged = true;
            item.rare = ItemRarityID.White;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BoneArrow, 3996);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}