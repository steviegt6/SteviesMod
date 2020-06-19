using System;
using System.Diagnostics;
using Terraria.ModLoader;
using Terraria;
using ReLogic.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.CompilerServices;
using System.IO;
using SteviesMod.Content.Items.Consumables.Upgrades;
using SteviesMod.Content.Tiles.Jungle.Natural;
using Terraria.UI;
using System.Collections.Generic;
using MonoMod.Cil;
using Mono.Cecil.Cil;
using SteviesMod.Utils;

namespace SteviesMod
{
	public class SteviesMod : Mod
	{
		private static int UI_ScreenAnchorX = Terraria.Main.screenWidth - 800;
		private static int UIDisplay_ManaPerStar;

		internal Texture2D originalMinimap;

		public override void Load()
		{
			originalMinimap = Terraria.Main.miniMapFrameTexture;

			Main.versionNumber = "v1.3.5.3\nStevie's Mod v0.1.3 (Beta Build 4)";

			On.Terraria.Main.DrawInterface_Resources_Mana += NewDrawMana;
			On.Terraria.Main.DrawInterface_Resources_Breath += NewDrawBreath;
			base.Load();
		}
        public override void Unload()
		{
			Terraria.Main.miniMapFrameTexture = originalMinimap;

			Main.versionNumber = "v1.3.5.3";

			base.Unload();
		}
        public override void AddRecipes()
        {
			RecipeHelper.RemoveEndlessQuiverRecipe(this);
            base.AddRecipes();
        }
        private void NewDrawBreath(On.Terraria.Main.orig_DrawInterface_Resources_Breath orig)
        {
			bool flag = false;
			if (Terraria.Main.player[Terraria.Main.myPlayer].dead)
			{
				return;
			}
			if (Terraria.Main.player[Terraria.Main.myPlayer].lavaTime < Terraria.Main.player[Terraria.Main.myPlayer].lavaMax && Terraria.Main.player[Terraria.Main.myPlayer].lavaWet)
			{
				flag = true;
			}
			else if (Terraria.Main.player[Terraria.Main.myPlayer].lavaTime < Terraria.Main.player[Terraria.Main.myPlayer].lavaMax && Terraria.Main.player[Terraria.Main.myPlayer].breath == Terraria.Main.player[Terraria.Main.myPlayer].breathMax)
			{
				flag = true;
			}
			Vector2 value = Terraria.Main.player[Terraria.Main.myPlayer].Top + new Vector2(0f, Terraria.Main.player[Terraria.Main.myPlayer].gfxOffY);
			if (Terraria.Main.playerInventory && Terraria.Main.screenHeight < 1000)
			{
				value.Y += Terraria.Main.player[Terraria.Main.myPlayer].height - 20;
			}
			value = Vector2.Transform(value - Terraria.Main.screenPosition, Terraria.Main.GameViewMatrix.ZoomMatrix);
			if (!Terraria.Main.playerInventory || Terraria.Main.screenHeight >= 1000)
			{
				value.Y -= 100f;
			}
			value /= Terraria.Main.UIScale;
			if (Terraria.Main.ingameOptionsWindow || Terraria.Main.InGameUI.IsVisible)
			{
				value = new Vector2(Terraria.Main.screenWidth / 2, Terraria.Main.screenHeight / 2 + 236);
				if (Terraria.Main.InGameUI.IsVisible)
				{
					value.Y = Terraria.Main.screenHeight - 64;
				}
			}
			if (Terraria.Main.player[Terraria.Main.myPlayer].breath < Terraria.Main.player[Terraria.Main.myPlayer].breathMax && !Terraria.Main.player[Terraria.Main.myPlayer].ghost && !flag)
			{
				_ = Terraria.Main.player[Terraria.Main.myPlayer].breathMax / 20;
				int num19 = Terraria.Main.player[Terraria.Main.myPlayer].breathMax / 10;
				for (int j = 1; j < Terraria.Main.player[Terraria.Main.myPlayer].breathMax / num19 + 1; j++)
				{
					int num25 = 255;
					float num24 = 1f;
					if (Terraria.Main.player[Terraria.Main.myPlayer].breath >= j * num19)
					{
						num25 = 255;
					}
					else
					{
						float num22 = (float)(Terraria.Main.player[Terraria.Main.myPlayer].breath - (j - 1) * num19) / (float)num19;
						num25 = (int)(30f + 225f * num22);
						if (num25 < 30)
						{
							num25 = 30;
						}
						num24 = num22 / 4f + 0.75f;
						if ((double)num24 < 0.75)
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
					if (Terraria.Main.LocalPlayer.GetModPlayer<SteviesModPlayer>().extendedLungs)
                    {
                        Terraria.Main.spriteBatch.Draw(GetTexture("Content/Items/Consumables/Upgrades/BubbleOverlay"), value + new Vector2((float)(26 * (j - 1) + num21) - 125f, 32f + ((float)Terraria.Main.bubbleTexture.Height - (float)Terraria.Main.bubbleTexture.Height * num24) / 2f + (float)num20), new Microsoft.Xna.Framework.Rectangle(0, 0, Terraria.Main.bubbleTexture.Width, Terraria.Main.bubbleTexture.Height), new Microsoft.Xna.Framework.Color(num25, num25, num25, num25), 0f, default(Vector2), num24, SpriteEffects.None, 0f);
					}
					else
                    {
                        Terraria.Main.spriteBatch.Draw(Terraria.Main.bubbleTexture, value + new Vector2((float)(26 * (j - 1) + num21) - 125f, 32f + ((float)Terraria.Main.bubbleTexture.Height - (float)Terraria.Main.bubbleTexture.Height * num24) / 2f + (float)num20), new Microsoft.Xna.Framework.Rectangle(0, 0, Terraria.Main.bubbleTexture.Width, Terraria.Main.bubbleTexture.Height), new Microsoft.Xna.Framework.Color(num25, num25, num25, num25), 0f, default(Vector2), num24, SpriteEffects.None, 0f);
					}
				}
			}
			if (!((Terraria.Main.player[Terraria.Main.myPlayer].lavaTime < Terraria.Main.player[Terraria.Main.myPlayer].lavaMax && !Terraria.Main.player[Terraria.Main.myPlayer].ghost) & flag))
			{
				return;
			}
			int num18 = Terraria.Main.player[Terraria.Main.myPlayer].lavaMax / 10;
			_ = Terraria.Main.player[Terraria.Main.myPlayer].breathMax / num18;
			for (int i = 1; i < Terraria.Main.player[Terraria.Main.myPlayer].lavaMax / num18 + 1; i++)
			{
				int num17 = 255;
				float num16 = 1f;
				if (Terraria.Main.player[Terraria.Main.myPlayer].lavaTime >= i * num18)
				{
					num17 = 255;
				}
				else
				{
					float num14 = (float)(Terraria.Main.player[Terraria.Main.myPlayer].lavaTime - (i - 1) * num18) / (float)num18;
					num17 = (int)(30f + 225f * num14);
					if (num17 < 30)
					{
						num17 = 30;
					}
					num16 = num14 / 4f + 0.75f;
					if ((double)num16 < 0.75)
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
                Terraria.Main.spriteBatch.Draw(Terraria.Main.flameTexture, value + new Vector2((float)(26 * (i - 1) + num13) - 125f, 32f + ((float)Terraria.Main.flameTexture.Height - (float)Terraria.Main.flameTexture.Height * num16) / 2f + (float)num12), new Microsoft.Xna.Framework.Rectangle(0, 0, Terraria.Main.bubbleTexture.Width, Terraria.Main.bubbleTexture.Height), new Microsoft.Xna.Framework.Color(num17, num17, num17, num17), 0f, default(Vector2), num16, SpriteEffects.None, 0f);
			}
		}
        public override void UpdateUI(GameTime gameTime) //this is a very no-no cringe bad dont do this way of doing this, wouldnt recommend
        {
			if (Terraria.Main.player[Terraria.Main.myPlayer].GetModPlayer<SteviesModPlayer>().mysteriousFossils <= 0)
                Terraria.Main.miniMapFrameTexture = GetTexture("UI/MysteriousFossilEmpty");
			if (Terraria.Main.player[Terraria.Main.myPlayer].GetModPlayer<SteviesModPlayer>().mysteriousFossils == 1)
                Terraria.Main.miniMapFrameTexture = GetTexture("UI/MysteriousFossil20");
			if (Terraria.Main.player[Terraria.Main.myPlayer].GetModPlayer<SteviesModPlayer>().mysteriousFossils == 2)
                Terraria.Main.miniMapFrameTexture = GetTexture("UI/MysteriousFossil40");
			if (Terraria.Main.player[Terraria.Main.myPlayer].GetModPlayer<SteviesModPlayer>().mysteriousFossils == 3)
                Terraria.Main.miniMapFrameTexture = GetTexture("UI/MysteriousFossil60");
			if (Terraria.Main.player[Terraria.Main.myPlayer].GetModPlayer<SteviesModPlayer>().mysteriousFossils == 4)
                Terraria.Main.miniMapFrameTexture = GetTexture("UI/MysteriousFossil80");
			if (Terraria.Main.player[Terraria.Main.myPlayer].GetModPlayer<SteviesModPlayer>().mysteriousFossils >= 5)
                Terraria.Main.miniMapFrameTexture = GetTexture("UI/MysteriousFossil100");
			base.UpdateUI(gameTime);
        }
        private void NewDrawMana(On.Terraria.Main.orig_DrawInterface_Resources_Mana orig)
        {
			if (Terraria.Main.player[Terraria.Main.myPlayer].statManaMax2 / 10 >= 20)
				UIDisplay_ManaPerStar = Terraria.Main.player[Terraria.Main.myPlayer].statManaMax2 / 10;
			else
				UIDisplay_ManaPerStar = 20;
			if (Terraria.Main.LocalPlayer.ghost || Terraria.Main.player[Terraria.Main.myPlayer].statManaMax2 <= 0)
			{
				return;
			}
			int num18 = Terraria.Main.player[Terraria.Main.myPlayer].statManaMax / 20;
			int num17 = Terraria.Main.player[Terraria.Main.myPlayer].GetModPlayer<SteviesModPlayer>().arcaneFruits;
			if (num17 < 0)
			{
				num17 = 0;
			}
			if (num17 > 0)
			{
				num18 = Terraria.Main.player[Terraria.Main.myPlayer].statManaMax / (20 + num17 / 4);
			}
			_ = Terraria.Main.player[Terraria.Main.myPlayer].statManaMax2 / 20;
			Microsoft.Xna.Framework.Vector2 vector = Terraria.Main.fontMouseText.MeasureString(Terraria.Lang.inter[2].Value);
			int num8 = 50;
			if (vector.X >= 45f)
			{
				num8 = (int)vector.X + 5;
			}
			DynamicSpriteFontExtensionMethods.DrawString(Terraria.Main.spriteBatch, Terraria.Main.fontMouseText, Terraria.Lang.inter[2].Value, new Microsoft.Xna.Framework.Vector2(800 - num8 + UI_ScreenAnchorX, 6f), new Microsoft.Xna.Framework.Color(Terraria.Main.mouseTextColor, Terraria.Main.mouseTextColor, Terraria.Main.mouseTextColor, Terraria.Main.mouseTextColor), 0f, default(Microsoft.Xna.Framework.Vector2), 1f, SpriteEffects.None, 0f);
			if (UIDisplay_ManaPerStar <= 20)
				for (int i = 1; i < Terraria.Main.player[Terraria.Main.myPlayer].statManaMax2 / UIDisplay_ManaPerStar + 1; i++)
				{
					int num7 = 255;
					bool flag = false;
					float num6 = 1f;
					if (Terraria.Main.player[Terraria.Main.myPlayer].statMana >= i * UIDisplay_ManaPerStar)
					{
						num7 = 255;
						if (Terraria.Main.player[Terraria.Main.myPlayer].statMana == i * UIDisplay_ManaPerStar)
						{
							flag = true;
						}
					}
					else
					{
						float num4 = (float)(Terraria.Main.player[Terraria.Main.myPlayer].statMana - (i - 1) * UIDisplay_ManaPerStar) / (float)UIDisplay_ManaPerStar;
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
						num6 += Terraria.Main.cursorScale - 1f;
					}
					int a = (int)((double)(float)num7 * 0.9);
					if (!Terraria.Main.player[Terraria.Main.myPlayer].ghost)
                    {
						if (num17 > 0)
						{
							num17--;
                            Terraria.Main.spriteBatch.Draw(GetTexture("Content/Items/Consumables/Upgrades/ManaOverlay"), new Microsoft.Xna.Framework.Vector2(775 + UI_ScreenAnchorX, (float)(30 + Terraria.Main.manaTexture.Height / 2) + ((float)Terraria.Main.manaTexture.Height - (float)Terraria.Main.manaTexture.Height * num6) / 2f + (float)(28 * (i - 1))), new Microsoft.Xna.Framework.Rectangle(0, 0, Terraria.Main.manaTexture.Width, Terraria.Main.manaTexture.Height), new Microsoft.Xna.Framework.Color(num7, num7, num7, a), 0f, new Vector2(Terraria.Main.manaTexture.Width / 2, Terraria.Main.manaTexture.Height / 2), num6, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0f);
						}
						else
                        {
                            Terraria.Main.spriteBatch.Draw(Terraria.Main.manaTexture, new Microsoft.Xna.Framework.Vector2(775 + UI_ScreenAnchorX, (float)(30 + Terraria.Main.manaTexture.Height / 2) + ((float)Terraria.Main.manaTexture.Height - (float)Terraria.Main.manaTexture.Height * num6) / 2f + (float)(28 * (i - 1))), new Microsoft.Xna.Framework.Rectangle(0, 0, Terraria.Main.manaTexture.Width, Terraria.Main.manaTexture.Height), new Microsoft.Xna.Framework.Color(num7, num7, num7, a), 0f, new Vector2(Terraria.Main.manaTexture.Width / 2, Terraria.Main.manaTexture.Height / 2), num6, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0f);
						}
                    }
				}
			else if (UIDisplay_ManaPerStar > 20)
				for (int i = 1; i < Terraria.Main.player[Terraria.Main.myPlayer].statManaMax2 / UIDisplay_ManaPerStar + 1; i++)
				{
					int num7 = 255;
					bool flag = false;
					float num6 = 1f;
					if (Terraria.Main.player[Terraria.Main.myPlayer].statMana >= i * UIDisplay_ManaPerStar)
					{
						num7 = 255;
						if (Terraria.Main.player[Terraria.Main.myPlayer].statMana == i * UIDisplay_ManaPerStar)
						{
							flag = true;
						}
					}
					else
					{
						float num4 = (float)(Terraria.Main.player[Terraria.Main.myPlayer].statMana - (i - 1) * UIDisplay_ManaPerStar) / (float)UIDisplay_ManaPerStar;
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
						num6 += Terraria.Main.cursorScale - 1f;
					}
					int a = (int)((double)(float)num7 * 0.9);
					if (!Terraria.Main.player[Terraria.Main.myPlayer].ghost)
					{
						if (num17 > 0)
						{
							num17--;
                            Terraria.Main.spriteBatch.Draw(GetTexture("Content/Items/Consumables/Upgrades/ManaOverlay"), new Microsoft.Xna.Framework.Vector2(775 + UI_ScreenAnchorX, (float)(30 + Terraria.Main.manaTexture.Height / 2) + ((float)Terraria.Main.manaTexture.Height - (float)Terraria.Main.manaTexture.Height * num6) / 2f + (float)(28 * (i - 1))), new Microsoft.Xna.Framework.Rectangle(0, 0, Terraria.Main.manaTexture.Width, Terraria.Main.manaTexture.Height), new Microsoft.Xna.Framework.Color(num7, num7, num7, a), 0f, new Vector2(Terraria.Main.manaTexture.Width / 2, Terraria.Main.manaTexture.Height / 2), num6, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0f);
						}
						else
						{
                            Terraria.Main.spriteBatch.Draw(Terraria.Main.manaTexture, new Microsoft.Xna.Framework.Vector2(775 + UI_ScreenAnchorX, (float)(30 + Terraria.Main.manaTexture.Height / 2) + ((float)Terraria.Main.manaTexture.Height - (float)Terraria.Main.manaTexture.Height * num6) / 2f + (float)(28 * (i - 1))), new Microsoft.Xna.Framework.Rectangle(0, 0, Terraria.Main.manaTexture.Width, Terraria.Main.manaTexture.Height), new Microsoft.Xna.Framework.Color(num7, num7, num7, a), 0f, new Vector2(Terraria.Main.manaTexture.Width / 2, Terraria.Main.manaTexture.Height / 2), num6, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0f);
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
					SteviesModPlayer steviesPlayer = Terraria.Main.player[playerNumber].GetModPlayer<SteviesModPlayer>();
					int arcaneFruits = reader.ReadInt32();
					int mysteriousFossils = reader.ReadInt32();
					bool extendedLungs = reader.ReadBoolean();
					steviesPlayer.arcaneFruits = arcaneFruits;
					steviesPlayer.mysteriousFossils = mysteriousFossils;
					steviesPlayer.extendedLungs = extendedLungs;
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