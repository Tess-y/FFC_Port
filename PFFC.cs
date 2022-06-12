using BepInEx;
using ClassesManagerReborn;
using HarmonyLib;
using Ported_FFC.Cards;
using Ported_FFC.Cards.Jester;
using Ported_FFC.Cards.Juggernaut;
using Ported_FFC.Cards.LightGunner;
using Ported_FFC.Cards.Marksman;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnboundLib.Cards;

namespace Ported_FFC
{

    [BepInDependency("root.classes.manager.reborn")]
    [BepInPlugin(ModId, ModName, Version)]
    [BepInProcess("Rounds.exe")]
    public class PFFC : BaseUnityPlugin
    {
        private const string ModId = "root.port.fluxxfield.fluxxfieldscards";
        private const string ModName = "Port of FFC";
        private const string Version = "1.1.0";
        public const string ModInitials = "PFFC";
        public static PFFC instance { get; private set; }

        private void Awake() 
        {
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
        }

        private void Start()
        {
            instance = this;
            CustomCard.BuildCard<Jester>((card) => Jester.Card = card);
            CustomCard.BuildCard<JokesOnYou>((card) => JokesOnYou.Card = card);
            CustomCard.BuildCard<KingOfFools>((card) => KingOfFools.Card = card);
            CustomCard.BuildCard<WayOfTheJester>((card) => WayOfTheJester.Card = card);
            CustomCard.BuildCard<WildCard>((card) => WildCard.Card = card);


            CustomCard.BuildCard<Juggernaut>((card) => Juggernaut.Card = card);
            CustomCard.BuildCard<ArmorPlating>((card) => ArmorPlating.Card = card);
            CustomCard.BuildCard<Conditioning>((card) => Conditioning.Card = card);
            CustomCard.BuildCard<SizeMatters>((card) => SizeMatters.Card = card);


            CustomCard.BuildCard<LightGunner>((card) => LightGunner.Card = card);
            CustomCard.BuildCard<AssaultRifle>((card) => AssaultRifle.Card = card);
            CustomCard.BuildCard<BattleExperience>((card) => BattleExperience.Card = card);
            CustomCard.BuildCard<Dmr>((card) => Dmr.Card = card);
            CustomCard.BuildCard<FastMags>((card) => FastMags.Card = card);
            CustomCard.BuildCard<Lmg>((card) => Lmg.Card = card);


            CustomCard.BuildCard<Marksman>((card) => Marksman.Card = card);
            CustomCard.BuildCard<ArmorPiercingRounds>((card) => ArmorPiercingRounds.Card = card);
            CustomCard.BuildCard<Barret50Cal>((card) => Barret50Cal.Card = card);
            CustomCard.BuildCard<SniperRifleExtendedMag>((card) => SniperRifleExtendedMag.Card = card);
        }

    }
}
