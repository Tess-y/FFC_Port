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
    public class KingOfFools : CustomCard
    {
        protected override string GetTitle()
        {
            return "King Of Fools";
        }

        protected override string GetDescription()
        {
            return
                "You have become the King of Fools! You know have a 15% for bullet bounces to spawn an extra bullet!";
        }

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            gameObject.GetOrAddComponent<ClassNameMono>().className = JesterClass.name;
        }

        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {/// TODO: figure this shit out
            /*
            var kingOfFools = characterStats.GetAdditionalData().kingOfFools += 1;
            player.gameObject.GetOrAddComponent<KingOfFoolsHitSurfaceEffect>();
            */
        }

        public override void OnRemoveCard()
        {
        }

        protected override CardInfoStat[] GetStats()
        {
            return null;
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
