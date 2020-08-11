using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Weapons.Melee.Swords
{
    public class OrichalcumShortsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orichalcum Shortsword");
        }

        public override void SetDefaults()
        {
            item.width = item.height = 32;
            item.damage = 31;
            item.useAnimation = 19;
            item.useTime = 19;
            //item.scale = 1.0f;
            item.value = ((52 * 100) * 9) * 5;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.useTurn = false;
            item.knockBack = 6f;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.rare = ItemRarityID.LightRed;
            item.autoReuse = true;
            //ItemEffects = "+5 armor penetration";

            SteviesGlobalItem.SetShortswordDefaults(item, ModContent.ProjectileType<Projectiles.OrichalcumShortswordProj>());
        }

        public override void HoldItem(Player player) => player.armorPenetration += 5;

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.OrichalcumBar, 9);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}