﻿using ClassesManagerReborn.Util;
using Ported_FFC.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;

namespace Ported_FFC.Cards.Marksman
{
    public class Marksman : CustomCard
    {
        private const float MaxHealth = 0.50f;
        private const float Damage = 1.80f;
        private const float ProjectileSpeed = 2.00f;
        private const float AttackSpeed = 3.00f;
        private const float ReloadSpeed = 1.20f;
        private const int MaxAmmo = -1;

        protected override string GetTitle()
        {
            return "Marksman";
        }

        protected override string GetDescription()
        {
            return "All or nothing. Precision is key";
        }

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            gun.damage = Damage;
            gun.projectileSpeed = ProjectileSpeed;
            gun.attackSpeed = AttackSpeed;
            gun.reloadTime = ReloadSpeed;
            gun.gravity = 0f;
            gun.ammo = MaxAmmo;
            statModifiers.health = MaxHealth;

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
                ManageCardInfoStats.BuildCardInfoStat("Damage", true, Damage),
                ManageCardInfoStats.BuildCardInfoStat("Bullet Gravity", true, null, "No"),
                ManageCardInfoStats.BuildCardInfoStat("Projectile Speed", true, ProjectileSpeed),
                ManageCardInfoStats.BuildCardInfoStat("Health", false, MaxHealth),
                ManageCardInfoStats.BuildCardInfoStat("Attack Speed", false, AttackSpeed, "", "-"),
                ManageCardInfoStats.BuildCardInfoStat("Reload Time", false, ReloadSpeed),
                ManageCardInfoStats.BuildCardInfoStat("Max Ammo", false, null, $"{MaxAmmo}")
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
