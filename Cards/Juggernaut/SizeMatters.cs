using ClassesManagerReborn.Util;
using Ported_FFC.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnboundLib;
using UnboundLib.Cards;
using UnboundLib.GameModes;
using UnityEngine;


namespace Ported_FFC.Cards.Juggernaut
{
    public class SizeMatters : CustomCard
    {
        private const float MaxHealth = 1.25f;
        private const float MaxAdaptiveMovementSpeed = 0.35f;
        private const float MaxAdaptiveGravity = 0.25f;

        protected override string GetTitle()
        {
            return "Size Matters";
        }

        protected override string GetDescription()
        {
            return "You get smaller and run faster as you take damage";
        }

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            statModifiers.health = MaxHealth;

            gameObject.GetOrAddComponent<ClassNameMono>().className = JuggernautClass.name;
        }

        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {/// TODO: figure this shit out
            /*
            var additionalData = characterStats.GetAdditionalData();
            additionalData.hasAdaptiveSizing = true;
            additionalData.adaptiveMovementSpeed += MaxAdaptiveMovementSpeed;
            additionalData.adaptiveGravity += MaxAdaptiveGravity;
            player.gameObject.GetOrAddComponent<SizeMattersMono>();*/
        }

        public override void OnRemoveCard()
        {
        }

        protected override CardInfoStat[] GetStats()
        {
            return new[] {
                ManageCardInfoStats.BuildCardInfoStat("Health", true, MaxHealth)
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

        public static IEnumerator SetPrePointStats(IGameModeHandler gm)
        {/// TODO: figure this shit out
            /*
            foreach (var player in PlayerManager.instance.players)
            {
                var additionalData = player.data.stats.GetAdditionalData();

                if (additionalData.hasAdaptiveSizing)
                    player.gameObject.GetComponent<SizeMattersMono>().SetPrePointStats(player.data);
            }
            */
            yield break;
        }
    }
}
