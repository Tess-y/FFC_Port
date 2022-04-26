using ClassesManagerReborn;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnboundLib.Cards;

namespace Ported_FFC.Cards.Marksman
{
    public class MarksmanClass : ClassHandler
    {
        internal static string name = "Marksman";

        public override IEnumerator Init()
        {
            UnityEngine.Debug.Log("Regestering: " + name);

            while (!(Marksman.Card && ArmorPiercingRounds.Card && Barret50Cal.Card && SniperRifleExtendedMag.Card)) yield return null;
            ClassesRegistry.Register(Marksman.Card, CardType.Entry);
            ClassesRegistry.Register(ArmorPiercingRounds.Card, CardType.Card, Marksman.Card);
            ClassesRegistry.Register(Barret50Cal.Card, CardType.Branch, Marksman.Card);
            ClassesRegistry.Register(SniperRifleExtendedMag.Card, CardType.Card, Barret50Cal.Card);

        }
    }
}
