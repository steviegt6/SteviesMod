using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Microsoft.Xna.Framework;

namespace SteviesMod
{
    public partial class SteviesMod : Mod
    {
        public static string GithubUserName => "Steviegt6";
        public static string GithubProjectName => "SteviesMod";

        private static readonly int UI_ScreenAnchorX = Main.screenWidth - 800;
        private static int UIDisplay_ManaPerStar;

        internal Texture2D originalLogoTexture;
        internal Texture2D originalLogo2Texture;
        internal Texture2D newLogoTexture;
        internal Texture2D newLogo2Texture;
        internal SteviesMod instance;

        public override void Load()
        {
            originalLogoTexture = Main.logoTexture;
            originalLogo2Texture = Main.logo2Texture;
            newLogoTexture = GetTexture("UI/logoDay2");
            newLogo2Texture = GetTexture("UI/logoNight2");

            instance = this;

            InitializeILEdits();
            InitializeMethodSwaps();
        }

        public override void PostSetupContent()
        {
            Main.OnPostDraw += Main_OnPostDraw;
        }

        public override void Unload()
        {
            Main.OnPostDraw -= Main_OnPostDraw;

            Main.logoTexture = originalLogoTexture;
            Main.logo2Texture = originalLogo2Texture;
            originalLogoTexture = null;
            originalLogo2Texture = null;
            newLogoTexture = null;
            newLogo2Texture = null;

            instance = null;
        }

        private void Main_OnPostDraw(GameTime obj)
        {
            Mod Overhaul = ModLoader.GetMod("TerrariaOverhaul");

            if (Main.gameMenu && Overhaul == null && !Main.dedServ)
            {
                Main.logoTexture = newLogoTexture;
                Main.logo2Texture = newLogo2Texture;
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
                    bool extendedLungs = reader.ReadBoolean();
                    steviesPlayer.arcaneFruits = arcaneFruits;
                    steviesPlayer.extendedLungs = extendedLungs;
                    break;
            }
        }

        internal enum SteviesModMessageType : byte
        {
            SteviesModPlayerSyncPlayer
        }
    }
}