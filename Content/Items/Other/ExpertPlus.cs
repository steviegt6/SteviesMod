using IL.Terraria.GameContent.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod.Content.Items.Other
{
    public class ExpertPlus : ModItem
    {
        public Color[] colorCycle => new Color[] { new Color(250, 236, 155), new Color(122, 83, 0) };
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Expert+");
            Tooltip.SetDefault("Might activate something?" +
                "\nYou shouldn't have this...");
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            item.value = 0;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useTurn = false;
            item.useAnimation = 45;
            item.useTime = 45;
            item.reuseDelay = 20;
            item.consumable = true;
            item.rare = ItemRarityID.Expert;
            item.maxStack = 1;
            item.width = item.height = 18;
            item.scale = 1.1f;
            item.expert = true;
            item.questItem = false;
            item.material = false;
            item.UseSound = SoundID.Item4;
            base.SetDefaults();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            float fade = Main.GameUpdateCount % 60 / 60f;
            int index = (int)(Main.GameUpdateCount / 60 % colorCycle.Length);

            for (int i = 0; i < tooltips.Count; i++)
            {
                TooltipLine tooltip = tooltips[i];

                if (tooltip.Name == "ItemName")
                    tooltip.overrideColor = Color.Lerp(colorCycle[index], colorCycle[(index + 1) % colorCycle.Length], fade);
            }
            base.ModifyTooltips(tooltips);
        }
        public override Color? GetAlpha(Color lightColor) => Color.White;
        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            float fade = Main.GameUpdateCount % 60 / 60f;
            int index = (int)(Main.GameUpdateCount / 60 % colorCycle.Length);

            Texture2D texture = mod.GetTexture("Glowmasks/ExpertPlus");

            for (int i = 0; i < 4; i++)
            {
                Vector2 offsetPositon = Vector2.UnitY.RotatedBy(MathHelper.PiOver2 * i) * 2;
                spriteBatch.Draw(texture, position + offsetPositon, null, Color.Lerp(colorCycle[index], colorCycle[(index + 1) % colorCycle.Length], fade), 0, origin, scale, SpriteEffects.None, 0f);
            }

            return true;
        }
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            float fade = Main.GameUpdateCount % 60 / 60f;
            int index = (int)(Main.GameUpdateCount / 60 % colorCycle.Length);

            Texture2D texture = mod.GetTexture("Glowmasks/ExpertPlus");

            Vector2 position = item.position - Main.screenPosition + new Vector2(item.width / 2, item.height - texture.Height * 0.5f + 2f);

            for (int i = 0; i < 4; i++)
            {
                Vector2 offsetPositon = Vector2.UnitY.RotatedBy(MathHelper.PiOver2 * i) * 2;
                spriteBatch.Draw(texture, position + offsetPositon, null, Color.Lerp(colorCycle[index], colorCycle[(index + 1) % colorCycle.Length], fade), rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);
            }

            return true;
        }
    }
}
