using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace SteviesMod
{
    [Label("Stevie's Mod Config")]
    public class SteviesModConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        public static SteviesModConfig Instance;

        [Header("General Options")]
        [Label("NPCs Display Text when Chatting")]
        [DefaultValue(true)]
        public bool npcText;

        [Label("Angler Shop")]
        [DefaultValue(true)]
        [ReloadRequired]
        public bool anglerShop;

        [Label("Lock Angler items behind a quest \"wall\".")]
        [DefaultValue(false)]
        [ReloadRequired]
        public bool anglerQuestWall;

        [Label("Experimental Features")]
        public Experimental experimental = new Experimental();

        public class Experimental
        {
            public static Experimental Instance;

            [Label("Enable Experimental Features")]
            [Tooltip("Not vanilla's experimental features. Only enable this if you know what you're doing.")]
            [DefaultValue(false)]
            public bool experimentalFeatures;
        }
    }
}