using Microsoft.Xna.Framework;
using SteviesMod.Content.Items.Consumables.OtherThrowing;
using SteviesMod.Content.Items.Consumables.Upgrades;
using SteviesMod.Content.Items.Weapons.Melee.Shortswords;
using SteviesMod.Content.Items.Weapons.Ranged.Bullets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.NPCs
{
    public class SteviesGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public bool switchBlueSlime = true;
        public override void AI(NPC npc)
        {
            switch (npc.type)
            {
                case NPCID.BlueSlime:
                    if (npc.netID == NPCID.BlueSlime && Main.rand.NextBool(15) && switchBlueSlime && Main.expertMode && NPC.downedSlimeKing)
                        npc.Transform(NPCID.SlimeSpiked);
                    break;
            }
            switchBlueSlime = false;
            base.AI(npc);
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
                CombatText.NewText(npc.Hitbox, Color.White, "What the fuck did you just fucking say about me, you little bitch?\n I'll have you know I graduated top of my class in the Navy Seals, and I've been involved in numerous secret raids on Al-Quaeda, and I have over 300 confirmed kills.\n I am trained in gorilla warfare and I'm the top sniper in the entire US armed forces.\n You are nothing to me but just another target.\n I will wipe you the fuck out with precision the likes of which has never been seen before on this Earth, mark my fucking words.\n You think you can get away with saying that shit to me over the Internet?\n Think again, fucker. As we speak I am contacting my secret network of spies across the USA and your IP is being traced right now so you better prepare for the storm, maggot.\n The storm that wipes out the pathetic little thing you call your life.\n You're fucking dead, kid.\n I can be anywhere, anytime, and I can kill you in over seven hundred ways, and that's just with my bare hands.\n Not only am I extensively trained in unarmed combat, but I have access to the entire arsenal of the United States Marine Corps and I will use it to its full extent to wipe your miserable ass off the face of the continent, you little shit.\n If only you could have known what unholy retribution your little \"clever\" comment was about to bring down upon you, maybe you would have held your fucking tongue.\n But you couldn't, you didn't, and now you're paying the price, you goddamn idiot.\n I will shit fury all over you and you will drown in it.\n You're fucking dead, kiddo.", false, true);
            base.GetChat(npc, ref chat);
        }
        public override void OnHitByItem(NPC npc, Player player, Item item, int damage, float knockback, bool crit)
        {
            if (npc.type == NPCID.Werewolf)
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
            base.OnHitByItem(npc, player, item, damage, knockback, crit);
        }
        public override void OnHitByProjectile(NPC npc, Projectile projectile, int damage, float knockback, bool crit)
        {
            if (npc.type == NPCID.Werewolf)
                switch (projectile.type)
                {
                    case ProjectileID.SilverCoin:
                    case ProjectileID.SapphireBolt:
                        damage *= 2;
                        break;

                    case ProjectileID.Bullet:
                        //pretty poor way of doing this but eh
                        if (Main.player[Main.myPlayer].HasItem(ItemID.SilverBullet) || Main.player[Main.myPlayer].HasItem(ModContent.ItemType<EndlessSilverPouch>()))
                            damage *= 2;
                                break;
                }
            base.OnHitByProjectile(npc, projectile, damage, knockback, crit);
        }
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
                        Item.NewItem(npc.getRect(), ModContent.ItemType<BoneKnife>());
                    break;

                case NPCID.GoblinArcher:
                case NPCID.GoblinPeon:
                case NPCID.GoblinScout:
                case NPCID.GoblinSorcerer:
                case NPCID.GoblinThief:
                    if (Main.rand.NextBool(250))
                        Item.NewItem(npc.getRect(), ModContent.ItemType<SpikyPouch>());
                    break;

                case NPCID.GoblinSummoner:
                    if (Main.rand.NextBool(150))
                        Item.NewItem(npc.getRect(), ModContent.ItemType<SpikyPouch>());
                    break;

                case NPCID.GoblinTinkerer:
                    if (Main.rand.NextBool(10))
                        Item.NewItem(npc.getRect(), ModContent.ItemType<SpikyPouch>());
                    break;
            }
            base.NPCLoot(npc);
        }
    }
}
