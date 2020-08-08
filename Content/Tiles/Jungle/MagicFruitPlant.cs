using SteviesMod.Content.Items.Consumables;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SteviesMod.Content.Tiles.Jungle
{
    public class MagicFruitPlant : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileValue[Type] = 810;
            Main.tileSpelunker[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileCut[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.addTile(Type);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 32, ModContent.ItemType<MagicFruit>());
        }
    }
}