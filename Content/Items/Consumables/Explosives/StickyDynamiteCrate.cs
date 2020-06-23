﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Consumables.Explosives
{
    public class StickyDynamiteCrate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sticky Dynamite Crate");
            Tooltip.SetDefault("'Tossing may be difficult.'");
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.StickyDynamite);
            item.consumable = false;
            item.width = 22;
            item.height = 40;
            item.value = Item.sellPrice(0, 2);
            base.SetDefaults();
        }
        public override void AddRecipes()
        {
            base.AddRecipes();
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StickyDynamite, 60);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
