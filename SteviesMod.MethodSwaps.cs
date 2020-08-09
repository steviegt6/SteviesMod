using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria.ModLoader;
using Terraria;
using TomatoLib.Core.Utils.Lang;

namespace SteviesMod
{
    //TODO: Clean up method swap code.
    //TODO: Adjust Mana Star draw hover code.
    public partial class SteviesMod : Mod
    {
        private void InitializeMethodSwaps()
        {
            On.Terraria.Main.DrawInterface_Resources_Mana += Main_DrawInterface_Resources_Mana;
            On.Terraria.Main.DrawInterface_Resources_Breath += Main_DrawInterface_Resources_Breath;
        }

        private void Main_DrawInterface_Resources_Breath(On.Terraria.Main.orig_DrawInterface_Resources_Breath orig)
        {
            bool flag = false;

            Player player = Main.player[Main.myPlayer];

            if (player.dead)
            {
                return;
            }

            if (player.lavaTime < player.lavaMax && player.lavaWet)
            {
                flag = true;
            }
            else if (player.lavaTime < player.lavaMax && player.breath == player.breathMax)
            {
                flag = true;
            }

            Vector2 value = player.Top + new Vector2(0f, player.gfxOffY);

            if (Main.playerInventory && Main.screenHeight < 1000)
            {
                value.Y += Main.player[Main.myPlayer].height - 20;
            }

            value = Vector2.Transform(value - Main.screenPosition, Main.GameViewMatrix.ZoomMatrix);

            if (!Main.playerInventory || Main.screenHeight >= 1000)
            {
                value.Y -= 100f;
            }

            value /= Main.UIScale;

            if (Main.ingameOptionsWindow || Main.InGameUI.IsVisible)
            {
                value = new Vector2(Main.screenWidth / 2, Main.screenHeight / 2 + 236);
            }

            if (Main.InGameUI.IsVisible)
            {
                value.Y = Main.screenHeight - 64;
            }

            if (Main.player[Main.myPlayer].breath < Main.player[Main.myPlayer].breathMax && !Main.player[Main.myPlayer].ghost && !flag)
            {
                _ = Main.player[Main.myPlayer].breathMax / 20;
                int num19 = Main.player[Main.myPlayer].breathMax / 10;
                for (int j = 1; j < Main.player[Main.myPlayer].breathMax / num19 + 1; j++)
                {
                    float num24 = 1f;
                    int num25;

                    if (player.breath >= j * num19)
                    {
                        num25 = 255;
                    }
                    else
                    {
                        float num22 = (float)(player.breath - (j - 1) * num19) / num19;

                        num25 = (int)(30f + 225f * num22);

                        if (num25 < 30)
                        {
                            num25 = 30;
                        }

                        num24 = num22 / 4f + 0.75f;

                        if (num24 < 0.75)
                        {
                            num24 = 0.75f;
                        }
                    }

                    int num21 = 0;
                    int num20 = 0;

                    if (j > 10)
                    {
                        num21 -= 260;
                        num20 += 26;
                    }

                    if (player.GetModPlayer<SteviesModPlayer>().extendedLungs)
                    {
                        Main.spriteBatch.Draw(GetTexture("UI/BubbleOverlay"), value + new Vector2((26 * (j - 1) + num21) - 125f, 32f + (Main.bubbleTexture.Height - Main.bubbleTexture.Height * num24) / 2f + num20), new Rectangle(0, 0, Main.bubbleTexture.Width, Main.bubbleTexture.Height), new Color(num25, num25, num25, num25), 0f, default, num24, SpriteEffects.None, 0f);
                    }
                    else
                    {
                        Main.spriteBatch.Draw(Main.bubbleTexture, value + new Vector2(26 * (j - 1) + num21 - 125f, 32f + (Main.bubbleTexture.Height - Main.bubbleTexture.Height * num24) / 2f + num20), new Rectangle(0, 0, Main.bubbleTexture.Width, Main.bubbleTexture.Height), new Color(num25, num25, num25, num25), 0f, default, num24, SpriteEffects.None, 0f);
                    }
                }
            }
            if (!((player.lavaTime < player.lavaMax && !player.ghost) & flag))
            {
                return;
            }

            int num18 = player.lavaMax / 10;
            _ = player.breathMax / num18;

            for (int i = 1; i < player.lavaMax / num18 + 1; i++)
            {
                float num16 = 1f;
                int num17;

                if (player.lavaTime >= i * num18)
                {
                    num17 = 255;
                }
                else
                {
                    float num14 = (float)(player.lavaTime - (i - 1) * num18) / num18;
                    num17 = (int)(30f + 225f * num14);

                    if (num17 < 30)
                    {
                        num17 = 30;
                    }

                    num16 = num14 / 4f + 0.75f;

                    if (num16 < 0.75)
                    {
                        num16 = 0.75f;
                    }
                }

                int num13 = 0;
                int num12 = 0;

                if (i > 10)
                {
                    num13 -= 260;
                    num12 += 26;
                }

                Main.spriteBatch.Draw(Main.flameTexture, value + new Vector2(26 * (i - 1) + num13 - 125f, 32f + (Main.flameTexture.Height - Main.flameTexture.Height * num16) / 2f + num12), new Rectangle(0, 0, Main.bubbleTexture.Width, Main.bubbleTexture.Height), new Color(num17, num17, num17, num17), 0f, default, num16, SpriteEffects.None, 0f);
            }
        }

