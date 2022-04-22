using ClassesManagerReborn;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnboundLib.Cards;

namespace Ported_FFC.Cards.Jester
{
    internal class JesterClass : ClassHandler
    {
        internal static string name = "Jester";

        public override IEnumerator Init()
        {
            CardInfo classCard = null;
            CustomCard.BuildCard<Jester>((card) => { ClassesRegistry.Regester(card, CardType.Entry); classCard = card; });
            while (classCard == null) yield return null;
        }
    }
}
