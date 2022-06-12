using ClassesManagerReborn.Util;
using ModdingUtils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;

namespace Ported_FFC.Cards.Jester
{
    internal class WildCard : CustomCard
    {
        internal static CardInfo Card = null;
        protected override string GetTitle()
        {
            return "Wildcard";
        }

        protected override string GetDescription()
        {
            return "Gain a pair of random bounce cards";
        }

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            cardInfo.GetAdditionalData().canBeReassigned = false;

        }

        public override void Callback()
        {
            gameObject.GetOrAddComponent<ClassNameMono>().className = JesterClass.name;
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            PFFC.instance.ExecuteAfterFrames(5, () =>
            {
                CardInfo[] availableCards = UnboundLib.Utils.CardManager.cards.Values.Where(c => c.cardInfo.GetComponent<Gun>() != null && c.cardInfo.GetComponent<Gun>().reflects > 0 && c.enabled && ModdingUtils.Utils.Cards.instance.PlayerIsAllowedCard(player, c.cardInfo)).Select(c => c.cardInfo).ToArray();
                availableCards.Shuffle();
                CardInfo card1 = availableCards[0];
                CardInfo card2 = availableCards[0];
                List<CardInfo> playerCards = player.data.currentCards.ToList();
                playerCards.Add(card1);
                do
                {
                    availableCards.Shuffle();
                    card2 = availableCards[0];
                } while (!ModdingUtils.Utils.Cards.instance.CardDoesNotConflictWithCards(card2, playerCards.ToArray()));
                ModdingUtils.Utils.Cards.instance.AddCardsToPlayer(player, new CardInfo[] { card1, card2 },false, null,null,null,true);
            });
        }

        public override void OnRemoveCard()
        {
        }

        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Rare;
        }

        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.EvilPurple;
        }

        protected override GameObject GetCardArt()
        {
            return null;
        }

        public override string GetModName()
        {
            return PFFC.ModInitials;
        }

        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[0];
        }
    }
}
