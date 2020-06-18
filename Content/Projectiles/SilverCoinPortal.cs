using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Projectiles
{
    public class SilverCoinPortal : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silver Coin Portal");
            Main.projFrames[projectile.type] = 4;
            base.SetStaticDefaults();
        }
        public override void SetDefaults() //518
        {
            projectile.width = 32;
            projectile.height = 32;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.alpha = 255;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
			aiType = -1;
            base.SetDefaults();
        }
        public override void AI()
        {
			if (++projectile.frameCounter >= 4)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= Main.projFrames[projectile.type])
				{
					projectile.frame = 0;
				}
			}
			ref float reference = ref projectile.ai[0];
			ref float reference44 = ref reference;
			float num1390 = reference;
			reference44 = num1390 + 1f;
			if (projectile.ai[0] <= 40f)
			{
				projectile.alpha -= 5;
				if (projectile.alpha < 0)
				{
					projectile.alpha = 0;
				}
				projectile.velocity *= 0.85f;
				if (projectile.ai[0] == 40f)
				{
					projectile.netUpdate = true;
					switch (Main.rand.Next(3))
					{
						case 0:
							projectile.ai[1] = 20f;
							break;
						case 1:
							projectile.ai[1] = 45f;
							break;
						case 2:
							projectile.ai[1] = 80f;
							break;
					}
				}
			}
			else if (projectile.ai[0] <= 60f)
			{
				projectile.velocity = Vector2.Zero;
				if (projectile.ai[0] == 60f)
				{
					projectile.netUpdate = true;
				}
			}
			else if (projectile.ai[0] <= 210f)
			{
				if (Main.netMode != 1 && (projectile.localAI[0] += 1f) >= projectile.ai[1])
				{
					projectile.localAI[0] = 0f;
					int num460 = Item.NewItem((int)projectile.Center.X, (int)projectile.Center.Y, 0, 0, ItemID.SilverCoin, (int)projectile.ai[1]);
					Main.item[num460].velocity = Vector2.UnitY.RotatedByRandom(6.2831854820251465) * new Vector2(3f, 2f) * (Main.rand.NextFloat() * 0.5f + 0.5f) - Vector2.UnitY * 1f;
				}
				if (projectile.ai[0] == 210f)
				{
					projectile.netUpdate = true;
				}
			}
			else
			{
				projectile.scale -= 71f / (678f * (float)Math.PI);
				projectile.alpha += 15;
				if (projectile.ai[0] == 239f)
				{
					projectile.netUpdate = true;
				}
				if (projectile.ai[0] == 240f)
				{
					projectile.Kill();
				}
			}
			if (projectile.alpha < 90 && Main.rand.Next(3) == 0)
			{
				Vector2 value120 = new Vector2(projectile.width, projectile.height) * projectile.scale * 0.85f;
				value120 /= 2f;
				Vector2 value119 = Vector2.UnitY.RotatedByRandom(6.2831854820251465) * value120;
				int num459 = Dust.NewDust(projectile.Center + value119, 0, 0, 245);
				Main.dust[num459].position = projectile.Center + value119;
				Main.dust[num459].velocity = Vector2.Zero;
			}
			float num458 = 143f / 255f;
			float num457 = 156f / 255f;
			float num456 = 157f / 255f;
			Lighting.AddLight(projectile.Center, num458 * 0.3f, num457 * 0.3f, num456 * 0.3f);
			base.AI();
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Microsoft.Xna.Framework.Color color74 = Lighting.GetColor((int)((double)projectile.position.X + (double)projectile.width * 0.5) / 16, (int)(((double)projectile.position.Y + (double)projectile.height * 0.5) / 16.0));
            Vector2 vector95 = projectile.position + new Vector2(projectile.width, projectile.height) / 2f + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition;
            Texture2D texture2D26 = Main.projectileTexture[projectile.type];
            Microsoft.Xna.Framework.Rectangle rectangle15 = texture2D26.Frame(1, Main.projFrames[projectile.type], 0, projectile.frame);
            Microsoft.Xna.Framework.Color alpha4 = projectile.GetAlpha(color74);
            Vector2 origin16 = rectangle15.Size() / 2f;
            return base.PreDraw(spriteBatch, lightColor);
        }
        public override Color? GetAlpha(Color lightColor)
        {
            float num55 = 1f - (float)projectile.alpha / 255f;
            return new Color((int)(200f * num55), (int)(200f * num55), (int)(200f * num55), (int)(100f * num55));
        }
    }
}
