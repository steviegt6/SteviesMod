using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Weapons.Ranged.Bullets
{
    public class EndlessLuminitePouch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endless Luminite Pouch");
            Tooltip.SetDefault("'Line 'um up and knock 'em down...'");
        }

        public override void SetDefaults()
        {
            item.shootSpeed = 2f;
            item.shoot = ProjectileID.MoonlordBullet;
            item.damage = 20;
            item.width = 26;
            item.height = 26;
            item.ammo = AmmoID.Bullet;
            item.knockBack = 3f;
            item.value = Item.sellPrice(0, 2);
            item.ranged = true;
            item.rare = ItemRarityID.Cyan;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MoonlordBullet, 3996);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}