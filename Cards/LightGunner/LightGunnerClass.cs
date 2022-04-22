using ClassesManagerReborn;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnboundLib.Cards;

namespace Ported_FFC.Cards.LightGunner
{
    public class LightGunnerClass : ClassHandler
    {
        internal static string name = "Light Gunner";

        public override IEnumerator Init()
        {
            UnityEngine.Debug.Log("Regestering: " + name);
            CardInfo classCard = null;
            CustomCard.BuildCard<LightGunner>((card) => { ClassesRegistry.Regester(card, CardType.Entry); classCard = card; });
            while (classCard == null) yield return null;
            CustomCard.BuildCard<FastMags>((card) => ClassesRegistry.Regester(card, CardType.Card, classCard));
            CustomCard.BuildCard<BattleExperience>((card) => ClassesRegistry.Regester(card, CardType.Card, classCard));
            CustomCard.BuildCard<Lmg>((card) => ClassesRegistry.Regester(card, CardType.SubClass, classCard));
            CustomCard.BuildCard<Dmr>((card) => ClassesRegistry.Regester(card, CardType.SubClass, classCard));
            CustomCard.BuildCard<AssaultRifle>((card) => ClassesRegistry.Regester(card, CardType.SubClass, classCard));
        }
    }
}
