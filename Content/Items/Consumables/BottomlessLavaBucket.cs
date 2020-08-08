using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using SteviesMod.Utilities;

namespace SteviesMod.Content.Items.Consumables
{
    public class BottomlessLavaBucket : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bottomless Lava Bucket");
            Tooltip.SetDefault("Contains an endless amount of lava");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.BottomlessBucket);
        }

        public override bool UseItem(Player player)
        {
            return LiquidHelper.PlaceLiquid(player, LiquidHelper.Liquids.Lava, 2);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BottomlessEmptyBucket>());
            recipe.needLava = true;
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LavaBucket, 60);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}