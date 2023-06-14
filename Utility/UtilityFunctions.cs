using System.IO;
using Newtonsoft.Json.Linq;

using BepInEx;
using System.Collections.Generic;
using Jotunn;
using Jotunn.Entities;
using Jotunn.Managers;
using Terraheim;

namespace TerraheimItems.Utility
{
    class UtilityFunctions
    {
        public static JObject GetJsonFromFile(string filename)
        {
            var filePath = Path.Combine(TerraheimItems.ModPath, filename);
            //Log.LogWarning(filePath);
            string rawText = File.ReadAllText(filePath);
            //Log.LogWarning(rawText);
            return JObject.Parse(rawText);
        }

        public static void ModifyWeaponDamage(ref CustomItem item, JToken damages, string type = "", string description = "")
        {
            foreach (var damage in damages["damages"])
            {
                switch ((string)damage["type"])
                {
                    case "blunt":
                        item.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)damage["value"];
                        break;
                    case "slash":
                        item.ItemDrop.m_itemData.m_shared.m_damages.m_slash = (float)damage["value"];
                        break;
                    case "pierce":
                        item.ItemDrop.m_itemData.m_shared.m_damages.m_pierce = (float)damage["value"];
                        break;
                    case "chop":
                        item.ItemDrop.m_itemData.m_shared.m_damages.m_chop = (float)damage["value"];
                        break;
                    case "pickaxe":
                        item.ItemDrop.m_itemData.m_shared.m_damages.m_blunt = (float)damage["value"];
                        break;
                    case "fire":
                        item.ItemDrop.m_itemData.m_shared.m_damages.m_fire = (float)damage["value"];
                        break;
                    case "frost":
                        item.ItemDrop.m_itemData.m_shared.m_damages.m_frost = (float)damage["value"];
                        break;
                    case "lightning":
                        item.ItemDrop.m_itemData.m_shared.m_damages.m_lightning = (float)damage["value"];
                        break;
                    case "poison":
                        item.ItemDrop.m_itemData.m_shared.m_damages.m_poison = (float)damage["value"];
                        break;
                    case "spirit":
                        item.ItemDrop.m_itemData.m_shared.m_damages.m_spirit = (float)damage["value"];
                        break;
                    default:
                        Log.LogWarning("Terraheim: Warning damage type not found! " + (string)damage["type"]);
                        break;
                }
            }

            if (type != "")
            {
                item.ItemDrop.m_itemData.m_shared.m_description = type + item.ItemDrop.m_itemData.m_shared.m_description;
            }

            if (description != "")
            {
                item.ItemDrop.m_itemData.m_shared.m_description += description;
            }
        }

        public static void GetRecipe(ref Recipe recipe, JToken json, bool useName = true)
        {
            var itemReqs = new List<Piece.Requirement>();
            int index = 0;
            foreach (var item in json["recipe"])
            {
                if ((string)item["item"] == "SalamanderFur")
                {
                    var fur = new Piece.Requirement
                    {
                        m_resItem = Terraheim.Utility.SharedResources.SalamanderItem.ItemDrop,
                        m_amount = (int)item["amount"],
                    };
                    itemReqs.Add(fur);
                }
                else
                {
                    itemReqs.Add(MockRequirement.Create((string)item["item"], (int)item["amount"]));
                    itemReqs[index].m_amountPerLevel = (int)item["perLevel"];
                }
                index++;
            }
            if (useName)
                recipe.name = $"Recipe_{json.Path}";
            recipe.m_resources = itemReqs.ToArray();
            recipe.m_craftingStation = Mock<CraftingStation>.Create((string)json["station"]);
            recipe.m_amount = (int)json["amountCrafted"];
        }

        public static bool HasProjectileAttack(string name)
        {
            if (name.Contains("_greatsword_fire"))
                return true;
            if (name.Contains("_battleaxe_fire"))
                return true;
            if (name.Contains("_sword_fire"))
                return true;
            if (name.Contains("_sledge_fire"))
                return true;
            if (name.Contains("_axe_serpent"))
                return true;
            return false;
        }

        public static StatusEffect GetStatusEffectFromName(string name, SEMan seman)
        {
            foreach (StatusEffect statusEffect in seman.GetStatusEffects())
            {
                if (statusEffect.name == name)
                {
                    return statusEffect;
                }
            }
            return null;
        }

        
    }
}
