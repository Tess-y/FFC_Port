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

namespace Ported_FFC.Cards.Juggernaut
{
    public class Juggernaut : CustomCard
    {
        private const float MaxHealth = 3f;
        private const float MovementSpeed = 0.65f;
        private const float JumpHight = 0.75f;
        private const float Size = 1.60f;
        private const float Healing = 0.50f;

        internal static CardInfo Card = null;
        protected override string GetTitle()
        {
            return "Juggernaut";
        }

        protected override string GetDescription()
        {
            return "Years of steroids has turned you into a slow moving, but deadly and unstoppable force";
        }

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            statModifiers.health = MaxHealth;
            statModifiers.movementSpeed = MovementSpeed;
            statModifiers.jump = JumpHight;
            statModifiers.sizeMultiplier = Size;

            cardInfo.allowMultiple = false;

        }

        public override void Callback()
        {
            gameObject.GetOrAddComponent<ClassNameMono>();
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            characterStats.GetAdditionalData().healing *= Healing;
        }

        public override void OnRemoveCard()
        {
        }

        protected override CardInfoStat[] GetStats()
        {
            return new[] {
                ManageCardInfoStats.BuildCardInfoStat("Health", true, MaxHealth),
                ManageCardInfoStats.BuildCardInfoStat("Movement Speed", false, MovementSpeed),
                ManageCardInfoStats.BuildCardInfoStat("Jump Hight", false, JumpHight),
                ManageCardInfoStats.BuildCardInfoStat("Healing", false, Healing)
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
            return PFFC.RS_Assets.LoadAsset<GameObject>("C_JUGGERNAUT");
        }

        public override string GetModName()
        {
            return PFFC.ModInitials;
        }
    }
    [Serializable]
    [HarmonyPatch(typeof(HealthHandler), "Heal")]
    public class Patch
    {
        private static void Prefix(HealthHandler __instance, ref float healAmount)
        {
            Player player = (Player)__instance.GetFieldValue("player");
            healAmount *= player.data.stats.GetAdditionalData().healing;
        }
    }

}
