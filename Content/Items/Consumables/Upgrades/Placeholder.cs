using Microsoft.Xna.Framework;
using SteviesMod.Content.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Consumables.Upgrades
{
    public class Placeholder : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("testing item");
            Tooltip.SetDefault("lets hope it crashes your game");
        }
        public override void SetDefaults()
        {
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.consumable = true;
            item.shoot = ModContent.ProjectileType<CopperCoinPortal>();
            base.SetDefaults();
        }
    }
}
