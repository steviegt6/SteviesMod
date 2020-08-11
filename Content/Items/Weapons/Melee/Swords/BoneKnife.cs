using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Weapons.Melee.Swords
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
            item.useTurn = false;
            item.knockBack = 6f;
            item.UseSound = SoundID.Item1;
            item.rare = ItemRarityID.Orange;

            SteviesGlobalItem.SetShortswordDefaults(item, ModContent.ProjectileType<Projectiles.AdamantiteShortswordProj>());
        }
    }
}