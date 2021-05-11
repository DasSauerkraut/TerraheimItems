﻿using Newtonsoft.Json.Linq;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Terraheim.Utility
{

    class AssetHelper
    {
        static JObject balance = UtilityFunctions.GetJsonFromFile("weaponBalance.json");

        public const string AssetBundleName = "bundle_terraheim";
        public static AssetBundle TerraheimAssetBundle;

        public static GameObject FolcbrandPrefab;
        public static GameObject GreatswordIronPrefab;
        public static GameObject GreatswordBlackmetalPrefab;

        public static GameObject AtgeirSilverPrefab;
        public static GameObject AxeForstascaPrefab;

        public static GameObject KnifeIronPrefab;
        public static GameObject BowBlackmetalPrefab;

        public static GameObject PickaxeBlackmetalPrefab;
        public static GameObject SpearBlackmetalPrefab;

        public static GameObject BattleaxeBronzePrefab;
        public static GameObject BattleaxeBlackmetalPrefab;
        public static GameObject BattleaxeSilverPrefab;
        public static GameObject GreateaxeBlackmetalPrefab;

        public static GameObject MaceFirePrefab;
        public static GameObject GreatswordFirePrefab;
        public static GameObject AtgeirFirePrefab;
        public static GameObject BowFirePrefab;
        public static GameObject BattleaxeFirePrefab;
        public static GameObject SledgeFirePrefab;
        public static GameObject AxeFirePrefab;
        public static GameObject KnifeFirePrefab;
        public static GameObject SpearFirePrefab;
        public static GameObject ThrowingAxeFirePrefab;
        public static GameObject ArrowGreatFirePrefab;

        public static GameObject TorchOlympiaPrefab;
        public static GameObject ParryingDaggerPrefab;

        public static GameObject BombFirePrefab;
        public static GameObject BombFrostPrefab;
        public static GameObject BombLightningPrefab;

        public static GameObject ThrowingAxeFlintPrefab;
        public static GameObject ThrowingAxeBronzePrefab;
        public static GameObject ThrowingAxeIronPrefab;
        public static GameObject ThrowingAxeSilverPrefab;
        public static GameObject ThrowingAxeBlackmetalPrefab;

        public static GameObject JavelinFlintPrefab;
        public static GameObject JavelinBronzePrefab;

        public static GameObject BowFireExplosionPrefab;
        public static GameObject AxeFireExplosionPrefab;
        public static GameObject VFXAtgeirFireHitPrefab;
        public static AudioClip SFXAtgeirFireHitPrefab;

        public static GameObject SwordIronFireProjPrefab;


        public static void Init()
        {
            TerraheimAssetBundle = GetAssetBundleFromResources(AssetBundleName);

            FolcbrandPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/folcbrand/SwordFolcbrand.prefab");
            GreatswordIronPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/greatswordiron/GreatswordIron.prefab");
            GreatswordBlackmetalPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/greatswordblackmetal/GreatswordBlackmetal.prefab");

            AtgeirSilverPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/kresja/AtgeirSilver.prefab");
            AxeForstascaPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/forstasca/AxeForstasca.prefab");
            
            BattleaxeBronzePrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/BattleaxeBronze/BattleaxeBronzeTerraheim.prefab");
            KnifeIronPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/ironKnife/KnifeIron.prefab");
            BowBlackmetalPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/blackmetalbow/BowBlackmetalTH.prefab");

            PickaxeBlackmetalPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/blackironPickaxe/PickaxeBlackmetal.prefab");
            SpearBlackmetalPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/blackmetalspear/SpearBlackmetal.prefab");
            BattleaxeBlackmetalPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/blackmetalAxehammer/BattleaxeBlackmetal.prefab");
            BattleaxeSilverPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/BattleaxeSilver/BattleaxeSilver.prefab");
            GreateaxeBlackmetalPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/BattleaxeBlackmetal/GreataxeBlackmetal.prefab");

            MaceFirePrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/flametal/mace/MaceFireTH.prefab");
            GreatswordFirePrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/flametal/greatsword/GreatswordFireTH.prefab");
            GreatswordFirePrefab.GetComponent<ItemDrop>().m_itemData.m_shared.m_secondaryAttack.m_attackProjectile.GetComponent<Projectile>()
                .m_spawnOnHit.GetComponent<Aoe>().m_damage.m_fire = (float)balance["GreatswordFire"]["effectVal"];
            AtgeirFirePrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/flametal/atgeir/AtgeirFireTH.prefab");
            BowFirePrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/flametal/bow/BowFireTH.prefab");
            BattleaxeFirePrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/flametal/greataxe/BattleaxeFireTH.prefab");
            BattleaxeFirePrefab.GetComponent<ItemDrop>().m_itemData.m_shared.m_secondaryAttack.m_attackProjectile.GetComponent<Projectile>()
                .m_damage.m_fire = (float)balance["BattleaxeFire"]["effectVal"];
            SledgeFirePrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/flametal/sledge/SledgeFireTH.prefab");
            SledgeFirePrefab.GetComponent<ItemDrop>().m_itemData.m_shared.m_secondaryAttack.m_attackProjectile.GetComponent<Projectile>()
                .m_spawnOnHit.GetComponent<Aoe>().m_damage.m_fire = (float)balance["SledgeFire"]["effectVal"];
            AxeFirePrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/flametal/axe/AxeFireTH.prefab");
            KnifeFirePrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/flametal/knife/KnifeFireTH.prefab");
            SpearFirePrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/flametal/spear/SpearFireTH.prefab");
            ThrowingAxeFirePrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/flametal/throwingaxe/ThrowingAxeFire.prefab");
            ArrowGreatFirePrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/flametal/arrow/ArrowGreatFireTH.prefab");
            
            TorchOlympiaPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/Olympia/TorchOlympia.prefab");
            ParryingDaggerPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/parryingdagger/ShieldSilverDagger.prefab");

            BombFirePrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/firebomb/BombFire.prefab");
            BombFrostPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/frostbomb/BombFrost.prefab");
            BombLightningPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/lightningbomb/BombLightning.prefab");

            ThrowingAxeFlintPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/ThrowingAxes/Flint/ThrowingAxeFlint.prefab");
            ThrowingAxeBronzePrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/ThrowingAxes/Bronze/ThrowingAxeBronze.prefab");
            ThrowingAxeIronPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/ThrowingAxes/Iron/ThrowingAxeIron.prefab");
            ThrowingAxeSilverPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/ThrowingAxes/Silver/ThrowingAxeSilver.prefab");
            ThrowingAxeBlackmetalPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/ThrowingAxes/Blackmetal/ThrowingAxeBlackmetal.prefab");

            JavelinFlintPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/Javelins/Flint/JavelinFlint.prefab");
            JavelinBronzePrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/Javelins/Bronze/JavelinBronze.prefab");

            SwordIronFireProjPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/flametal/swordProj/swordironfire_projectile.prefab");

            BowFireExplosionPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/flametal/bow/bowFire_explosion1.prefab");
            BowFireExplosionPrefab.GetComponent<Aoe>().m_damage.m_fire = (float)balance["BowFire"]["effectVal"];
            AxeFireExplosionPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/flametal/axe/axeFire_explosion.prefab");
            AxeFireExplosionPrefab.GetComponent<Aoe>().m_statusEffect = "ChainExplosionListener";
            VFXAtgeirFireHitPrefab = TerraheimAssetBundle.LoadAsset<GameObject>("Assets/CustomItems/Effects/vfx_flametal_atgeir_hit.prefab");
            SFXAtgeirFireHitPrefab = TerraheimAssetBundle.LoadAsset<AudioClip>("Assets/CustomItems/flametal/atgeir/Flame_SpitFire3.wav");
        }

        public static AssetBundle GetAssetBundleFromResources(string filename)
        {
            var execAssembly = Assembly.GetExecutingAssembly();
            var resourceName = execAssembly.GetManifestResourceNames().Single(str => str.EndsWith(filename));

            using (var stream = execAssembly.GetManifestResourceStream(resourceName))
            {
                return AssetBundle.LoadFromStream(stream);
            }
        }
    }
}
