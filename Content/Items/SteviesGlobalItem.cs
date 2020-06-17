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
                case ItemID.WoodenSword:
                    foreach (TooltipLine line in tooltips)
                        if (line.mod == "Terraria" && line.Name == "ItemName")
                            line.text = "Wooden Broadsword";
                    break;
                case ItemID.TitaniumSword:
                    foreach (TooltipLine line in tooltips)
                        if (line.mod == "Terraria" && line.Name == "ItemName")
                            line.text = "Titanium Broadsword";
                    break;
                case ItemID.ShadewoodSword:
                    foreach (TooltipLine line in tooltips)
                        if (line.mod == "Terraria" && line.Name == "ItemName")
                            line.text = "Shadewood Broadsword";
                    break;
                case ItemID.RichMahoganySword:
                    foreach (TooltipLine line in tooltips)
                        if (line.mod == "Terraria" && line.Name == "ItemName")
                            line.text = "Rich Mahogany Broadsword";
                    break;
                case ItemID.PearlwoodSword:
                    foreach (TooltipLine line in tooltips)
                        if (line.mod == "Terraria" && line.Name == "ItemName")
                            line.text = "Pearlwood Broadsword";
                    break;
                case ItemID.PalmWoodSword:
                    foreach (TooltipLine line in tooltips)
                        if (line.mod == "Terraria" && line.Name == "ItemName")
                            line.text = "Palm Wood Broadsword";
                    break;
                case ItemID.PalladiumSword:
                    foreach (TooltipLine line in tooltips)
                        if (line.mod == "Terraria" && line.Name == "ItemName")
                            line.text = "Palladium Broadsword";
                    break;
                case ItemID.OrichalcumSword:
                    foreach (TooltipLine line in tooltips)
                        if (line.mod == "Terraria" && line.Name == "ItemName")
                            line.text = "Orichalcum Broadsword";
                    break;
                case ItemID.MythrilSword:
                    foreach (TooltipLine line in tooltips)
                        if (line.mod == "Terraria" && line.Name == "ItemName")
                            line.text = "Mythril Broadsword";
                    break;
                case ItemID.EbonwoodSword:
                    foreach (TooltipLine line in tooltips)
                        if (line.mod == "Terraria" && line.Name == "ItemName")
                            line.text = "Ebonwood Broadsword";
                    break;
                case ItemID.CobaltSword:
                    foreach (TooltipLine line in tooltips)
                        if (line.mod == "Terraria" && line.Name == "ItemName")
                            line.text = "Cobalt Broadsword";
                    break;
                case ItemID.CactusSword:
                    foreach (TooltipLine line in tooltips)
                        if (line.mod == "Terraria" && line.Name == "ItemName")
                            line.text = "Cactus Broadsword";
                    break;
                case ItemID.BorealWoodSword:
                    foreach (TooltipLine line in tooltips)
                        if (line.mod == "Terraria" && line.Name == "ItemName")
                            line.text = "Boreal Wood Broadsword";
                    break;
                case ItemID.AdamantiteSword:
                    foreach (TooltipLine line in tooltips)
                        if (line.mod == "Terraria" && line.Name == "ItemName")
                            line.text = "Adamantite Broadsword";
                    break;

            }
            base.ModifyTooltips(item, tooltips);
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
