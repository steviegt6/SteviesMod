using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Weapons.Ranged.Arrows
{
    public class EndlessFrostburnQuiver : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endless Frostburn Quiver");
        }

        public override void SetDefaults()
        {
            item.shootSpeed = 3.75f;
            item.shoot = ProjectileID.FrostburnArrow;
            item.damage = 9;
            item.width = 26;
            item.height = 26;
            item.ammo = AmmoID.Arrow;
            item.knockBack = 2.2f;
            item.value = Item.sellPrice(0, 2);
            item.ranged = true;
            item.rare = ItemRarityID.White;
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            if (!item.wet)
            {
                Lighting.AddLight((int)((item.position.X + item.width) / 16f), (int)((item.position.Y + item.height / 2) / 16f), 0.35f, 0.65f, 1f);
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FrostburnArrow, 3996);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}