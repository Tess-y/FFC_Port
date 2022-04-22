﻿using Ported_FFC.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;


namespace Ported_FFC.Cards.LightGunner
{
    public class BattleExperience : CustomCard
    {
        private const float Damage = 1.15f;
        private const float ReloadSpeed = 0.75f;
        private const float AttackSpeed = 0.90f;
        private const float MaxHealth = 0.90f;

        protected override string GetTitle()
        {
            return "Battle Experience";
        }

        protected override string GetDescription()
        {
            return "A few tours later...";
        }

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            gun.damage = Damage;
            gun.attackSpeed = AttackSpeed;
            gun.reloadTime = ReloadSpeed;
            statModifiers.health = MaxHealth;

            gameObject.GetOrAddComponent<ClassNameMono>().className = LightGunnerClass.name;
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
                ManageCardInfoStats.BuildCardInfoStat("Damage", true, Damage),
                ManageCardInfoStats.BuildCardInfoStat("Reload Speed", true, ReloadSpeed),
                ManageCardInfoStats.BuildCardInfoStat("Attack Speed", true, AttackSpeed),
                ManageCardInfoStats.BuildCardInfoStat("Health", false, MaxHealth)
            };
        }

        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Common;
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
