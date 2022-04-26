using ClassesManagerReborn.Util;
using Ported_FFC.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;

namespace Ported_FFC.Cards.Jester
{
    public class Jester : CustomCard
    {
        private const float MaxHealth = 0.85f;
        private const float MovementSpeed = 1.15f;
        private const float Size = 0.90f;
        private const int Bounces = 3;

        internal static CardInfo Card = null;
        protected override string GetTitle()
        {
            return "Jester";
        }

        protected override string GetDescription()
        {
            return "As a Jester, you enjoy bullet bounces";
        }

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            statModifiers.health = MaxHealth;
            statModifiers.movementSpeed = MovementSpeed;
            statModifiers.sizeMultiplier = Size;

            gun.projectileColor = new Color(25f / 255f, 8f / 255f, 40f / 255f);
            gun.reflects = Bounces;

            cardInfo.allowMultiple = false;

            gameObject.GetOrAddComponent<ClassNameMono>();
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
                ManageCardInfoStats.BuildCardInfoStat("Movement Speed", true, MovementSpeed),
                ManageCardInfoStats.BuildCardInfoStat("Bounces", true, null, $"+{Bounces}"),
                ManageCardInfoStats.BuildCardInfoStat("Health", false, MaxHealth)
            };
        }

        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Common;
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
