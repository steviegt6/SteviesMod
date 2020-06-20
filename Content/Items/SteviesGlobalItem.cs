using SteviesMod.Content.Items.Consumables.Upgrades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items
{
    public class SteviesGlobalItem : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            switch (item.type)
            {
            }
            base.ModifyTooltips(item, tooltips);
        }
        public override void SetDefaults(Item item)
        {
            switch (item.type)
            {
                case ItemID.WoodenSword:
                    item.SetNameOverride("Wooden Broadsword");
                    break;
                case ItemID.TitaniumSword:
                    item.SetNameOverride("Titanium Broadsword");
                    break;
                case ItemID.ShadewoodSword:
                    item.SetNameOverride("Shadewood Broadsword");
                    break;
                case ItemID.RichMahoganySword:
                    item.SetNameOverride("Rich Mahogany Broadsword");
                    break;
                case ItemID.PearlwoodSword:
                    item.SetNameOverride("Pearlwood Broadsword");
                    break;
                case ItemID.PalmWoodSword:
                    item.SetNameOverride("Palm Wood Broadsword");
                    break;
                case ItemID.PalladiumSword:
                    item.SetNameOverride("Palladium Broadsword");
                    break;
                case ItemID.OrichalcumSword:
                    item.SetNameOverride("Orichalcum Broadsword");
                    break;
                case ItemID.MythrilSword:
                    item.SetNameOverride("Mythril Broadsword");
                    break;
                case ItemID.EbonwoodSword:
                    item.SetNameOverride("Ebonwood Broadsword");
                    break;
                case ItemID.CobaltSword:
                    item.SetNameOverride("Cobalt Broadsword");
                    break;
                case ItemID.CactusSword:
                    item.SetNameOverride("Cactus Broadsword");
                    break;
                case ItemID.BorealWoodSword:
                    item.SetNameOverride("Boreal Broadsword");
                    break;
                case ItemID.AdamantiteSword:
                    item.SetNameOverride("Adamantite Broadsword");
                    break;
                case ItemID.EndlessQuiver:
                    item.rare = ItemRarityID.White;
                    item.SetNameOverride("Endless Wooden Quiver");
                    break;
                case ItemID.EndlessMusketPouch:
                    item.rare = ItemRarityID.White;
                    break;
            }
            base.SetDefaults(item);
        }
        public override void ExtractinatorUse(int extractType, ref int resultType, ref int resultStack)
        {
            int result = 0;
            int stack = 1;
            switch (extractType)
            {
                case ItemID.DesertFossil:
                    if (Main.rand.Next(750) == 0)
                    {
                        stack = 1;
                        result = ModContent.ItemType<MysteriousFossil>();
                    }
                    break;
            }
            if (result > 0)
            {
                resultType = result;
                resultStack = stack;
            }
            base.ExtractinatorUse(extractType, ref resultType, ref resultStack);
        }
    }
}
