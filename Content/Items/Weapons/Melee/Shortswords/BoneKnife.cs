using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Weapons.Melee.Shortswords
{
    public class BoneKnife : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bone Knife");
        }
        public override void SetDefaults()
        {
            item.width = item.height = 34;
            item.damage = 10;
            item.useAnimation = 14;
            item.useTime = 14;
            item.value = 11 * 100;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.useTurn = false;
            item.knockBack = 6f;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.rare = ItemRarityID.Orange;
            base.SetDefaults();
        }
    }
}
