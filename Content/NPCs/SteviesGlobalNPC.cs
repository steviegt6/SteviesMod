using Microsoft.Xna.Framework;
using SteviesMod.Content.Items.Consumables.Upgrades;
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
                    if (Main.rand.NextBool(100) && !player.GetModPlayer<SteviesModPlayer>().extendedLungs)
                    {
                        Item.NewItem(player.position, ModContent.ItemType<LungExtensionCard>(), 1, false, 0, true);
                        chat = "Shh! Don't tell anyone I handed you this card.";
                    }
                    break;
            }
            CombatText.NewText(npc.Hitbox, Color.White, chat);
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
                        if (Main.player[Main.myPlayer].HasItem(ItemID.SilverBullet)) //pretty ghetto way of doing this but eh
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
                    if (Main.rand.Next(150) == 0)
                        Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Weapons.Melee.Shortswords.BoneKnife>());
                    break;
            }
            base.NPCLoot(npc);
        }
    }
}
