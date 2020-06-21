using Terraria.ID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using SteviesMod.Utils;

namespace SteviesMod.Content.Items.Consumables.Buckets
{
    public class BottomlessEmptyBucket : ModItem
    {
        public static int funnycount = 0;
        public static int funnyintgoup;

        List<String> funnyliquidshahaha = new List<String>();

        String[] thefunny = new string[]
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
            "secretion",
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
            "blood of Christ",
            "Hic est enim Calix Sánguinis mei",
            "Smilodon blood",
            "passenger pigeon blood",
            "Thomas Jefferson's blood",
            "canis lupus",
            "saliva of equus ferus caballus",
            "urine of phascolarctos cinereus",
            "cerebrospinal fluid of phoberomys pattersoni",
            "room-temperature superconductor",
            "leukemia",
            "something OUT OF RANGE",
            "toothpaste",
            "liquid",
            "something funny",
            "filler",
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
            "\\n"
        };
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bottomless Bucket");
            //Tooltip.SetDefault("Contains an endless amount of air");
            base.SetStaticDefaults();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            funnyliquidshahaha.AddRange(thefunny);

            tooltips.Add(new TooltipLine(mod, "Tooltip", "Does not contain any trace of " + funnyliquidshahaha[funnycount]));

            funnyintgoup++;

            if (funnyintgoup >= 2)
            {
                funnycount = Main.rand.Next(funnyliquidshahaha.Count);

                funnyintgoup = 0;
            }
            base.ModifyTooltips(tooltips);
        }
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.BottomlessBucket);
            item.tileBoost = 0;
            base.SetDefaults();
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.EmptyBucket, 30);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
            base.AddRecipes();
        }
    }
}
