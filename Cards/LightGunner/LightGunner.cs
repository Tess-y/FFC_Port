using Ported_FFC.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;

namespace Ported_FFC.Cards.LightGunner
{
    public class LightGunner : CustomCard
    {
        private const float MaxHealth = 1.10f;
        private const float MovementSpeed = 1.10f;
        private const int MaxAmmo = 3;

        protected override string GetTitle()
        {
            return "Light Gunner";
        }

        protected override string GetDescription()
        {
            return "As a Light Gunner your prioritize movement over Defence and Health";
        }

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            gun.ammo = MaxAmmo;
            statModifiers.health = MaxHealth;
            statModifiers.movementSpeed = MovementSpeed;

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
                ManageCardInfoStats.BuildCardInfoStat("Health", true, MaxHealth),
                ManageCardInfoStats.BuildCardInfoStat("Movement Speed", true, MovementSpeed),
                ManageCardInfoStats.BuildCardInfoStat("Max Ammo", true, null, $"+{MaxAmmo}")
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
