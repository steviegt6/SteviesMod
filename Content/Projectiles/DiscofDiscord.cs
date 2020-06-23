using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Projectiles
{
    public class DiscofDiscord : ModProjectile
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
        public override void AI()
        {
            projectile.rotation += (Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y)) * 0.09f * (float)projectile.direction;
            projectile.alpha = 0;
            projectile.ai[0] += 1f;
            if (projectile.ai[0] >= 60)
            {
                projectile.velocity.Y += 0.2f;
                projectile.velocity.X *= 0.98f;
            }
        }
        public override void Kill(int timeLeft)
        {
            Player player = Main.LocalPlayer;
            Vector2 vector51 = default(Vector2);
            vector51.X = projectile.position.X;
            if (player.gravDir == 1f)
            {
                vector51.Y = projectile.position.Y - player.height;
            }
            else
            {
                vector51.Y = projectile.position.Y;
            }
            vector51.X -= player.width / 2;
            if (vector51.X > 50f && vector51.X < (float)(Main.maxTilesX * 16 - 50) && vector51.Y > 50f && vector51.Y < (float)(Main.maxTilesY * 16 - 50))
            {
                int num457 = (int)(vector51.X / 16f);
                int num456 = (int)(vector51.Y / 16f);
                if ((Main.tile[num457, num456].wall != 87 || !((double)num456 > Main.worldSurface) || NPC.downedPlantBoss) && !Collision.SolidCollision(vector51, player.width, player.height))
                {
                    player.Teleport(vector51, 1);
                    NetMessage.SendData(65, -1, -1, null, 0, player.whoAmI, vector51.X, vector51.Y, 1);
                    if (player.chaosState)
                    {
                        player.statLife -= player.statLifeMax2 / 7;
                        PlayerDeathReason damageSource = PlayerDeathReason.ByOther(13);
                        if (Main.rand.Next(2) == 0)
                        {
                            damageSource = PlayerDeathReason.ByOther(player.Male ? 14 : 15);
                        }
                        if (player.statLife <= 0)
                        {
                            player.KillMe(damageSource, 1.0, 0);
                        }
                        player.lifeRegenCount = 0;
                        player.lifeRegenTime = 0;
                    }
                    player.AddBuff(88, 360);
                }
            }
            base.Kill(timeLeft);
        }
    }
}
