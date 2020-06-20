﻿using Terraria.ID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using SteviesMod.Utils;

namespace SteviesMod.Content.Items.Consumables.Buckets
{
    public class BottomlessLavaBucket : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bottomless Lava Bucket");
            Tooltip.SetDefault("Contains an endless amount of lava");
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.BottomlessBucket);
            base.SetDefaults();
        }
        public override bool UseItem(Player player)
        {
            return LiquidHelper.PlaceLiquid(player, LiquidHelper.Liquids.Lava, 2);
        }
    }
}
