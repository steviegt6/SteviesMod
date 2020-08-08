using Microsoft.Xna.Framework;
using SteviesMod.Content.Items.Consumables;
using SteviesMod.Content.Items.Weapons.Melee.Swords;
using SteviesMod.Content.Items.Weapons.Ranged.Bullets;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.NPCs
{
    public class SteviesGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public override void OnChatButtonClicked(NPC npc, bool firstButton)
        {
            switch (npc.type)
            {
                case NPCID.Angler:
                    if (!firstButton)
                    {
                        Main.playerInventory = true;
                        Main.npcChatText = "";
                        Main.npcShop = Main.MaxShopIDs - 1;
                        Main.instance.shop[Main.npcShop].SetupShop(NPCID.Angler);
                        Main.PlaySound(SoundID.MenuTick);
                    }
                    break;
            }
        }

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            Player player = Main.LocalPlayer;

            switch (type)
            {
                case NPCID.Angler:
                    if (SteviesModConfig.Instance.anglerQuestWall)
                    {
                        if (player.anglerQuestsFinished >= 5)
                        {
                            shop.item[nextSlot].SetDefaults(ItemID.FuzzyCarrot);
                            nextSlot++;
                        }

                        if (player.anglerQuestsFinished >= 10)
                        {
                            shop.item[nextSlot].SetDefaults(ItemID.AnglerHat);
                            nextSlot++;

                            if (Main.hardMode)
                            {
                                shop.item[nextSlot].SetDefaults(ItemID.FinWings);
                                nextSlot++;
                                shop.item[nextSlot].SetDefaults(ItemID.BottomlessBucket);
                                nextSlot++;
                                shop.item[nextSlot].SetDefaults(ModContent.ItemType<BottomlessLavaBucket>());
                                nextSlot++;
                                shop.item[nextSlot].SetDefaults(ModContent.ItemType<BottomlessHoneyBucket>());
                                nextSlot++;
                                shop.item[nextSlot].SetDefaults(ItemID.SuperAbsorbantSponge);
                                nextSlot++;
                            }
                        }

                        if (player.anglerQuestsFinished >= 15)
                        {
                            shop.item[nextSlot].SetDefaults(ItemID.AnglerVest);
                            nextSlot++;
                        }

                        if (player.anglerQuestsFinished >= 20)
                        {
                            shop.item[nextSlot].SetDefaults(ItemID.AnglerPants);
                            nextSlot++;
                        }

                        if (player.anglerQuestsFinished >= 25)
                        {
                            shop.item[nextSlot].SetDefaults(ItemID.HotlineFishingHook);
                            nextSlot++;
                        }

                        if (player.anglerQuestsFinished >= 30)
                        {
                            shop.item[nextSlot].SetDefaults(ItemID.GoldenFishingRod);
                            nextSlot++;
                        }
                    }
                    else
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.FuzzyCarrot);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ItemID.AnglerHat);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ItemID.FinWings);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ItemID.BottomlessBucket);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<BottomlessLavaBucket>());
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ModContent.ItemType<BottomlessHoneyBucket>());
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ItemID.SuperAbsorbantSponge);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ItemID.AnglerVest);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ItemID.AnglerPants);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ItemID.HotlineFishingHook);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ItemID.GoldenFishingRod);
                        nextSlot++;
                    }

                    shop.item[nextSlot].SetDefaults(ItemID.GoldenBugNet);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.FishHook);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.HighTestFishingLine);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.AnglerEarring);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.TackleBox);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.FishermansGuide);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.WeatherRadio);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.Sextant);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.SeashellHairpin);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.MermaidAdornment);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.MermaidTail);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.FishCostumeMask);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.FishCostumeShirt);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.FishCostumeFinskirt);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.LifePreserver);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.ShipsWheel);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.CompassRose);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.WallAnchor);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.PillaginMePixels);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.TreasureMap);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.GoldfishTrophy);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.BunnyfishTrophy);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.SwordfishTrophy);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.SharkteethTrophy);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.ShipInABottle);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.SeaweedPlanter);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.FishingPotion);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.SonarPotion);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.CratePotion);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.ApprenticeBait);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.JourneymanBait);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.MasterBait); //funny haha lololololololool shut tupgtitrijtr
                    nextSlot++;

                    break;
            }
        }

        public override void GetChat(NPC npc, ref string chat)
        {
            Player player = Main.LocalPlayer;
            switch (npc.type)
            {
                case NPCID.Nurse:
                    if (Main.rand.NextBool(100) && !player.GetModPlayer<SteviesModPlayer>().extendedLungs && !Main.player[Main.myPlayer].HasItem(ModContent.ItemType<LungExtensionCard>()))
                    {
                        Item.NewItem(player.position, ModContent.ItemType<LungExtensionCard>(), 1, false, 0, true);
                        chat = "Shh! Don't tell anyone I handed you this card.";
                    }
                    break;
            }

            if (SteviesModConfig.Instance.npcText)
            {
                CombatText.NewText(npc.Hitbox, Color.White, chat);
            }
        }

#pragma warning disable IDE0059 // Unnecessary assignment of a value

        public override void OnHitByItem(NPC npc, Player player, Item item, int damage, float knockback, bool crit)
        {
            if (npc.type == NPCID.Werewolf)
            {
                switch (item.type)
                {
                    case ItemID.SilverAxe:
                    case ItemID.SilverBroadsword:
                    case ItemID.SilverHammer:
                    case ItemID.SilverPickaxe:
                    case ItemID.SilverShortsword:
                        damage *= 2;
                        break;
                }
            }
        }

        public override void OnHitByProjectile(NPC npc, Projectile projectile, int damage, float knockback, bool crit)
        {
            if (npc.type == NPCID.Werewolf)
            {
                switch (projectile.type)
                {
                    case ProjectileID.SilverCoin:
                    case ProjectileID.SapphireBolt:
                        damage *= 2;
                        break;

                    case ProjectileID.Bullet:
                        //pretty poor way of doing this but eh
                        if (Main.player[Main.myPlayer].HasItem(ItemID.SilverBullet) || Main.player[Main.myPlayer].HasItem(ModContent.ItemType<EndlessSilverPouch>()))
                        {
                            damage *= 2;
                        }

                        break;
                }
            }
        }

#pragma warning restore IDE0059 // Unnecessary assignment of a value

        public override void NPCLoot(NPC npc)
        {
            switch (npc.type)
            {
                case NPCID.Skeleton:
                case NPCID.SmallSkeleton:
                case NPCID.BigSkeleton:
                case NPCID.HeadacheSkeleton:
                case NPCID.SmallHeadacheSkeleton:
                case NPCID.BigHeadacheSkeleton:
                case NPCID.MisassembledSkeleton:
                case NPCID.SmallMisassembledSkeleton:
                case NPCID.BigMisassembledSkeleton:
                case NPCID.SkeletonTopHat:
                case NPCID.SkeletonAstonaut:
                case NPCID.SkeletonAlien:
                    if (Main.rand.NextBool(150))
                    {
                        Item.NewItem(npc.getRect(), ModContent.ItemType<BoneKnife>());
                    }
                    break;

                case NPCID.ChaosElemental:
                    if (Main.rand.NextBool(5))
                    {
                        Item.NewItem(npc.getRect(), ModContent.ItemType<DiscofDiscord>(), Main.rand.Next(2, 5));
                    }

                    break;
            }
        }
    }
}