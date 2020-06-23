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
    public class SpikyPouch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spiky Pouch");
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.SpikyBall);
            item.width = 26;
            item.height = 36;
            item.consumable = false;
            base.SetDefaults();
        }
        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SpikyBall, 999);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
            base.AddRecipes();
        }*/
    }
}
