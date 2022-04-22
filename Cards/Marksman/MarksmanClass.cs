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
            CardInfo classCard = null;
            CustomCard.BuildCard<Marksman>((card) => { ClassesRegistry.Regester(card, CardType.Entry); classCard = card; });
            while (classCard == null) yield return null;
            CustomCard.BuildCard<ArmorPiercingRounds>((card) => ClassesRegistry.Regester(card, CardType.Card, classCard));
            CardInfo barret50Cal = null;
            CustomCard.BuildCard<Barret50Cal>((card) => { ClassesRegistry.Regester(card, CardType.Branch, classCard); barret50Cal = card; });
            while (barret50Cal == null) yield return null;
            CustomCard.BuildCard<SniperRifleExtendedMag>((card) => ClassesRegistry.Regester(card, CardType.Card, barret50Cal));

        }
    }
}
