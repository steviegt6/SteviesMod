using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items
{
    public class SteviesGlobalItem : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            SpecialEffectsGlobalItem globalItem = item.GetGlobalItem<SpecialEffectsGlobalItem>();

            TooltipLine shiftForMore = new TooltipLine(mod, $"{mod.Name}:ShiftForMore", "Hold shift for more info.")
            {
                overrideColor = Color.Gray
            };
            TooltipLine effectsTooltip = new TooltipLine(mod, $"{mod.Name}:EffectsTooltip", "")
            {
                overrideColor = Color.LightGray
            };

            if (globalItem.ItemEffects != "" && globalItem.ItemEffects != "No extra info to display!")
            {
                effectsTooltip.text = globalItem.ItemEffects;

                if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift))
                {
                    tooltips.Remove(shiftForMore);
                    tooltips.Add(effectsTooltip);
                }
                else
                {
                    tooltips.Remove(effectsTooltip);
                    tooltips.Add(shiftForMore);
                }
            }
        }

        public override void SetDefaults(Item item)
        {
            SpecialEffectsGlobalItem globalItem = item.GetGlobalItem<SpecialEffectsGlobalItem>();

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

                case ItemID.IronPickaxe:
                    globalItem.ItemEffects = "Test Effect #1" +
                        "\nTest Effect #2";
                    break;

                case ItemID.CopperPickaxe:
                    globalItem.ItemEffects = "Test Effect #3" +
                        "\nTest Effect #4";
                    break;

                default:
                    globalItem.ItemEffects = "No extra info to display!";
                    break;
            }
        }
    }

    public class SpecialEffectsGlobalItem : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override bool CloneNewInstances => true;

        internal string ItemEffects = "";
    }
}