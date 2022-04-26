using ClassesManagerReborn;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnboundLib.Cards;
using UnboundLib.GameModes;

namespace Ported_FFC.Cards.LightGunner
{
    public class LightGunnerClass : ClassHandler
    {
        internal static string name = "Light Gunner";

        public override IEnumerator Init()
        {
            UnityEngine.Debug.Log("Regestering: " + name);
            while (!(LightGunner.Card && FastMags.Card && BattleExperience.Card && Lmg.Card && Dmr.Card && AssaultRifle.Card)) yield return null;
            ClassesRegistry.Register(LightGunner.Card, CardType.Entry);
            ClassesRegistry.Register(FastMags.Card, CardType.Card, LightGunner.Card);
            ClassesRegistry.Register(BattleExperience.Card, CardType.Card, LightGunner.Card);
            ClassesRegistry.Register(Lmg.Card, CardType.Card, LightGunner.Card);
            ClassesRegistry.Register(Dmr.Card, CardType.Card, LightGunner.Card);
            ClassesRegistry.Register(AssaultRifle.Card, CardType.Card, LightGunner.Card);
        }

        public override IEnumerator PostInit()
        {
            ClassesRegistry.Get(Lmg.Card).Blacklist(Dmr.Card).Blacklist(AssaultRifle.Card);
            ClassesRegistry.Get(Dmr.Card).Blacklist(Lmg.Card).Blacklist(AssaultRifle.Card);
            ClassesRegistry.Get(AssaultRifle.Card).Blacklist(Dmr.Card).Blacklist(Lmg.Card);
            yield break;
        }
    }
}
