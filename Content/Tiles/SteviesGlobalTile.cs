using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using SteviesMod.Content.Tiles.Jungle;

namespace SteviesMod.Content.Tiles
{
    public class SteviesGlobalTile : GlobalTile
    {
        public override void RandomUpdate(int i, int j, int type)
        {
            Tile tile = Main.tile[i, j - 1];

            if (Main.rand.NextBool(65) && type == TileID.JungleGrass && tile.active() && tile.type == TileID.JunglePlants && Main.hardMode && NPC.downedMechBossAny)
            {
                WorldGen.KillTile(i, j - 1, noItem: true);
                WorldGen.PlaceTile(i, j - 1, ModContent.TileType<MagicFruitPlant>(), true, false, -1, Main.rand.Next(3));
            }
        }
    }
}