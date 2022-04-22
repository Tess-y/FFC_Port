using BepInEx;
using ClassesManagerReborn;
using HarmonyLib;
using Ported_FFC.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Ported_FFC
{

    [BepInDependency("root.classes.manager.reborn")]
    [BepInPlugin(ModId, ModName, Version)]
    [BepInProcess("Rounds.exe")]
    public class PFFC : BaseUnityPlugin
    {
        private const string ModId = "root.port.fluxxfield.fluxxfieldscards";
        private const string ModName = "Port of FFC";
        private const string Version = "0.0.0";
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
        }

    }
}
