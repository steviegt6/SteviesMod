using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Projectiles
{
    public class ExpertStar : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Disc of Discord");
            Main.projFrames[projectile.type] = 1;
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
			projectile.width = projectile.height = 28;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.alpha = 255;
            projectile.tileCollide = true;
            projectile.ignoreWater = false;
			aiType = -1;
            base.SetDefaults();
        }
    }
}
