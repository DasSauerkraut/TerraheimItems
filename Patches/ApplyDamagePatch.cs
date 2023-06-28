using HarmonyLib;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using TerraheimItems;
using TerraheimItems.Utility;
using UnityEngine;

namespace TerraheimItems.Patches
{
    [HarmonyPatch]
    class ApplyDamagePatch
    {
        static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");

        [HarmonyPrefix]
        [HarmonyPatch(typeof(SEMan), "OnDamaged")]
        public static void DamagePrefix(SEMan __instance, HitData hit)
        {
            if (__instance.m_character.IsPlayer() && hit.m_statusEffectHash == "ChainExplosionListener".GetStableHashCode())
            {
                hit.m_damage.m_damage = 0f;
                //Log.LogInfo("NewDamage From Explosion " + hit.GetTotalDamage());
            }
        }

        static Dictionary<int, float> explosionList = new Dictionary<int, float>();
        [HarmonyPrefix]
        [HarmonyPatch(typeof(Ragdoll), "SaveLootList")]
        public static void SaveLootListPrefix(Ragdoll __instance, CharacterDrop characterDrop)
        {
            if (characterDrop.m_character.GetSEMan().HaveStatusEffect("ChainExplosionListener"))
            {
                explosionList.Add(__instance.GetInstanceID(), characterDrop.m_character.GetMaxHealth()* (float)balance["AxeFire"]["effectVal"]);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(Ragdoll), "SpawnLoot")]
        public static void SpawnLootPostfix(Ragdoll __instance, Vector3 center)
        {
            if (explosionList.ContainsKey(__instance.GetInstanceID()))
            {
                AssetHelper.AxeFireExplosionPrefab.GetComponent<Aoe>().m_hitFriendly = false;
                AssetHelper.AxeFireExplosionPrefab.GetComponent<Aoe>().m_hitOwner = false;
                AssetHelper.AxeFireExplosionPrefab.GetComponent<Aoe>().m_damage.m_damage = explosionList[__instance.GetInstanceID()];
                //Log.LogInfo($"Explosion will deal {explosionList[__instance.GetInstanceID()]} damage");
                Object.Instantiate(AssetHelper.AxeFireExplosionPrefab, center, Quaternion.identity);
                explosionList.Remove(__instance.GetInstanceID());
            }
        }
    }
}
