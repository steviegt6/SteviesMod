using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Weapons.Melee.Swords
{
    public class AdamantiteShortsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adamantite Shortsword");
        }

        public override void SetDefaults()
        {
            item.width = item.height = 34;
            item.damage = 35;
            item.useAnimation = 23;
            item.useTime = 23;
            item.scale = 1.2f;
            item.value = ((75 * 100) * 9) * 5;
            item.useTurn = false;
            item.knockBack = 7f;
            item.UseSound = SoundID.Item1;
            item.rare = ItemRarityID.LightRed;
            item.autoReuse = true;
            //ItemEffects = "+15 armor penetration";

            SteviesGlobalItem.SetShortswordDefaults(item, ModContent.ProjectileType<Projectiles.AdamantiteShortswordProj>());
        }

        public override void HoldItem(Player player) => player.armorPenetration += 15;

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteBar, 9);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}