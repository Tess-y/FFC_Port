using ClassesManagerReborn;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnboundLib.Cards;

namespace Ported_FFC.Cards.Juggernaut
{
    internal class JuggernautClass : ClassHandler
    {
        internal static string name = "Juggernaut";

        public override IEnumerator Init()
        {
            CardInfo classCard = null;
            CustomCard.BuildCard<Juggernaut>((card) => { ClassesRegistry.Regester(card, CardType.Entry); classCard = card; });
            while (classCard == null) yield return null;
        }
    }
}
