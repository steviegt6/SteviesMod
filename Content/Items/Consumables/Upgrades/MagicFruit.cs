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
    public class MagicFruit : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Arcane Fruit");
            Tooltip.SetDefault("Permanently increases maximum mana by 5");
        }
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 24;
            item.maxStack = 99;
            item.useAnimation = 30;
            item.useTime = 30;
            item.value = Item.sellPrice(0, 2);
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = SoundID.Item4;
            item.rare = ItemRarityID.Lime;
            item.consumable = true;
            base.SetDefaults();
        }
        public override bool CanUseItem(Player player)
        {
            return player.statManaMax >= 200 && player.GetModPlayer<SteviesModPlayer>().arcaneFruits < 10;
        }
        public override bool UseItem(Player player)
        {
            if (player.itemAnimation > 0 && player.statManaMax >= 200 && player.itemTime == 0)
            {
                player.itemTime = PlayerHooks.TotalUseTime(item.useTime, player, item);
                player.statManaMax2 += 5;
                player.GetModPlayer<SteviesModPlayer>().arcaneFruits += 1;
                player.statMana += 5;
                if (Main.myPlayer == player.whoAmI)
                    player.ManaEffect(5);
                AchievementsHelper.HandleSpecialEvent(player, AchievementHelperID.Special.ConsumeStar);
            }
            return false;
        }
    }
}
