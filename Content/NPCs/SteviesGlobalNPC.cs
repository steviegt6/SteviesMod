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
