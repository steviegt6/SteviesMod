using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Projectiles
{
    public abstract class ShortswordProjBase : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.scale = 1f;
            projectile.ownerHitCheck = true;
            projectile.melee = true;
            projectile.extraUpdates = 1;
            projectile.timeLeft = 360;
            projectile.hide = true;
            projectile.alpha = 255;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            projectile.scale = Main.player[Main.myPlayer].HeldItem.scale;
            Color color29 = Lighting.GetColor((int)((double)projectile.position.X + (double)projectile.width * 0.5) / 16, (int)(((double)projectile.position.Y + (double)projectile.height * 0.5) / 16.0));
            Vector2 vector43 = projectile.position + new Vector2(projectile.width, projectile.height) / 2f + Vector2.UnitY * projectile.gfxOffY - Main.screenPosition;
            Texture2D value107 = Main.projectileTexture[projectile.type];
            Microsoft.Xna.Framework.Color color68 = projectile.GetAlpha(color29);
            Vector2 origin17 = new Vector2(value107.Width, value107.Height) / 2f;
            float num295 = projectile.rotation;
            Vector2 vector44 = Vector2.One * projectile.scale;
            Microsoft.Xna.Framework.Rectangle? sourceRectangle2 = null;
            num295 -= (float)System.Math.PI / 4f * (float)projectile.spriteDirection;
            spriteBatch.Draw(value107, vector43, sourceRectangle2, color68, num295, origin17, vector44, SpriteEffects.None, 0f);
            return false;
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float collisionPoint9 = 0f;
            if (Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), projectile.Center, projectile.Center + projectile.velocity * 6f, 10f * projectile.scale, ref collisionPoint9))
            {
                return true;
            }
            return false;
        }

        public override void CutTiles()
        {
            DelegateMethods.tilecut_0 = TileCuttingContext.AttackProjectile;
            Utils.PlotTileLine(projectile.Center, projectile.Center + projectile.velocity.SafeNormalize(-Vector2.UnitY) * 10f, 10f * projectile.scale, DelegateMethods.CutTiles);
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            projectile.scale = player.HeldItem.scale;
            projectile.rotation = projectile.direction == 1 ? projectile.velocity.ToRotation() + (float)Math.PI / 2f : projectile.velocity.ToRotation() + (float)Math.PI * 2;
            projectile.ai[0] += 1f;
            float num2 = projectile.Opacity = GetLerpValue(0f, 7f, projectile.ai[0], clamped: true) * GetLerpValue(16f, 12f, projectile.ai[0], clamped: true);
            projectile.Center = player.RotatedRelativePoint(player.MountedCenter, false) + projectile.velocity * (projectile.ai[0] - 1f);
            projectile.spriteDirection = ((!(Vector2.Dot(projectile.velocity, Vector2.UnitX) < 0f)) ? 1 : (-1));
            if (projectile.ai[0] >= 16f)
            {
                projectile.Kill();
            }
            else
            {
                player.heldProj = projectile.whoAmI;
            }
        }

        public static float GetLerpValue(float from, float to, float t, bool clamped = false)
        {
            if (clamped)
            {
                if (from < to)
                {
                    if (t < from)
                    {
                        return 0f;
                    }
                    if (t > to)
                    {
                        return 1f;
                    }
                }
                else
                {
                    if (t < to)
                    {
                        return 1f;
                    }
                    if (t > from)
                    {
                        return 0f;
                    }
                }
            }
            return (t - from) / (to - from);
        }
    }

    public class CopperShortswordProj : ShortswordProjBase
    {
        public override string Texture => "Terraria/Item_" + ItemID.CopperShortsword;
    }

    public class TinShortswordProj : ShortswordProjBase
    {
        public override string Texture => "Terraria/Item_" + ItemID.TinShortsword;
    }

    public class IronShortswordProj : ShortswordProjBase
    {
        public override string Texture => "Terraria/Item_" + ItemID.IronShortsword;
    }

    public class LeadShortswordProj : ShortswordProjBase
    {
        public override string Texture => "Terraria/Item_" + ItemID.LeadShortsword;
    }

    public class SilverShortswordProj : ShortswordProjBase
    {
        public override string Texture => "Terraria/Item_" + ItemID.SilverShortsword;
    }

    public class TungstenShortswordProj : ShortswordProjBase
    {
        public override string Texture => "Terraria/Item_" + ItemID.TungstenShortsword;
    }

    public class GoldShortswordProj : ShortswordProjBase
    {
        public override string Texture => "Terraria/Item_" + ItemID.GoldShortsword;
    }

    public class PlatinumShortswordProj : ShortswordProjBase
    {
        public override string Texture => "Terraria/Item_" + ItemID.PlatinumShortsword;
    }

    public class AdamantiteShortswordProj : ShortswordProjBase
    {
        public override string Texture => "SteviesMod/Content/Items/Weapons/Melee/Swords/AdamantiteShortsword";
    }

    public class BloodPusherProj : ShortswordProjBase
    {
        public override string Texture => "SteviesMod/Content/Items/Weapons/Melee/Swords/BloodPusher";
    }

    public class BoneKnifeProj : ShortswordProjBase
    {
        public override string Texture => "SteviesMod/Content/Items/Weapons/Melee/Swords/BoneKnife";
    }

    public class BorealWoodShortswordProj : ShortswordProjBase
    {
        public override string Texture => "SteviesMod/Content/Items/Weapons/Melee/Swords/BorealWoodShortsword";
    }

    public class CactusShortswordProj : ShortswordProjBase
    {
        public override string Texture => "SteviesMod/Content/Items/Weapons/Melee/Swords/CactusShortsword";
    }

    public class CobaltShortswordProj : ShortswordProjBase
    {
        public override string Texture => "SteviesMod/Content/Items/Weapons/Melee/Swords/CobaltShortsword";
    }

    public class EbonwoodShortswordProj : ShortswordProjBase
    {
        public override string Texture => "SteviesMod/Content/Items/Weapons/Melee/Swords/EbonwoodShortsword";
    }

    public class LightsShameProj : ShortswordProjBase
    {
        public override string Texture => "SteviesMod/Content/Items/Weapons/Melee/Swords/LightsShame";
    }

    public class MythrilShortswordProj : ShortswordProjBase
    {
        public override string Texture => "SteviesMod/Content/Items/Weapons/Melee/Swords/MythrilShortsword";
    }

    public class OrichalcumShortswordProj : ShortswordProjBase
    {
        public override string Texture => "SteviesMod/Content/Items/Weapons/Melee/Swords/OrichalcumShortsword";
    }

    public class PalladiumShortswordProj : ShortswordProjBase
    {
        public override string Texture => "SteviesMod/Content/Items/Weapons/Melee/Swords/PalladiumShortsword";
    }

    public class PalmWoodShortswordProj : ShortswordProjBase
    {
        public override string Texture => "SteviesMod/Content/Items/Weapons/Melee/Swords/PalmWoodShortsword";
    }

    public class PearlwoodShortswordProj : ShortswordProjBase
    {
        public override string Texture => "SteviesMod/Content/Items/Weapons/Melee/Swords/PearlwoodShortsword";
    }

    public class RichMahoganyShortswordProj : ShortswordProjBase
    {
        public override string Texture => "SteviesMod/Content/Items/Weapons/Melee/Swords/RichMahoganyShortsword";
    }

    public class ShadewoodShortswordProj : ShortswordProjBase
    {
        public override string Texture => "SteviesMod/Content/Items/Weapons/Melee/Swords/ShadewoodShortsword";
    }

    public class TitaniumShortswordProj : ShortswordProjBase
    {
        public override string Texture => "SteviesMod/Content/Items/Weapons/Melee/Swords/TitaniumShortsword";
    }

    public class WoodenShortswordProj : ShortswordProjBase
    {
        public override string Texture => "SteviesMod/Content/Items/Weapons/Melee/Swords/WoodenShortsword";
    }
}