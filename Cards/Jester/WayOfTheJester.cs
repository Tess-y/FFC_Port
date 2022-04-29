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
    public class WayOfTheJester : CustomCard
    {
        internal static CardInfo Card = null;
        protected override string GetTitle()
        {
            return "Way of the Jester";
        }

        protected override string GetDescription()
        {
            return
                "PASSIVE: Your stats increase as your pick cards that give you more bounces. Stats are added per bounce. Capped at 25 bounces. Thanks Pong! ;)";
        }

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            cardInfo.allowMultiple = false;

            gameObject.GetOrAddComponent<ClassNameMono>().className = JesterClass.name;
        }

        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            player.gameObject.GetOrAddComponent<WayOfTheJesterMono>();
        }

        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            Destroy(player.gameObject.GetOrAddComponent<WayOfTheJesterMono>());
        }

        protected override CardInfoStat[] GetStats()
        {
            return new[] {
                new CardInfoStat {
                    positive = true,
                    stat = "Damage",
                    amount = "+5%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat {
                    positive = true,
                    stat = "Movement Speed",
                    amount = "+1%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat {
                    positive = true,
                    stat = "Projectile Speed",
                    amount = "+3%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
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

    public class WayOfTheJesterMono : MonoBehaviour
    {
        private const float Damage = 0.05f;
        private float deltaDamage = 0f; 
        private const float MovementSpeed = 0.01f;
        private float deltaMovementSpeed = 0f;
        private const float ProjectileSpeed = 0.03f;
        private float deltaProjectileSpeed = 0f;
        private int _bounces;
        private Gun _gun;
        private Player _player;
        private int _previousBounces = 0;
        private CharacterStatModifiers _stats;

        public void Start()
        {
            if (_player == null) _player = gameObject.GetComponent<Player>();
        }
        private void Update()
        {
            if (_player == null) return;
            _stats = _player.data.stats;
            _gun = _player.GetComponent<Holding>().holdable.GetComponent<Gun>();
            _bounces = Mathf.Clamp(_gun.reflects, 0, 25);
            if (_bounces == _previousBounces) return;
            _previousBounces = _bounces;

            _stats.movementSpeed -= deltaMovementSpeed;
            _gun.damage -= deltaDamage;
            _gun.projectileSpeed -= deltaProjectileSpeed;

            deltaMovementSpeed = _stats.movementSpeed * MovementSpeed * _bounces;
            deltaDamage = _gun.damage * Damage * _bounces;
            deltaProjectileSpeed = _gun.projectileSpeed * _bounces * ProjectileSpeed;

            _stats.movementSpeed += deltaMovementSpeed;
            
            _gun.damage += deltaDamage;

            _gun.projectileSpeed += deltaProjectileSpeed;
        }
    }

}
