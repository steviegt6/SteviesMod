using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Weapons.Melee.Swords
{
    public class RichMahoganyShortsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rich Mahogany Shortsword");
        }

        public override void SetDefaults()
        {
            item.width = item.height = 32;
            item.damage = 5;
            item.useAnimation = 13;
            item.useTime = 13;
            item.scale = 0.8f;
            item.value = 350;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.useTurn = false;
            item.knockBack = 4f;
            item.UseSound = SoundID.Item1;
            item.melee = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RichMahogany, 6);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}