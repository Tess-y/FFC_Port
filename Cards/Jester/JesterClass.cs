using ClassesManagerReborn;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnboundLib.Cards;

namespace Ported_FFC.Cards.Jester
{
    public class JesterClass : ClassHandler
    {
        internal static string name = "Jester";

        public override IEnumerator Init()
        {
            UnityEngine.Debug.Log("Regestering: "+name);
            while(!(Jester.Card && JokesOnYou.Card && KingOfFools.Card && WayOfTheJester.Card && WildCard.Card)) yield return null;
            ClassesRegistry.Register(Jester.Card, CardType.Entry);
            ClassesRegistry.Register(JokesOnYou.Card, CardType.Card, Jester.Card);
            ClassesRegistry.Register(KingOfFools.Card, CardType.Card, Jester.Card, 2);
            ClassesRegistry.Register(WayOfTheJester.Card, CardType.Card, Jester.Card);
            ClassesRegistry.Register(WildCard.Card, CardType.Card, Jester.Card);
        }
    }
}
