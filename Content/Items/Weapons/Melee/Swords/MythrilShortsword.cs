using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Weapons.Melee.Swords
{
    public class MythrilShortsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mythril Shortsword");
        }

        public override void SetDefaults()
        {
            item.width = item.height = 36;
            item.damage = 31;
            item.useAnimation = 21;
            item.useTime = 21;
            item.scale = 1.1f;
            item.value = ((44 * 100) * 7) * 5;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.useTurn = false;
            item.knockBack = 5f;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.rare = ItemRarityID.LightRed;
            item.autoReuse = true;
            //ItemEffects = "+10 armor penetration";

            SteviesGlobalItem.SetShortswordDefaults(item, ModContent.ProjectileType<Projectiles.MythrilShortswordProj>());
        }

        public override void HoldItem(Player player) => player.armorPenetration += 10;

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MythrilBar, 7);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}