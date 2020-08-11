using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Weapons.Melee.Swords
{
    public class LightsShame : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Light's Shame");
        }

        public override void SetDefaults()
        {
            item.width = item.width = 32;
            item.useAnimation = 15;
            item.damage = 12;
            item.useTime = 15;
            item.scale = 1.1f;
            item.value = ((30 * 100) * 7) * 5;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.useTurn = false;
            item.knockBack = 4f;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.rare = ItemRarityID.Blue;

            SteviesGlobalItem.SetShortswordDefaults(item, ModContent.ProjectileType<Projectiles.LightsShameProj>());
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}