using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace SteviesMod
{
    public class SteviesModPlayer : ModPlayer
    {
        public int arcaneFruits;
        public bool extendedLungs;
        public static SteviesModPlayer Instance;

        public override void ResetEffects()
        {
            player.statManaMax2 += 5 * arcaneFruits;

            if (extendedLungs)
            {
                player.breathMax = 300;
            }
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = mod.GetPacket();
            packet.Write(arcaneFruits);
            packet.Write(extendedLungs);
            packet.Send(toWho, fromWho);
        }

        public override TagCompound Save()
        {
            return new TagCompound
            {
                { "arcaneFruits", arcaneFruits },
                { "extendedLungs", extendedLungs }
            };
        }

        public override void Load(TagCompound tag)
        {
            arcaneFruits = tag.GetInt("arcaneFruits");
            extendedLungs = tag.GetBool("extendedLungs");
        }

        public bool ZonePurity => !player.ZoneBeach
            && !player.ZoneCorrupt
            && !player.ZoneCrimson
            && !player.ZoneDesert
            && !player.ZoneDungeon
            && !player.ZoneGlowshroom
            && !player.ZoneHoly
            && !player.ZoneJungle
            && !player.ZoneOldOneArmy
            && !player.ZoneSnow
            && !player.ZoneUndergroundDesert;

        //Non-exact switch cases to help decrease the chance of catching something.
        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
        {
            if (!junk)
            {
                if ((player.ZoneDesert || player.ZoneUndergroundDesert) && Main.rand.NextBool(20))
                {
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
                }

                if (ZonePurity)
                {
                    if (Main.rand.NextBool(15))
                    {
                        switch (Main.rand.Next(8))
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
                    }
                }

                if (player.ZoneRockLayerHeight && Main.rand.NextBool(15))
                {
                    switch (Main.rand.Next(8))
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
                }
            }
        }

        public override void ModifyDrawLayers(List<PlayerLayer> layers)
        {
            if (Main.player[Main.myPlayer].HeldItem.type == ItemID.CopperShortsword)
            {
                layers.Remove(PlayerLayer.HeldItem);
            }
        }
    }
}