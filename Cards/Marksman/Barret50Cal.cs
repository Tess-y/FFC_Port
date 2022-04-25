using ClassesManagerReborn.Util;
using ModdingUtils.RoundsEffects;
using Photon.Pun;
using Ported_FFC.Extensions;
using Ported_FFC.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;

namespace Ported_FFC.Cards.Marksman
{
    public class Barret50Cal : CustomCard
    {
        private const float ReloadSpeed = 1.40f;
        private const float MovementSpeed = 0.90f;
        private const int MaxAmmo = 1;
        private InstantKillHitEffect instantKillHitEffect;
        private Barret50CalMono barret50CalMono;

        protected override string GetTitle()
        {
            return "Barret .50 Cal";
        }

        protected override string GetDescription()
        {
            return "Girl Friend: 'Now that's BIG ;)' *Ammo can only be added by Sniper Rifle Extended Mag*";
        }

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            gun.reloadTime = ReloadSpeed;
            statModifiers.movementSpeed = MovementSpeed;

            cardInfo.allowMultiple = false;

            gameObject.GetOrAddComponent<ClassNameMono>().className = MarksmanClass.name;
        }

        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            instantKillHitEffect = player.gameObject.GetOrAddComponent<InstantKillHitEffect>();
            barret50CalMono = player.gameObject.GetOrAddComponent<Barret50CalMono>();
        }

        public override void OnRemoveCard()
        {
            Destroy(instantKillHitEffect);
            Destroy(barret50CalMono);
        }

        protected override CardInfoStat[] GetStats()
        {
            return new[] {
                ManageCardInfoStats.BuildCardInfoStat("Insta Kill", true),
                ManageCardInfoStats.BuildCardInfoStat("Max Ammo", false, null, $"{MaxAmmo}"),
                ManageCardInfoStats.BuildCardInfoStat("Reload Time", false, ReloadSpeed),
                ManageCardInfoStats.BuildCardInfoStat("Movement Speed", false, MovementSpeed)
            };
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
    public class InstantKillHitEffect : HitEffect
    {
        public override void DealtDamage(Vector2 damage, bool selfDamage, Player damagedPlayer = null)
        {
            if (damagedPlayer == null) return;
            if (damagedPlayer.data.stats.remainingRespawns > 0)
            {
                damagedPlayer.data.view.RPC("RPCA_Die_Phoenix", RpcTarget.All, new object[]
                {
                    damage
                });
            }
            else
            {
                damagedPlayer.data.view.RPC("RPCA_Die", RpcTarget.All, new object[]
                {
                    damage
                });
            }
        }
    }
    public class Barret50CalMono : MonoBehaviour
    {
        private Player _player;

        private void Awake()
        {
            if (_player == null) _player = gameObject.GetComponent<Player>();
        }

        private void Update()
        {
            var extendedMags = _player.data.stats.GetAdditionalData().extendedMags;
            gameObject.GetComponent<Holding>().holdable.GetComponent<Gun>().GetComponentInChildren<GunAmmo>().maxAmmo =
                extendedMags;
        }
    }
}
