using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using Terraria.ID;
using Terraria.ModLoader;

namespace SteviesMod
{
    public partial class SteviesMod : Mod
    {
        private void InitializeILEdits()
        {
            IL.Terraria.Main.GUIChatDrawInner += Main_GUIChatDrawInner;
        }

        private void Main_GUIChatDrawInner(ILContext il)
        {
            Mod gunplay = ModLoader.GetMod("Gunplay");
            if (!SteviesModConfig.Instance.anglerShop)
            {
                return;
            }

            var c = new ILCursor(il).Goto(0);

            if (!c.TryGotoNext(i => i.MatchLdcI4(NPCID.Angler)))
            {
                throw new Exception("Can't patch Angler shop button");
            }

            if (!c.TryGotoNext(i => i.MatchLdcI4(NPCID.Angler)))
            {
                throw new Exception("Can't patch Angler shop button");
            }

            if (gunplay != null)
            {
                instance.Logger.Error("Can't patch Angler shop button, disable Gunplay");
            }

            c.Index += 2;

            c.EmitDelegate<Func<string>>(() => "Shop");

            c.Emit(OpCodes.Stloc_S, (byte)10);
        }
    }
}