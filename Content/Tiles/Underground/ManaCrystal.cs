using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SteviesMod.Content.Tiles.Underground
{
    //TODO: Make this exist.
    public class ManaCrystal : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileValue[Type] = 800;
            Main.tileSpelunker[Type] = true;
            Main.tileShine[Type] = 300;
            Main.tileShine2[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.Origin = new Terraria.DataStructures.Point16(1, 2);
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 16 };
            TileObjectData.addTile(Type);
            animationFrameHeight = 36;
        }

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frame = Main.tileFrame[TileID.Heart];
            frameCounter = Main.tileFrameCounter[TileID.Heart];
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 32, ItemID.ManaCrystal);
        }
    }
}