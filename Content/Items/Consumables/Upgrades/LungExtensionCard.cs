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
    public class LungExtensionCard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lung Extension Card");
            Tooltip.SetDefault("Permanently increases your lung size" +
                "\n'This prodecure is not legal, but I will do it for you.'");
        }
        public override void SetDefaults()
        {
            item.width = 38;
            item.height = 28;
            item.maxStack = 99;
            item.useAnimation = 30;
            item.useTime = 30;
            item.value = Item.sellPrice(0);
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = SoundID.Item4;
            item.rare = ItemRarityID.Green;
            item.consumable = true;
            base.SetDefaults();
        }
        public override bool CanUseItem(Player player)
        {
            return !player.GetModPlayer<SteviesModPlayer>().extendedLungs;
        }
        public override bool UseItem(Player player)
        {
            if (player.itemAnimation > 0 && !player.GetModPlayer<SteviesModPlayer>().extendedLungs && player.itemTime == 0)
            {
                player.itemTime = PlayerHooks.TotalUseTime(item.useTime, player, item);
                player.breath += 100;
                player.breathMax = 300;
                player.GetModPlayer<SteviesModPlayer>().extendedLungs = true;
            }
            return false;
        }
    }
}
