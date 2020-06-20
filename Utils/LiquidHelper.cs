using Terraria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using IL.Terraria.Achievements;

namespace SteviesMod.Utils
{
    public class LiquidHelper : ModPlayer
    {
        public enum Liquids : byte
        {
            Water,
            Lava,
            Honey
        }
        internal static bool PlaceLiquids(Player player, int x, int y, Liquids liquid)
        {
            if (Main.netMode != NetmodeID.Server)
            {
                Tile tileSafely = Framing.GetTileSafely(x, y);
                if (player.whoAmI == Main.myPlayer && (!tileSafely.nactive() || !Main.tileSolid[(int)tileSafely.type] || Main.tileSolidTop[(int)tileSafely.type]))
                {
                    tileSafely.liquidType((int)liquid);
                    tileSafely.liquid = 255;
                    WorldGen.SquareTileFrame(x, y, true);
                    if (Main.netMode == 1)
                        NetMessage.sendWater(x, y);
                    else
                        Liquid.AddWater(x, y);
                    return true;
                }
            }
            return false;
        }
        internal static bool PlaceLiquid(Player player, Liquids liquid, int range)
        {
            if (player.whoAmI == Main.myPlayer && !player.noBuilding)
            {
                Vector2 adjustedPos = player.position / 16;
                float xDistance = Math.Abs(Player.tileTargetX - adjustedPos.X);
                float yDistance = Math.Abs(Player.tileTargetY - adjustedPos.Y);

                if (xDistance > Player.tileRangeX + range || yDistance > Player.tileRangeY + range)
                    return false;
                if (PlaceLiquids(player, Player.tileTargetX, Player.tileTargetY, liquid))
                {
                    Main.PlaySound(SoundID.Splash, (int)player.position.X, (int)player.position.Y, 1, 1f, 0f);
                    return true;
                }
            }
            return false;
        }
    }
}
