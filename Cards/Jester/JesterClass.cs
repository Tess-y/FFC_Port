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
            CardInfo classCard = null;
            CustomCard.BuildCard<Jester>((card) => { ClassesRegistry.Regester(card, CardType.Entry); classCard = card; });
            while (classCard == null) yield return null;
            CustomCard.BuildCard<JokesOnYou>((card) => ClassesRegistry.Regester(card, CardType.Card, classCard));
            CustomCard.BuildCard<WayOfTheJester>((card) => ClassesRegistry.Regester(card, CardType.Card, classCard));
            CustomCard.BuildCard<KingOfFools>((card) => ClassesRegistry.Regester(card, CardType.Card, classCard, 2));
        }
    }
}
