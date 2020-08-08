using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Weapons.Melee.Swords
{
    public class TitaniumShortsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Titanium Shortsword");
            Tooltip.SetDefault("Can penetrate armor");
        }

        public override void SetDefaults()
        {
            item.width = item.height = 30;
            item.damage = 36;
            item.useAnimation = 22;
            item.useTime = 22;
            item.scale = 1.2f;
            item.value = ((85 * 100) * 10) * 5;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.useTurn = false;
            item.knockBack = 7f;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.rare = ItemRarityID.LightRed;
            item.autoReuse = true;
        }

        public override void HoldItem(Player player) => player.armorPenetration += 15;

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TitaniumBar, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}