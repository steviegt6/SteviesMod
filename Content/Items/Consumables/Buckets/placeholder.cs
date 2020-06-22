using Terraria.ID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using SteviesMod.Utils;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using SteviesMod.Content.Tiles.Underground;

namespace SteviesMod.Content.Items.Consumables.Buckets
{
    public class placeholder : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bottomless Bucket");
            //Tooltip.SetDefault("Contains an endless amount of air");
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.BottomlessBucket);
            item.createTile = ModContent.TileType<ManaCrystal>();
            base.SetDefaults();
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.EmptyBucket, 30);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
            base.AddRecipes();
        }
    }
}
