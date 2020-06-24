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
    public class PoisonDartCase : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Endless Poison Dart Case");
            Tooltip.SetDefault("Inflicts poison on enemies");
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            item.shoot = ProjectileID.PoisonDart;
            item.damage = 10;
            item.width = 24;
            item.height = 28;
            item.ammo = AmmoID.Dart;
            item.knockBack = 2f;
            item.value = Item.sellPrice(0, 2);
            item.ranged = true;
            item.rare = ItemRarityID.Green;
            base.SetDefaults();
        }
        public override void AddRecipes()
        {
            base.AddRecipes();
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PoisonDart, 3996);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
