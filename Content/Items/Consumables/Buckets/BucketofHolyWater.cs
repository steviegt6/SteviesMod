using Terraria.ID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using SteviesMod.Utils;

namespace SteviesMod.Content.Items.Consumables.Buckets
{
    public class BucketofHolyWater : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bucket of Holy Water");
            Tooltip.SetDefault("Spreads the Hallow to some blocks");
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.HolyWater);
            item.width = 24;
            item.height = 22;
            item.consumable = false;
            base.SetDefaults();
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HolyWater, 30);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
            base.AddRecipes();
        }
    }
}
