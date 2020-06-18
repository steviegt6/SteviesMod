using Terraria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using SteviesMod.Content.Tiles.Jungle.Natural;
using SteviesMod.Content.Projectiles;

namespace SteviesMod.Content.Tiles
{
    public class SteviesGlobalTile : GlobalTile
    {
        public override void RandomUpdate(int i, int j, int type)
        {
            Tile tile = Main.tile[i, j - 1];
            if (Main.rand.Next(25) == 0 && type == TileID.JungleGrass && tile.active() && tile.type == TileID.JunglePlants && Main.hardMode && NPC.downedMechBossAny && Main.rand.Next(40) == 0)
            {
                WorldGen.KillTile(i, j - 1, false, false, true);
                WorldGen.PlaceTile(i, j - 1, ModContent.TileType<MagicFruitPlant>(), true, false, -1, Main.rand.Next(3));
            }
            base.RandomUpdate(i, j, type);
        }
        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            float num26 = 1f;
            num26 = (num26 * 2f + 1f) / 3f;
            int maxValue = (int)(250f / ((num26 + 1f) / 2f));
            switch (type)
            {
                case TileID.Pots:
                    if (!WorldGen.gen && Main.netMode != 1)
                    {
                        if (Main.rand.NextBool(100 * 4))
                            Projectile.NewProjectile(i * 16 + 16, j * 16 + 16, 0f, -12f, ModContent.ProjectileType<CopperCoinPortal>(), 0, 0f, Main.myPlayer);
                        if (Main.rand.NextBool(250 * 4))
                            Projectile.NewProjectile(i * 16 + 16, j * 16 + 16, 0f, -12f, ModContent.ProjectileType<SilverCoinPortal>(), 0, 0f, Main.myPlayer);
                    }
                    break;
            }
            base.KillTile(i, j, type, ref fail, ref effectOnly, ref noItem);
        }
    }
}
