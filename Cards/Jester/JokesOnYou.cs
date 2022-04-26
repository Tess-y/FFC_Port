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


namespace Ported_FFC.Cards.Jester
{

    /// 
    /// I've changed the funtionality of this card slightly, however i feel that it is a flavorful accurate change, plus it lets the card prevent self-poison damage
    /// 

    public class JokesOnYou : CustomCard
    {
        private const int Bounces = 3;

        internal static CardInfo Card = null;
        protected override string GetTitle()
        {
            return "Jokes on you!";
        }

        protected override string GetDescription()
        {
            return "Your bouncing bullets bounce right off you!";
        }

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers)
        {
            gun.reflects = Bounces;

            cardInfo.allowMultiple = false;

            gameObject.GetOrAddComponent<ClassNameMono>().className = JesterClass.name;
        }

        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            characterStats.GetAdditionalData().JokesOnYou = true;
        }

        public override void OnRemoveCard()
        {
        }

        protected override CardInfoStat[] GetStats()
        {
            return new[] {
                ManageCardInfoStats.BuildCardInfoStat("Bounces", true, null, $"+{Bounces}"),
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

    [Serializable]
    [HarmonyPatch(typeof(ProjectileHit), "Hit")]
    class ProjectileHitPatchHit
    {
        // disable friendly fire or self damage and hit effects if that setting is enabled
        private static bool Prefix(ProjectileHit __instance, HitInfo hit, bool forceCall)
        {
            HealthHandler healthHandler = null;
            if (hit.transform)
            {
                healthHandler = hit.transform.GetComponent<HealthHandler>();
            }
            if (healthHandler)
            {
                Player hitPlayer = healthHandler.GetComponent<Player>();
                // if the hit player is not null
                if (hitPlayer != null && __instance.ownPlayer.playerID == hitPlayer.playerID && __instance.ownPlayer.data.stats.GetAdditionalData().JokesOnYou)
                {
                    __instance.GetComponent<ProjectileHit>().RemoveOwnPlayerFromPlayersHit();
                    __instance.GetComponent<ProjectileHit>().AddPlayerToHeld(healthHandler);
                    __instance.GetComponent<MoveTransform>().velocity *= -1f;
                    __instance.transform.position += __instance.GetComponent<MoveTransform>().velocity * TimeHandler.deltaTime;
                    __instance.GetComponent<RayCastTrail>().WasBlocked();
                    if (__instance.destroyOnBlock)
                    {
                        __instance.InvokeMethod("DestroyMe");
                    }
                    __instance.sinceReflect = 0f;
                    return false;
                }
            }
            return true;
        }
    }
}
