using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader.Config;

namespace SteviesMod
{
    [Label("Stevie's Mod Config")]
    public class SteviesModConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        public static SteviesModConfig Instance;

        [Header("General Options")]
        [Label("NPCs DIsplay Text when Chatting")]
        [DefaultValue(true)]
        public bool npcText;

        [Label("Fossil UI")]
        [DefaultValue(true)]
        public bool fossilUI;
    }
}
