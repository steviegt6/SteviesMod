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
    public class MysteriousFossil : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mysterious Fossil");
            Tooltip.SetDefault("Permanently increases mining speed by 20%");
        }
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.maxStack = 99;
            item.useAnimation = 30;
            item.useTime = 30;
            item.value = Item.sellPrice(0, 1, 5);
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = SoundID.Item4;
            item.rare = ItemRarityID.Green;
            item.consumable = true;
            base.SetDefaults();
        }
        public override bool CanUseItem(Player player)
        {
            return player.GetModPlayer<SteviesModPlayer>().mysteriousFossils < 5;
        }
        public override bool UseItem(Player player)
        {
            if (player.itemAnimation > 0 && player.GetModPlayer<SteviesModPlayer>().mysteriousFossils < 5 && player.itemTime == 0)
            {
                player.itemTime = PlayerHooks.TotalUseTime(item.useTime, player, item);
                player.pickSpeed -= 0.20f;
                player.GetModPlayer<SteviesModPlayer>().mysteriousFossils += 1;
            }
            return false;
        }
    }
}
