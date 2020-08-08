using SteviesMod.Utilities;
using Terraria.ModLoader;

namespace SteviesMod
{
    public class SteviesModWorld : ModWorld
    {
        public override void PreUpdate() => AnimatedColor.Update();
    }
}