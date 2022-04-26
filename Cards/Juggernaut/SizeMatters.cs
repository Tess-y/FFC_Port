using ClassesManagerReborn.Util;
using Ported_FFC.Extensions;
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

        internal static CardInfo Card = null;
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
        {
            var additionalData = characterStats.GetAdditionalData();
            additionalData.hasAdaptiveSizing = true;
            additionalData.adaptiveMovementSpeed += MaxAdaptiveMovementSpeed;
            additionalData.adaptiveGravity += MaxAdaptiveGravity;
            player.gameObject.GetOrAddComponent<SizeMattersMono>();
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

    }

    public class SizeMattersMono : MonoBehaviour
    {
        private float lastHealthPercet;
        private float sizeDelta = 0f;
        private float movementSpeedDelta = 0f;
        private float gravtyDelta = 0f;
        private Player _player;
        private void Start()
        {
            if (_player == null) _player = gameObject.GetComponent<Player>();
            GameModeManager.AddHook(GameModeHooks.HookPointEnd, (gm) => reset());
        }
        private void Update()
        {
            if (_player == null || !_player.data.stats.GetAdditionalData().hasAdaptiveSizing) return;
            float healthPrecent = _player.data.health / _player.data.maxHealth;
            if (Mathf.Clamp(healthPrecent, 0f, 1f) == lastHealthPercet) return;
            lastHealthPercet = healthPrecent;
            _player.data.stats.movementSpeed -= movementSpeedDelta;
            _player.data.stats.gravity -= gravtyDelta;
            _player.data.stats.sizeMultiplier -= sizeDelta;

            movementSpeedDelta = _player.data.stats.movementSpeed * (_player.data.stats.GetAdditionalData().adaptiveMovementSpeed - (_player.data.stats.GetAdditionalData().adaptiveMovementSpeed * healthPrecent));
            gravtyDelta = -_player.data.stats.gravity * (_player.data.stats.GetAdditionalData().adaptiveGravity - (_player.data.stats.GetAdditionalData().adaptiveGravity * healthPrecent));
            sizeDelta = (_player.data.stats.sizeMultiplier * Mathf.Clamp(healthPrecent,0.25f,1f)) - _player.data.stats.sizeMultiplier;


            _player.data.stats.movementSpeed += movementSpeedDelta;
            _player.data.stats.gravity += gravtyDelta;
            _player.data.stats.sizeMultiplier += sizeDelta;

            _player.data.stats.InvokeMethod("ConfigureMassAndSize");
        }
        public IEnumerator reset()
        {
            try
            {
                _player.data.stats.movementSpeed -= movementSpeedDelta;
                _player.data.stats.gravity -= gravtyDelta;
                _player.data.stats.sizeMultiplier -= sizeDelta;
                movementSpeedDelta = 0;
                gravtyDelta = 0;
                sizeDelta = 0;
            }
            catch { }
            yield break;
        }
    }
}
