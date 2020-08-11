using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Weapons.Melee.Swords
{
    public class CactusShortsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cactus Shortsword");
        }

        public override void SetDefaults()
        {
            item.width = item.height = 34;
            item.damage = 5;
            item.useAnimation = 14;
            item.useTime = 14;
            item.scale = 0.9f;
            item.value = 2 * 7;
            item.useTurn = false;
            item.knockBack = 4f;
            item.UseSound = SoundID.Item1;

            SteviesGlobalItem.SetShortswordDefaults(item, ModContent.ProjectileType<Projectiles.CactusShortswordProj>());
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Cactus, 7);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}