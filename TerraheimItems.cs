using BepInEx;
using HarmonyLib;
using System.IO;
using TerraheimItems.StatusEffects;
using TerraheimItems.Utility;
using UnityEngine;
using Jotunn.Entities;
using Jotunn.Managers;

namespace TerraheimItems
{
    [BepInPlugin(ModGuid, ModName, ModVer)]
    [BepInDependency(Jotunn.Main.ModGuid, BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("DasSauerkraut.Terraheim", BepInDependency.DependencyFlags.SoftDependency)]
    class TerraheimItems : BaseUnityPlugin
    {

        public const string ModGuid = AuthorName + "." + ModName;
        private const string AuthorName = "DasSauerkraut";
        private const string ModName = "TerraheimItems";
        private const string ModVer = "2.3.7";
        public static readonly string ModPath = Path.GetDirectoryName(typeof(TerraheimItems).Assembly.Location);

        private readonly Harmony harmony = new Harmony(ModGuid);
        internal static TerraheimItems Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            Log.Init(Logger);
            TranslationUtils.LoadTranslations();
            SetupStatusEffects();
            harmony.PatchAll();
            Utility.AssetHelper.Init();
            Weapons.Greatswords.Init();
            Weapons.Axes.Init();
            Weapons.AtgeirSilver.Init();
            Weapons.Knives.Init();
            Weapons.ParryingDagger.Init();
            Weapons.BowBlackmetal.Init();
            Weapons.PickaxeBlackmetal.Init();
            Weapons.SpearBlackmetal.Init();
            Weapons.Battleaxes.Init();
            Weapons.FlametalWeapons.Init();

            Weapons.TorchOlympia.Init();

            Weapons.Bombs.Init();
            Weapons.ThrowingAxes.Init();
            //Weapons.Javelins.Init();

            Log.LogInfo("Patching complete");
        }

        public static void SetupStatusEffects()
        {
            ItemManager.Instance.AddStatusEffect(new CustomStatusEffect(ScriptableObject.CreateInstance<SE_HealthPercentDamage>(), fixReference: true));
            ItemManager.Instance.AddStatusEffect(new CustomStatusEffect(ScriptableObject.CreateInstance<SE_ChainExplosionListener>(), fixReference: true));
        }
    }
}
