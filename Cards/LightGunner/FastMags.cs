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
    public class FastMags : CustomCard
    {
        private const float ReloadSpeed = 0.70f;

        protected override string GetTitle()
        {
            return "Fast Mags";
        }

        protected override string GetDescription()
        {
            return "After many missed shots and constantly having to reloading.. You bought fast mags. But, it didn't fix your aim";
        }

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            gun.reloadTime = ReloadSpeed;

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
                ManageCardInfoStats.BuildCardInfoStat("Reload Speed", true, ReloadSpeed)
            };
        }

        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Common;
        }

        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.TechWhite;
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
