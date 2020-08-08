using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Weapons.Ranged.Arrows
{
    public class EndlessVenomQuiver : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endless Venom Quiver");
            Tooltip.SetDefault("Inflicts target with Venom");
        }

        public override void SetDefaults()
        {
            item.shootSpeed = 4.3f;
            item.shoot = ProjectileID.VenomArrow;
            item.damage = 17;
            item.width = 26;
            item.height = 26;
            item.ammo = AmmoID.Arrow;
            item.knockBack = 4.2f;
            item.value = Item.sellPrice(0, 2);
            item.ranged = true;
            item.rare = ItemRarityID.Orange;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.VenomArrow, 3996);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}