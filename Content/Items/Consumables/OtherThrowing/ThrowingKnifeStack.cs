using Terraria.ID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using SteviesMod.Utils;

namespace SteviesMod.Content.Items.Consumables.OtherThrowing
{
    public class ThrowingKnifeStack : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Throwing Knife Set");
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ThrowingKnife);
            item.width = item.height = 24;
            item.consumable = false;
            base.SetDefaults();
        }
        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ThrowingKnife, 396);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
            base.AddRecipes();
        }*/
    }
}
