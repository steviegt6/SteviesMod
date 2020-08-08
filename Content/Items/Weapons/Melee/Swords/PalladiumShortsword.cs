using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Weapons.Melee.Swords
{
    public class PalladiumShortsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Palladium Shortsword");
            Tooltip.SetDefault("Can penetrate armor");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 36;
            item.damage = 28;
            item.useAnimation = 20;
            item.useTime = 20;
            item.scale = 1.1f;
            item.value = ((27 * 100) * 9) * 5;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.useTurn = false;
            item.knockBack = 6f;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.rare = ItemRarityID.LightRed;
            item.autoReuse = true;
        }

        public override void HoldItem(Player player) => player.armorPenetration += 10;

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PalladiumBar, 9);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}