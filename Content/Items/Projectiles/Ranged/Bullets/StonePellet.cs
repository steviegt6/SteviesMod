using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Projectiles.Ranged.Bullets
{
    public class StonePellet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone Pellet");
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 2;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.timeLeft = 10 * 60;
            projectile.alpha = 255;
            projectile.tileCollide = true;
            projectile.ignoreWater = false;
            aiType = ProjectileID.Bullet;
            base.SetDefaults();
        }
        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item10, projectile.position);
            base.Kill(timeLeft);
        }
    }
}