        private void Main_DrawInterface_Resources_Mana(On.Terraria.Main.orig_DrawInterface_Resources_Mana orig)
        {
            if (Main.player[Main.myPlayer].statManaMax2 / 10 >= 20)
            {
                UIDisplay_ManaPerStar = Main.player[Main.myPlayer].statManaMax2 / 10;
            }
            else
            {
                UIDisplay_ManaPerStar = 20;
            }

            if (Main.LocalPlayer.ghost || Main.player[Main.myPlayer].statManaMax2 <= 0)
            {
                return;
            }

            _ = Main.player[Main.myPlayer].statManaMax / 20;
            int num17 = Main.player[Main.myPlayer].GetModPlayer<SteviesModPlayer>().arcaneFruits;
            if (num17 < 0)
            {
                num17 = 0;
            }
            if (num17 > 0)
            {
                _ = Main.player[Main.myPlayer].statManaMax / (20 + num17 / 4);
            }
            _ = Main.player[Main.myPlayer].statManaMax2 / 20;
            Vector2 vector = Main.fontMouseText.MeasureString(LangAndLocalization.GetLegacyInterface(2).Value);
            int num8 = 50;
            if (vector.X >= 45f)
            {
                num8 = (int)vector.X + 5;
            }
            DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, Main.fontMouseText, LangAndLocalization.GetLegacyInterface(2).Value, new Vector2(800 - num8 + UI_ScreenAnchorX, 6f), new Color(Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor), 0f, default, 1f, SpriteEffects.None, 0f);
            if (UIDisplay_ManaPerStar <= 20)
            {
                for (int i = 1; i < Main.player[Main.myPlayer].statManaMax2 / UIDisplay_ManaPerStar + 1; i++)
                {
                    bool flag = false;
                    float num6 = 1f;
                    int num7;
                    if (Main.player[Main.myPlayer].statMana >= i * UIDisplay_ManaPerStar)
                    {
                        num7 = 255;
                        if (Main.player[Main.myPlayer].statMana == i * UIDisplay_ManaPerStar)
                        {
                            flag = true;
                        }
                    }
                    else
                    {
                        float num4 = (Main.player[Main.myPlayer].statMana - (i - 1) * UIDisplay_ManaPerStar) / (float)UIDisplay_ManaPerStar;
                        num7 = (int)(30f + 225f * num4);
                        if (num7 < 30)
                        {
                            num7 = 30;
                        }
                        num6 = num4 / 4f + 0.75f;
                        if (num6 < 0.75)
                        {
                            num6 = 0.75f;
                        }
                        if (num4 > 0f)
                        {
                            flag = true;
                        }
                    }
                    if (flag)
                    {
                        num6 += Main.cursorScale - 1f;
                    }
                    int a = (int)((float)num7 * 0.9);
                    if (!Main.player[Main.myPlayer].ghost)
                    {
                        if (num17 > 0)
                        {
                            num17--;
                            Main.spriteBatch.Draw(GetTexture("UI/ManaOverlay"), new Vector2(775 + UI_ScreenAnchorX, 30 + Main.manaTexture.Height / 2 + (Main.manaTexture.Height - Main.manaTexture.Height * num6) / 2f + 28 * (i - 1)), new Rectangle(0, 0, Main.manaTexture.Width, Main.manaTexture.Height), new Color(num7, num7, num7, a), 0f, new Vector2(Main.manaTexture.Width / 2, Main.manaTexture.Height / 2), num6, SpriteEffects.None, 0f);
                        }
                        else
                        {
                            Main.spriteBatch.Draw(Main.manaTexture, new Vector2(775 + UI_ScreenAnchorX, 30 + Main.manaTexture.Height / 2 + (Main.manaTexture.Height - Main.manaTexture.Height * num6) / 2f + 28 * (i - 1)), new Rectangle(0, 0, Main.manaTexture.Width, Main.manaTexture.Height), new Color(num7, num7, num7, a), 0f, new Vector2(Main.manaTexture.Width / 2, Main.manaTexture.Height / 2), num6, SpriteEffects.None, 0f);
                        }
                    }
                }
            }
            else if (UIDisplay_ManaPerStar > 20)
            {
                for (int i = 1; i < Main.player[Main.myPlayer].statManaMax2 / UIDisplay_ManaPerStar + 1; i++)
                {
                    bool flag = false;
                    float num6 = 1f;
                    int num7;
                    if (Main.player[Main.myPlayer].statMana >= i * UIDisplay_ManaPerStar)
                    {
                        num7 = 255;
                        if (Main.player[Main.myPlayer].statMana == i * UIDisplay_ManaPerStar)
                        {
                            flag = true;
                        }
                    }
                    else
                    {
                        float num4 = (Main.player[Main.myPlayer].statMana - (i - 1) * UIDisplay_ManaPerStar) / (float)UIDisplay_ManaPerStar;
                        num7 = (int)(30f + 225f * num4);
                        if (num7 < 30)
                        {
                            num7 = 30;
                        }
                        num6 = num4 / 4f + 0.75f;
                        if (num6 < 0.75)
                        {
                            num6 = 0.75f;
                        }
                        if (num4 > 0f)
                        {
                            flag = true;
                        }
                    }
                    if (flag)
                    {
                        num6 += Main.cursorScale - 1f;
                    }
                    int a = (int)((float)num7 * 0.9);
                    if (!Main.player[Main.myPlayer].ghost)
                    {
                        if (num17 > 0)
                        {
                            num17--;
                            Main.spriteBatch.Draw(GetTexture("UI/ManaOverlay"), new Vector2(775 + UI_ScreenAnchorX, 30 + Main.manaTexture.Height / 2 + (Main.manaTexture.Height - Main.manaTexture.Height * num6) / 2f + 28 * (i - 1)), new Rectangle(0, 0, Main.manaTexture.Width, Main.manaTexture.Height), new Color(num7, num7, num7, a), 0f, new Vector2(Main.manaTexture.Width / 2, Main.manaTexture.Height / 2), num6, SpriteEffects.None, 0f);
                        }
                        else
                        {
                            Main.spriteBatch.Draw(Main.manaTexture, new Vector2(775 + UI_ScreenAnchorX, 30 + Main.manaTexture.Height / 2 + (Main.manaTexture.Height - Main.manaTexture.Height * num6) / 2f + 28 * (i - 1)), new Rectangle(0, 0, Main.manaTexture.Width, Main.manaTexture.Height), new Color(num7, num7, num7, a), 0f, new Vector2(Main.manaTexture.Width / 2, Main.manaTexture.Height / 2), num6, SpriteEffects.None, 0f);
                        }
                    }
                }
            }
        }
    }
}