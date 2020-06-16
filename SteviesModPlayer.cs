using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod
{
    public class SteviesModPlayer : ModPlayer
    {
        public bool ZonePurity()
        {
            if (!player.ZoneBeach && !player.ZoneCorrupt && !player.ZoneCrimson && !player.ZoneDesert && !player.ZoneDungeon && !player.ZoneGlowshroom && !player.ZoneHoly && !player.ZoneJungle && !player.ZoneOldOneArmy && !player.ZoneSnow && !player.ZoneUndergroundDesert)
                return true;
            else
                return false;
        }
        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
        {
            if (junk)
                return;
            if (player.ZoneDesert || player.ZoneUndergroundDesert)
                if (Main.rand.NextBool(15))
                    switch (Main.rand.Next(5))
                    {
                        case 0:
                            caughtType = ItemID.FlyingCarpet;
                            break;
                        case 1:
                            caughtType = ItemID.SandstorminaBottle;
                            break;
                        default:
                            break;
                    }
            if (ZonePurity())
                if (Main.rand.NextBool(10))
                    switch (Main.rand.Next(4))
                    {
                        case 0:
                            caughtType = ItemID.Spear;
                            break;
                        case 1:
                            caughtType = ItemID.Blowpipe;
                            break;
                        case 2:
                            caughtType = ItemID.WoodenBoomerang;
                            break;
                        case 3:
                            caughtType = ItemID.WandofSparking;
                            break;
                        default:
                            break;
                    }
            base.CatchFish(fishingRod, bait, power, liquidType, poolSize, worldLayer, questFish, ref caughtType, ref junk);
        }
    }
}
