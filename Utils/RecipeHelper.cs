using Terraria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;

namespace SteviesMod.Utils
{
    public static class RecipeHelper
    {
        public static void EditEndlessQuiverRecipe(Mod mod)
        {
            /*RecipeFinder recipeFinder = new RecipeFinder();
            recipeFinder.AddIngredient(ItemID.WoodenArrow, 3996);
            recipeFinder.AddTile(TileID.CrystalBall);
            recipeFinder.SetResult(ItemID.EndlessQuiver);

            foreach (Recipe recipe in recipeFinder.SearchRecipes())
            {
                RecipeEditor recipeEditor = new RecipeEditor(recipe);
                recipeEditor.DeleteTile(TileID.CrystalBall);
                recipeEditor.AddTile(TileID.WorkBenches);
            }*/
        }
        public static void EditMusketPouchRecipe(Mod mod)
        {
            /*RecipeFinder recipeFinder = new RecipeFinder();
            recipeFinder.AddIngredient(ItemID.MusketBall, 3996);
            recipeFinder.AddTile(TileID.CrystalBall);
            recipeFinder.SetResult(ItemID.EndlessMusketPouch);

            foreach (Recipe recipe in recipeFinder.SearchRecipes())
            {
                RecipeEditor recipeEditor = new RecipeEditor(recipe);
                recipeEditor.DeleteTile(TileID.CrystalBall);
                recipeEditor.AddTile(TileID.WorkBenches);
            }*/
        }
    }
}
