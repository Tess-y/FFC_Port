﻿using ClassesManagerReborn.Util;
using Ported_FFC.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;

namespace Ported_FFC.Cards.LightGunner
{
    public class Lmg : CustomCard
    {
        private const float Damage = 1.35f;
        private const float ProjectileSpeed = 1.30f;
        private const float AttackSpeed = 1.30f;
        private const float ReloadSpeed = 2.50f;
        private const float MovementSpeed = 0.70f;
        private const int MaxAmmo = 12;

        protected override string GetTitle()
        {
            return "LMG";
        }

        protected override string GetDescription()
        {
            return "'SAY HELLO TO MY LITTLE FRIEND' - Said someone, somewhere";
        }

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            gun.dontAllowAutoFire = false;
            gun.damage = Damage;
            gun.projectileSpeed = ProjectileSpeed;
            gun.attackSpeed = AttackSpeed;
            gun.ammo = MaxAmmo;
            gun.reloadTime = ReloadSpeed;
            statModifiers.movementSpeed = MovementSpeed;

            cardInfo.allowMultiple = false;


            gameObject.GetOrAddComponent<ClassNameMono>().className = LightGunnerClass.name; ;
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
                ManageCardInfoStats.BuildCardInfoStat("Bullet Speed", true, ProjectileSpeed),
                ManageCardInfoStats.BuildCardInfoStat("Max Ammo", true, null, $"+{MaxAmmo}"),
                ManageCardInfoStats.BuildCardInfoStat("Attack Speed", false, AttackSpeed, "", "-"),
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
