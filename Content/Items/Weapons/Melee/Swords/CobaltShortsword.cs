using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Weapons.Melee.Swords
{
    public class CobaltShortsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cobalt Shortsword");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 30;
            item.damage = 24;
            item.useAnimation = 18;
            item.useTime = 18;
            //item.scale = 1.0f;
            item.value = ((21 * 100) * 7) * 5;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.useTurn = false;
            item.knockBack = 4f;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.rare = ItemRarityID.LightRed;
            item.autoReuse = true;
            //ItemEffects = "+5 armor penetration";

            SteviesGlobalItem.SetShortswordDefaults(item, ModContent.ProjectileType<Projectiles.CobaltShortswordProj>());
        }

        public override void HoldItem(Player player) => player.armorPenetration += 5;

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBar, 7);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}