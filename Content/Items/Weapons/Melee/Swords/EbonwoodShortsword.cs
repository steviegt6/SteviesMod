using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Weapons.Melee.Swords
{
    public class EbonwoodShortsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ebonwood Shortsword");
        }

        public override void SetDefaults()
        {
            item.width = item.height = 32;
            item.damage = 6;
            item.useAnimation = 13;
            item.useTime = 13;
            item.scale = 0.8f;
            item.value = 350;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.useTurn = false;
            item.knockBack = 4f;
            item.UseSound = SoundID.Item1;
            item.melee = true;

            SteviesGlobalItem.SetShortswordDefaults(item, ModContent.ProjectileType<Projectiles.EbonwoodShortswordProj>());
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ebonwood, 6);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}