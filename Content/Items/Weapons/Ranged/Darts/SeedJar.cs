using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Weapons.Ranged.Darts
{
    public class SeedJar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endless Seed Jar");
            Tooltip.SetDefault("For use with Blowpipe");
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            item.shoot = ProjectileID.Seed;
            item.damage = 3;
            item.width = 20;
            item.height = 26;
            item.ammo = AmmoID.Dart;
            item.value = Item.sellPrice(0, 2);
            item.ranged = true;
            base.SetDefaults();
        }
        public override void AddRecipes()
        {
            base.AddRecipes();
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Seed, 396);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
