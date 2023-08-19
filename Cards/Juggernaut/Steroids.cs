using ClassesManagerReborn.Util;
using HarmonyLib;
using Ported_FFC.Extensions;
using Ported_FFC.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;

namespace Ported_FFC.Cards.Juggernaut {
    public class Steroids:CustomCard {
        private const float DamageResistance = 0.10f;
        private const float MovementSpeed = 0.80f;
        private const float Damage = 1.15f;
        internal static CardInfo Card = null;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block) {
            statModifiers.movementSpeed = MovementSpeed;
            gun.damage = Damage;
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats) {
            statModifiers.GetAdditionalData().damageReduction += DamageResistance;
        }
        public override void Callback() {
            gameObject.GetOrAddComponent<ClassNameMono>().className = JuggernautClass.name;
        }
        protected override GameObject GetCardArt() {
            return null;
        }

        protected override string GetDescription() {
            return "";
        }

        protected override CardInfo.Rarity GetRarity() {
            return CardInfo.Rarity.Rare;
        }

        protected override CardInfoStat[] GetStats() {
            return new[] {
                ManageCardInfoStats.BuildCardInfoStat("Damage Resistance", true, DamageResistance+1),
                ManageCardInfoStats.BuildCardInfoStat("Damage", true, Damage),
                ManageCardInfoStats.BuildCardInfoStat("Movement Speed", false, MovementSpeed),
            };
        }

        protected override CardThemeColor.CardThemeColorType GetTheme() {
            return CardThemeColor.CardThemeColorType.ColdBlue;
        }

        protected override string GetTitle() {
            return "Steroids";
        }

        public override string GetModName() {
            return PFFC.ModInitials;
        }

        [Serializable]
        [HarmonyPatch(typeof(HealthHandler), "DoDamage")]
        public class Patch {
            private static void Prefix(HealthHandler __instance, ref Vector2 damage, Player damagingPlayer) {
                if(damagingPlayer == (Player)__instance.GetFieldValue("player") || damagingPlayer == null) return;
                float res = ((CharacterStatModifiers)__instance.GetFieldValue("stats")).GetAdditionalData().damageReduction;
                if(res > 0) {
                    damage -= damage * res; 
                }
            }
        }
    }
}
