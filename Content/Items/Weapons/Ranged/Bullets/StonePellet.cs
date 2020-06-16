using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Weapons.Ranged.Bullets
{
    public class StonePellet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone Pellet");
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            item.damage = 4;
            item.ranged = true;
            item.width = item.height = 12;
            item.maxStack = 999;
            item.consumable = true;
            item.knockBack = 1f;
            item.value = 5 * 5;
            item.rare = ItemRarityID.White;
            item.shoot = ModContent.ProjectileType<Items.Projectiles.Ranged.Bullets.StonePellet>();
            item.shootSpeed = 4f;
            item.ammo = AmmoID.Bullet;
            base.SetDefaults();
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddTile(ItemID.WorkBench);
            recipe.SetResult(this, 70);
            base.AddRecipes();
        }
    }
}
