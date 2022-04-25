using ClassesManagerReborn.Util;
using Ported_FFC.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;



namespace Ported_FFC.Cards.LightGunner
{
    public class Dmr : CustomCard
    {
        private const float Damage = 1.50f;
        private const float ProjectileSpeed = 1.50f;
        private const float AttackSpeed = 2.00f;
        private const float ReloadSpeed = 1.20f;

        protected override string GetTitle()
        {
            return "DMR";
        }

        protected override string GetDescription()
        {
            return "More Damage and ammo, but less attack speed";
        }

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            gun.dontAllowAutoFire = true;
            gun.damage = Damage;
            gun.projectileSpeed = ProjectileSpeed;
            gun.attackSpeed = AttackSpeed;
            gun.reloadTime = ReloadSpeed;

            cardInfo.allowMultiple = false;

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
                ManageCardInfoStats.BuildCardInfoStat("Bullet Speed", true, ProjectileSpeed),
                ManageCardInfoStats.BuildCardInfoStat("Attack Speed", false, AttackSpeed, "", "-"),
                ManageCardInfoStats.BuildCardInfoStat("Reload Time", false, ReloadSpeed)
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
