using Terraria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using SteviesMod.Content.Tiles.Jungle.Natural;

namespace SteviesMod.Content.Tiles
{
    public class SteviesGlobalItem : GlobalTile
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
    }
}
