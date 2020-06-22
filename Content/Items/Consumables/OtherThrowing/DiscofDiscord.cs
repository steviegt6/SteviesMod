using Terraria.ID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using SteviesMod.Utils;
using SteviesMod.Content.Projectiles;

namespace SteviesMod.Content.Items.Consumables.OtherThrowing
{
    public class DiscofDiscord : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Disc of Discord");
            Tooltip.SetDefault("Teleports you to the place it landed");
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            item.width = item.height = 28;
            item.consumable = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 20;
            item.useTime = 20;
            item.UseSound = SoundID.Item8;
            item.rare = ItemRarityID.Lime;
            item.shootSpeed = 8f;
            item.maxStack = 99;
            item.shoot = ModContent.ProjectileType<Content.Projectiles.DiscofDiscord>();
            base.SetDefaults();
        }
    }
}
