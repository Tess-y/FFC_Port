using ClassesManagerReborn.Util;
using Ported_FFC.Extensions;
using Ported_FFC.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;

namespace Ported_FFC.Cards.Marksman
{
    public class SniperRifleExtendedMag : CustomCard
    {
        private const float ReloadSpeed = 1.10f;
        private const float MovementSpeed = 0.95f;
        private const int MaxAmmo = 1;

        internal static CardInfo Card = null;
        protected override string GetTitle()
        {
            return "Sniper Rifle Extended Mag";
        }

        protected override string GetDescription()
        {
            return "The only way to add ammo if you have a Barret .50 Cal!";
        }

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            gun.reloadTime = ReloadSpeed;
            statModifiers.movementSpeed = MovementSpeed;

        }

        public override void Callback()
        {
            gameObject.GetOrAddComponent<ClassNameMono>().className = MarksmanClass.name;
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
           characterStats.GetAdditionalData().extendedMags += MaxAmmo;
        }

        public override void OnRemoveCard()
        {
        }

        protected override CardInfoStat[] GetStats()
        {
            return new[] {
                ManageCardInfoStats.BuildCardInfoStat("MaxAmmo", true, null, $"+{MaxAmmo}"),
                ManageCardInfoStats.BuildCardInfoStat("Reload Time", false, ReloadSpeed),
                ManageCardInfoStats.BuildCardInfoStat("Movement Speed", false, MovementSpeed)
            };
        }

        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Uncommon;
        }

        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.DefensiveBlue;
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
