using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Weapons.Melee.Swords
{
    public class BloodPusher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blood Pusher");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 34;
            item.damage = 14;
            item.useAnimation = 17;
            item.useTime = 17;
            item.scale = 1.1f;
            item.value = ((39 * 100) * 7) * 5;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.useTurn = false;
            item.knockBack = 5f;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaneBar, 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}