using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Weapons.Melee.Shortswords
{
    public class AdamantiteShortsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adamantite Shortsword");
            Tooltip.SetDefault("Can penetrate armor");
        }
        public override void SetDefaults()
        {
            item.width = item.height = 34;
            item.damage = 35;
            item.useAnimation = 23;
            item.useTime = 23;
            item.scale = 1.2f;
            item.value = ((75 * 100) * 9) * 5;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.useTurn = false;
            item.knockBack = 7f;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.rare = ItemRarityID.LightRed;
            item.autoReuse = true;
            base.SetDefaults();
        }
        public override void HoldItem(Player player)
        {
            player.armorPenetration += 15;
            base.HoldItem(player);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteBar, 9);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
            base.AddRecipes();
        }
    }
}
