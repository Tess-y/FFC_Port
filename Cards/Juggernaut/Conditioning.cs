﻿using ClassesManagerReborn.Util;
using Ported_FFC.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;

namespace Ported_FFC.Cards.Juggernaut
{
    public class Conditioning : CustomCard
    {
        private const float MaxHealth = 1.50f;
        private const float MovementSpeed = 1.15f;

        internal static CardInfo Card = null;
        protected override string GetTitle()
        {
            return "Conditioning";
        }

        protected override string GetDescription()
        {
            return "You have trained hard! And its paying off...";
        }

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            statModifiers.health = MaxHealth;
            statModifiers.movementSpeed = MovementSpeed;
        }

        public override void Callback()
        {
            gameObject.GetOrAddComponent<ClassNameMono>().className = JuggernautClass.name;
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
                ManageCardInfoStats.BuildCardInfoStat("Health", true, MaxHealth),
                ManageCardInfoStats.BuildCardInfoStat("Movement Speed", true, MovementSpeed)
            };
        }

        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Uncommon;
        }

        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.NatureBrown;
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
