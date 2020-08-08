using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Consumables
{
    public class DiscofDiscord : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Disc of Discord");
            Tooltip.SetDefault("Teleports you to the place it landed");
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
            item.shootSpeed = 10f;
            item.maxStack = 99;
            item.shoot = ModContent.ProjectileType<Projectiles.DiscofDiscord>();
        }
    }
}