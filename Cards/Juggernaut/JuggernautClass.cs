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
            CardInfo classCard = null;
            CustomCard.BuildCard<Juggernaut>((card) => { ClassesRegistry.Regester(card, CardType.Entry); classCard = card; });
            while (classCard == null) yield return null;
            CustomCard.BuildCard<Conditioning>((card) => ClassesRegistry.Regester(card, CardType.Card, classCard));
            CustomCard.BuildCard<SizeMatters>((card) => ClassesRegistry.Regester(card, CardType.Card, classCard));
            CustomCard.BuildCard<ArmorPlating>((card) => ClassesRegistry.Regester(card, CardType.Card, classCard)); //doesn't do anything yet (was never finished in original FFC)
        }
    }
}
