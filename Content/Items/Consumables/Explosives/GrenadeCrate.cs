using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Consumables.Explosives
{
    public class GrenadeCrate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Grenade Crate");
            Tooltip.SetDefault("A small explosion that will not destroy tiles");
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Grenade);
            item.consumable = false;
            item.value = Item.sellPrice(0, 2);
            base.SetDefaults();
        }
        public override void AddRecipes()
        {
            base.AddRecipes();
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Grenade, 30);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
