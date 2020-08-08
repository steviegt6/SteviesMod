using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Weapons.Ranged.Bullets
{
    public class EndlessCrystalPouch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endless Crystal Pouch");
            Tooltip.SetDefault("Creates several crystal shards on impact");
        }

        public override void SetDefaults()
        {
            item.shootSpeed = 5f;
            item.shoot = ProjectileID.CrystalBullet;
            item.damage = 9;
            item.width = 26;
            item.height = 26;
            item.ammo = AmmoID.Bullet;
            item.knockBack = 1f;
            item.value = Item.sellPrice(0, 2);
            item.ranged = true;
            item.rare = ItemRarityID.Orange;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrystalBullet, 3996);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}