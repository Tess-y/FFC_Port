using ClassesManagerReborn.Util;
using Ported_FFC.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;

namespace Ported_FFC.Cards.Marksman
{
    public class ArmorPiercingRounds : CustomCard
    {
        private const float ReloadSpeed = 1.25f;

        internal static CardInfo Card = null;
        protected override string GetTitle()
        {
            return "Armor-Piercing Rounds";
        }

        protected override string GetDescription()
        {
            return "Tired of your friends blocking your shots? This might help";
        }

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            gun.unblockable = true;
            gun.reloadTime = ReloadSpeed;

            cardInfo.allowMultiple = false;

        }
        public override void Callback()
        {
            gameObject.GetOrAddComponent<ClassNameMono>().className = MarksmanClass.name;
        }

        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
        }

        public override void OnRemoveCard()
        {
        }

        protected override CardInfoStat[] GetStats()
        {
            return new[] {
                ManageCardInfoStats.BuildCardInfoStat("Unblockable", true),
                ManageCardInfoStats.BuildCardInfoStat("Reload Time", false, ReloadSpeed)
            };
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
    }
}
