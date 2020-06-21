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
    public class StarAniseStack : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Anise Stack");
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.StarAnise);
            item.width = 26;
            item.height = 26;
            item.consumable = false;
            base.SetDefaults();
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StarAnise, 396);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
            base.AddRecipes();
        }
    }
}
