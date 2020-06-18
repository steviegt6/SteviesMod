using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace SteviesMod
{
    public class SteviesModPlayer : ModPlayer
    {
        public static SteviesModPlayer Instance;

        public int arcaneFruits;
        public int mysteriousFossils;
        public bool extendedLungs;
        public override void ResetEffects()
        {
            player.statManaMax2 += 5 * arcaneFruits;
            player.pickSpeed -= 0.20f * mysteriousFossils;
            if (extendedLungs)
                player.breathMax = 300;
            base.ResetEffects();
        }
        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = mod.GetPacket();
            packet.Write(arcaneFruits);
            packet.Write(mysteriousFossils);
            packet.Write(extendedLungs);
            packet.Send(toWho, fromWho);
            base.SyncPlayer(toWho, fromWho, newPlayer);
        }
        public override TagCompound Save()
        {
            return new TagCompound
            {
                { "arcaneFruits", arcaneFruits },
                { "mysteriousFossils", mysteriousFossils },
                { "extendedLungs", extendedLungs }
            };
        }
        public override void Load(TagCompound tag)
        {
            arcaneFruits = tag.GetInt("arcaneFruits");
            mysteriousFossils = tag.GetInt("mysteriousFossils");
            extendedLungs = tag.GetBool("extendedLungs");
            base.Load(tag);
        }
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
            if (player.ZoneRockLayerHeight)
                if (Main.rand.NextBool(10))
                    switch (Main.rand.Next(6))
                    {
                        case 0:
                            caughtType = ItemID.BandofRegeneration;
                            break;
                        case 1:
                            caughtType = ItemID.MagicMirror;
                            break;
                        case 2:
                            caughtType = ItemID.CloudinaBottle;
                            break;
                        case 3:
                            caughtType = ItemID.HermesBoots;
                            break;
                        case 4:
                            caughtType = ItemID.EnchantedBoomerang;
                            break;
                        case 5:
                            caughtType = ItemID.ShoeSpikes;
                            break;
                    }
            base.CatchFish(fishingRod, bait, power, liquidType, poolSize, worldLayer, questFish, ref caughtType, ref junk);
        }
    }
}
