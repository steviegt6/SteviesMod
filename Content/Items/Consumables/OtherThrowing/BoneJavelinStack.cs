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
    public class BoneJavelinStack : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bone Javelin Stack");
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.BoneJavelin);
            item.width = 46;
            item.height = 46;
            item.consumable = false;
            base.SetDefaults();
        }
        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BoneJavelin, 999);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
            base.AddRecipes();
        }*/
    }
}
