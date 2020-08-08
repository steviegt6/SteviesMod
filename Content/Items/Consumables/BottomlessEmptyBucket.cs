using Terraria.ID;
using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace SteviesMod.Content.Items.Consumables
{
    public class BottomlessEmptyBucket : ModItem
    {
        private static int selectedLiquidName = 0;
        private static int liquidNameChangeTimer;
        private static int liquidColorChangeTimer;

        private readonly List<string> liquidNamesList = new List<string>();

        private readonly string[] liquidNamesIndex = new string[]
        {
            "water",
            "piss",
            "air",
            "internal static",
            "milk",
            "saliva",
            "orange juice",
            "honey",
            "lava",
            "nothing",
            "soup",
            "broth",
            "a secretion",
            "gold",
            "anti-water",
            "diamond",
            "bleach",
            "the best drink I've ever had",
            "the perfect drink",
            "music",
            "something Cassy will like",
            "pertinent medical knowledge",
            "my life story",
            "the blood of Christ",
            "Hic est enim Calix Sánguinis mei",
            "Smilodon blood",
            "passenger pigeon blood",
            "Thomas Jefferson's blood",
            "canis lupus",
            "the saliva of equus ferus caballus",
            "the urine of phascolarctos cinereus",
            "the cerebrospinal fluid of phoberomys pattersoni",
            "a room-temperature superconductor",
            "leukemia",
            "something OUT OF RANGE",
            "toothpaste",
            "any liquid",
            "something funny",
            "FILLER",
            "padding",
            "something repetitive",
            "glue",
            "oobleck",
            "something radioactive",
            "anything anomalous",
            "'weeb fuel'",
            "pure energy",
            "raw, unfiltered calamity",
            "cringe",
            "",
            "new line",
            "\\n",
            "\n",
            "\n\n\n\n",
            "<none>",
            "emptiness",
            "vacuum",
            "HL3",
            "Half Life 3",
            "alcohol",
            "ethanol",
            "vodka",
            "amnesia",
            "anti-energy",
            "anti-liquid",
            "anti-matter",
            "the void",
            "uranium",
            "beer",
            "a black, corrosive liquid",
            "blood",
            "quantum gas",
            "carbon",
            "carrots",
            "egg",
            "curry",
            "something hot",
            "something cold",
            "element #0",
            "me",
            "you",
            "them",
            "eyedrops",
            "glass",
            "feces",
            "iron",
            "\n\n",
            "\n\n\n\n\n\n\n\n\n\n\n\n\n\n",
            "\n\n\n\n\n\n\n",
            "\n.\n.\n.\n.\n.\n.\n."
        };

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bottomless Bucket");
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            liquidNamesList.AddRange(liquidNamesIndex);

            tooltips.Add(new TooltipLine(mod, "Tooltip", "Does not contain any trace of " + liquidNamesList[selectedLiquidName]));

            liquidNameChangeTimer++;
            liquidColorChangeTimer++;

            if (liquidNameChangeTimer >= 5)
            {
                selectedLiquidName = Main.rand.Next(liquidNamesList.Count);

                liquidNameChangeTimer = 0;
            }
            if (liquidColorChangeTimer >= 1)
            {
                for (int i = 1; i < tooltips.Count; i++)
                {
                    tooltips[i].overrideColor = new Color(Main.rand.Next(255), Main.rand.Next(255), Main.rand.Next(255));
                }

                liquidColorChangeTimer = 0;
            }
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.BottomlessBucket);
            item.tileBoost = 0;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.EmptyBucket, 60);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}