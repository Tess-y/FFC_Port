using ClassesManagerReborn;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnboundLib.Cards;

namespace Ported_FFC.Cards.Juggernaut
{
    public class JuggernautClass : ClassHandler
    {
        internal static string name = "Juggernaut";

        public override IEnumerator Init()
        {
            UnityEngine.Debug.Log("Regestering: " + name);
            while (!(Juggernaut.Card && Conditioning.Card && SizeMatters.Card && ArmorPlating.Card)) yield return null;
            ClassesRegistry.Register(Juggernaut.Card, CardType.Entry);
            ClassesRegistry.Register(Conditioning.Card, CardType.Card, Juggernaut.Card);
            ClassesRegistry.Register(SizeMatters.Card, CardType.Card, Juggernaut.Card);
            ClassesRegistry.Register(ArmorPlating.Card, CardType.Card, Juggernaut.Card);
            ClassesRegistry.Register(Steroids.Card, CardType.Card, Juggernaut.Card, 6);
        }
    }
}
