using System;
using System.Diagnostics;
using Terraria.ModLoader;
using Terraria;
using ReLogic.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.CompilerServices;
using System.IO;

namespace SteviesMod
{
	public class SteviesMod : Mod
	{
		private static int UI_ScreenAnchorX = Main.screenWidth - 800;
		private static int UIDisplay_ManaPerStar;
		public override void Load()
        {
            On.Terraria.Main.DrawInterface_Resources_Mana += NewDrawMana; //literally just recreate this method but adds onto it lmao
            base.Load();
        }

        private void NewDrawMana(On.Terraria.Main.orig_DrawInterface_Resources_Mana orig)
        {
			if (Main.player[Main.myPlayer].statManaMax2 / 10 >= 20)
				UIDisplay_ManaPerStar = Main.player[Main.myPlayer].statManaMax2 / 10;
			else
				UIDisplay_ManaPerStar = 20;
			if (Main.LocalPlayer.ghost || Main.player[Main.myPlayer].statManaMax2 <= 0)
			{
				return;
			}
			int num18 = Main.player[Main.myPlayer].statManaMax / 20;
			int num17 = Main.player[Main.myPlayer].GetModPlayer<SteviesModPlayer>().arcaneFruits;
			if (num17 < 0)
			{
				num17 = 0;
			}
			if (num17 > 0)
			{
				num18 = Main.player[Main.myPlayer].statManaMax / (20 + num17 / 4);
			}
			_ = Main.player[Main.myPlayer].statManaMax2 / 20;
			Microsoft.Xna.Framework.Vector2 vector = Main.fontMouseText.MeasureString(Lang.inter[2].Value);
			int num8 = 50;
			if (vector.X >= 45f)
			{
				num8 = (int)vector.X + 5;
			}
			DynamicSpriteFontExtensionMethods.DrawString(Main.spriteBatch, Main.fontMouseText, Lang.inter[2].Value, new Microsoft.Xna.Framework.Vector2(800 - num8 + UI_ScreenAnchorX, 6f), new Microsoft.Xna.Framework.Color(Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor), 0f, default(Microsoft.Xna.Framework.Vector2), 1f, SpriteEffects.None, 0f);
			if (UIDisplay_ManaPerStar <= 20)
				for (int i = 1; i < Main.player[Main.myPlayer].statManaMax2 / UIDisplay_ManaPerStar + 1; i++)
				{
					int num7 = 255;
					bool flag = false;
					float num6 = 1f;
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
						float num4 = (float)(Main.player[Main.myPlayer].statMana - (i - 1) * UIDisplay_ManaPerStar) / (float)UIDisplay_ManaPerStar;
						num7 = (int)(30f + 225f * num4);
						if (num7 < 30)
						{
							num7 = 30;
						}
						num6 = num4 / 4f + 0.75f;
						if ((double)num6 < 0.75)
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
					int a = (int)((double)(float)num7 * 0.9);
					if (!Main.player[Main.myPlayer].ghost)
                    {
						if (num17 > 0)
						{
							num17--;
							Main.spriteBatch.Draw(GetTexture("Content/Items/Consumables/Upgrades/ManaOverlay"), new Microsoft.Xna.Framework.Vector2(775 + UI_ScreenAnchorX, (float)(30 + Main.manaTexture.Height / 2) + ((float)Main.manaTexture.Height - (float)Main.manaTexture.Height * num6) / 2f + (float)(28 * (i - 1))), new Microsoft.Xna.Framework.Rectangle(0, 0, Main.manaTexture.Width, Main.manaTexture.Height), new Microsoft.Xna.Framework.Color(num7, num7, num7, a), 0f, new Vector2(Main.manaTexture.Width / 2, Main.manaTexture.Height / 2), num6, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0f);
						}
						else
                        {
							Main.spriteBatch.Draw(Main.manaTexture, new Microsoft.Xna.Framework.Vector2(775 + UI_ScreenAnchorX, (float)(30 + Main.manaTexture.Height / 2) + ((float)Main.manaTexture.Height - (float)Main.manaTexture.Height * num6) / 2f + (float)(28 * (i - 1))), new Microsoft.Xna.Framework.Rectangle(0, 0, Main.manaTexture.Width, Main.manaTexture.Height), new Microsoft.Xna.Framework.Color(num7, num7, num7, a), 0f, new Vector2(Main.manaTexture.Width / 2, Main.manaTexture.Height / 2), num6, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0f);
						}
                    }
				}
			else if (UIDisplay_ManaPerStar > 20)
				for (int i = 1; i < Main.player[Main.myPlayer].statManaMax2 / UIDisplay_ManaPerStar + 1; i++)
				{
					int num7 = 255;
					bool flag = false;
					float num6 = 1f;
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
						float num4 = (float)(Main.player[Main.myPlayer].statMana - (i - 1) * UIDisplay_ManaPerStar) / (float)UIDisplay_ManaPerStar;
						num7 = (int)(30f + 225f * num4);
						if (num7 < 30)
						{
							num7 = 30;
						}
						num6 = num4 / 4f + 0.75f;
						if ((double)num6 < 0.75)
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
					int a = (int)((double)(float)num7 * 0.9);
					if (!Main.player[Main.myPlayer].ghost)
					{
						if (num17 > 0)
						{
							num17--;
							Main.spriteBatch.Draw(GetTexture("Content/Items/Consumables/Upgrades/ManaOverlay"), new Microsoft.Xna.Framework.Vector2(775 + UI_ScreenAnchorX, (float)(30 + Main.manaTexture.Height / 2) + ((float)Main.manaTexture.Height - (float)Main.manaTexture.Height * num6) / 2f + (float)(28 * (i - 1))), new Microsoft.Xna.Framework.Rectangle(0, 0, Main.manaTexture.Width, Main.manaTexture.Height), new Microsoft.Xna.Framework.Color(num7, num7, num7, a), 0f, new Vector2(Main.manaTexture.Width / 2, Main.manaTexture.Height / 2), num6, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0f);
						}
						else
						{
							Main.spriteBatch.Draw(Main.manaTexture, new Microsoft.Xna.Framework.Vector2(775 + UI_ScreenAnchorX, (float)(30 + Main.manaTexture.Height / 2) + ((float)Main.manaTexture.Height - (float)Main.manaTexture.Height * num6) / 2f + (float)(28 * (i - 1))), new Microsoft.Xna.Framework.Rectangle(0, 0, Main.manaTexture.Width, Main.manaTexture.Height), new Microsoft.Xna.Framework.Color(num7, num7, num7, a), 0f, new Vector2(Main.manaTexture.Width / 2, Main.manaTexture.Height / 2), num6, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0f);
						}
					}
				}
		}
        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
			SteviesModMessageType msgType = (SteviesModMessageType)reader.ReadByte();
			switch (msgType)
            {
				case SteviesModMessageType.SteviesModPlayerSyncPlayer:
					byte playerNumber = reader.ReadByte();
					SteviesModPlayer steviesPlayer = Main.player[playerNumber].GetModPlayer<SteviesModPlayer>();
					int arcaneFruits = reader.ReadInt32();
					steviesPlayer.arcaneFruits = arcaneFruits;
					break;
            }
            base.HandlePacket(reader, whoAmI);
        }
		internal enum SteviesModMessageType : byte
        {
			SteviesModPlayerSyncPlayer
        }
    }
}