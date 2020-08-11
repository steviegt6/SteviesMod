using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SteviesMod.Content.Items.Weapons.Melee.Swords;
using SteviesMod.Content.Projectiles;
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
        private float HeightOffsetHitboxCenter
        {
            get
            {
                if (Main.player[Main.myPlayer].mount.Active)
                {
                    return Main.player[Main.myPlayer].mount.PlayerOffsetHitbox;
                }
                return 0f;
            }
        }

        private Vector2 MountedCenter
        {
            get
            {
                return new Vector2(Main.player[Main.myPlayer].position.X + (float)(Main.player[Main.myPlayer].width / 2), Main.player[Main.myPlayer].position.Y + 21f + HeightOffsetHitboxCenter);
            }
            set
            {
                Main.player[Main.myPlayer].position = new Vector2(value.X - (float)(Main.player[Main.myPlayer].width / 2), value.Y - 21f - HeightOffsetHitboxCenter);
            }
        }

        private Vector2 RotatedRelativePoint(Vector2 pos, bool reverseRotation = false, bool addGfxOffY = true)
        {
            float num = reverseRotation ? (0f - Main.player[Main.myPlayer].fullRotation) : Main.player[Main.myPlayer].fullRotation;
            Vector2 vector = Main.player[Main.myPlayer].Bottom + new Vector2(0f, Main.player[Main.myPlayer].gfxOffY);
            int num2 = Main.player[Main.myPlayer].mount.PlayerOffset / 2 + 4;
            Vector2 value = new Vector2(0f, -num2) + new Vector2(0f, num2).RotatedBy(num);
            if (addGfxOffY)
            {
                pos.Y += Main.player[Main.myPlayer].gfxOffY;
            }
            pos = vector + (pos - vector).RotatedBy(num) + value;
            return pos;
        }

        private static List<int> shortswords = new List<int>
        {
            ItemID.CopperShortsword,
            ItemID.TinShortsword,
            ItemID.IronShortsword,
            ItemID.LeadShortsword,
            ItemID.SilverShortsword,
            ItemID.TungstenShortsword,
            ItemID.GoldShortsword,
            ItemID.PlatinumShortsword,
            ModContent.ItemType<AdamantiteShortsword>(),
            ModContent.ItemType<BloodPusher>(),
            ModContent.ItemType<BoneKnife>(),
            ModContent.ItemType<BorealWoodShortsword>(),
            ModContent.ItemType<CactusShortsword>(),
            ModContent.ItemType<CobaltShortsword>(),
            ModContent.ItemType<EbonwoodShortsword>(),
            ModContent.ItemType<LightsShame>(),
            ModContent.ItemType<MythrilShortsword>(),
            ModContent.ItemType<OrichalcumShortsword>(),
            ModContent.ItemType<PalladiumShortsword>(),
            ModContent.ItemType<PalmWoodShortsword>(),
            ModContent.ItemType<PearlwoodShortsword>(),
            ModContent.ItemType<RichMahoganyShortsword>(),
            ModContent.ItemType<ShadewoodShortsword>(),
            ModContent.ItemType<TitaniumShortsword>(),
            ModContent.ItemType<WoodenShortsword>()
        };

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            SpecialEffectsGlobalItem globalItem = item.GetGlobalItem<SpecialEffectsGlobalItem>();

            TooltipLine shiftForMore = new TooltipLine(mod, $"{mod.Name}:ShiftForMore", "Hold shift for more info.")
            {
                overrideColor = Color.DarkGray
            };

            TooltipLine effectsTooltip = new TooltipLine(mod, $"{mod.Name}:EffectsTooltip", "")
            {
                overrideColor = Color.LightGray
            };

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

                case ItemID.CopperShortsword:
                    SetShortswordDefaults(item, ModContent.ProjectileType<CopperShortswordProj>());
                    globalItem.ItemEffects = "1 armor penetration";
                    break;

                case ItemID.TinShortsword:
                    SetShortswordDefaults(item, ModContent.ProjectileType<TinShortswordProj>());
                    globalItem.ItemEffects = "1 armor penetration";
                    break;

                case ItemID.IronShortsword:
                    SetShortswordDefaults(item, ModContent.ProjectileType<IronShortswordProj>());
                    globalItem.ItemEffects = "2 armor penetration";
                    break;

                case ItemID.LeadShortsword:
                    SetShortswordDefaults(item, ModContent.ProjectileType<LeadShortswordProj>());
                    globalItem.ItemEffects = "2 armor penetration";
                    break;

                case ItemID.SilverShortsword:
                    SetShortswordDefaults(item, ModContent.ProjectileType<SilverShortswordProj>());
                    globalItem.ItemEffects = "3 armor penetration";
                    break;

                case ItemID.TungstenShortsword:
                    SetShortswordDefaults(item, ModContent.ProjectileType<TungstenShortswordProj>());
                    globalItem.ItemEffects = "3 armor penetration";
                    break;

                case ItemID.GoldShortsword:
                    SetShortswordDefaults(item, ModContent.ProjectileType<GoldShortswordProj>());
                    globalItem.ItemEffects = "4 armor penetration";
                    break;

                case ItemID.PlatinumShortsword:
                    SetShortswordDefaults(item, ModContent.ProjectileType<PlatinumShortswordProj>());
                    globalItem.ItemEffects = "4 armor penetration";
                    break;

                default:
                    globalItem.ItemEffects = "No extra info to display!";
                    break;
            }

            if (item.type == ModContent.ItemType<CobaltShortsword>() || item.type == ModContent.ItemType<PalladiumShortsword>())
            {
                globalItem.ItemEffects = "5 armor penetration";
            }

            if (item.type == ModContent.ItemType<MythrilShortsword>() || item.type == ModContent.ItemType<OrichalcumShortsword>())
            {
                globalItem.ItemEffects = "10 armor penetration";
            }

            if (item.type == ModContent.ItemType<AdamantiteShortsword>() || item.type == ModContent.ItemType<TitaniumShortsword>())
            {
                globalItem.ItemEffects = "15 armor penetration";
            }
        }

        public override void HoldItem(Item item, Player player)
        {
            switch (item.type)
            {
                case ItemID.CopperShortsword:
                    player.armorPenetration++;
                    break;

                case ItemID.TinShortsword:
                    player.armorPenetration++;
                    break;

                case ItemID.IronShortsword:
                    player.armorPenetration += 2;
                    break;

                case ItemID.LeadShortsword:
                    player.armorPenetration += 2;
                    break;

                case ItemID.SilverShortsword:
                    player.armorPenetration += 3;
                    break;

                case ItemID.TungstenShortsword:
                    player.armorPenetration += 3;
                    break;

                case ItemID.GoldShortsword:
                    player.armorPenetration += 4;
                    break;

                case ItemID.PlatinumShortsword:
                    player.armorPenetration += 4;
                    break;
            }
        }

        public static void SetShortswordDefaults(Item item, int projectile)
        {
            item.useStyle = 5;
            item.shoot = projectile;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.melee = true;
            item.shootSpeed = 2.1f;
            item.useTurn = false;
        }

        public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            bool canShoot = item.useAmmo <= 0 && (item.type < ItemID.CopperCoin || item.type > ItemID.PlatinumCoin);

            if (canShoot && shortswords.Contains(item.type))
            {
                Main.player[Main.myPlayer].itemRotation = (float)Math.Atan2((float)Main.mouseY + Main.screenPosition.Y - RotatedRelativePoint(MountedCenter, reverseRotation: true).Y * (float)Main.player[Main.myPlayer].direction, (float)Main.mouseX + Main.screenPosition.X - RotatedRelativePoint(MountedCenter, reverseRotation: true).X * (float)Main.player[Main.myPlayer].direction) - Main.player[Main.myPlayer].fullRotation;
                NetMessage.SendData(MessageID.PlayerControls, -1, -1, null, Main.player[Main.myPlayer].whoAmI);
                NetMessage.SendData(MessageID.ItemAnimation, -1, -1, null, Main.player[Main.myPlayer].whoAmI);
            }
            else if (shortswords.Contains(item.type))
            {
                player.itemRotation = 0f;
            }

            return base.Shoot(item, player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }

        /*public override void UseStyle(Item item, Player player)
        {
            int useAnimation = player.itemAnimationMax;
            int itemTimeMax = player.itemTime;

            if (itemTimeMax != 0)
            {
                useAnimation = itemTimeMax;
            }
            if (useAnimation == 0)
            {
                useAnimation = item.useAnimation;
            }
            float num21 = 1f - (float)(player.itemAnimation % useAnimation) / (float)useAnimation;
            CompositeArmStretchAmount stretch = CompositeArmStretchAmount.Quarter;
            if (num21 > 0.33f && num21 <= 0.66f)
            {
                stretch = CompositeArmStretchAmount.ThreeQuarters;
            }
            if (num21 > 0.66f && num21 <= 1f)
            {
                stretch = CompositeArmStretchAmount.Full;
            }
            float rotation = player.itemRotation - (float)Math.PI / 2f * (float)player.direction;
            SetCompositeArmFront(enabled: true, stretch, rotation);
        }*/
    }

    public class SpecialEffectsGlobalItem : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override bool CloneNewInstances => true;

        internal string ItemEffects = "";
    }
}