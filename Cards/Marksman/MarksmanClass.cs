using ClassesManagerReborn;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnboundLib.Cards;

namespace Ported_FFC.Cards.Marksman
{
    internal class MarksmanClass : ClassHandler
    {
        internal static string name = "Marksman";

        public override IEnumerator Init()
        {
            CardInfo classCard = null;
            CustomCard.BuildCard<Marksman>((card) => { ClassesRegistry.Regester(card, CardType.Entry); classCard = card; });
            while (classCard == null) yield return null;
        }
    }
}
