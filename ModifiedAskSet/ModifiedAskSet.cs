using System;
using BepInEx;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;
using UnityEngine;

//TODO convert over to a more generic config structure

namespace ModifiedAskSet
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    //[NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class ModifiedAskSet : BaseUnityPlugin
    {
        public const string PluginGUID = "com.jumb0frame.ModifiedAskSet";
        public const string PluginName = "ModifiedAskSet";
        public const string PluginVersion = "0.0.1";
        
        // Use this class to add your own localization to the game
        // https://valheim-modding.github.io/Jotunn/tutorials/localization.html
        public static CustomLocalization Localization = LocalizationManager.Instance.GetLocalization();

        private static SE_Stats SetEffects;

        private void Awake()
        {
            // Jotunn comes with its own Logger class to provide a consistent Log style for all mods using it
            Jotunn.Logger.LogInfo("ModifiedAskSet has landed");

            SetStatusEffects();

            try
            {
                PrefabManager.OnVanillaPrefabsAvailable += AddModifiedAsksvinArmor;
                Jotunn.Logger.LogInfo(SetEffects.GetTooltipString());

            }
            catch (Exception e)
            {
                Jotunn.Logger.LogInfo(e);
            }
        }
        private void AddModifiedAsksvinArmor()
        {
            //hood
            ItemConfig askHoodConfig = new ItemConfig();
            askHoodConfig.Name = "Better Ask Hood Config";
            askHoodConfig.Description = "Better Ask Hood description config";
            askHoodConfig.CraftingStation = "blackforge";
            askHoodConfig.AddRequirement(new RequirementConfig("MoltenCore", 2));
            askHoodConfig.AddRequirement(new RequirementConfig("LinenThread", 15));
            askHoodConfig.AddRequirement(new RequirementConfig("AskHide", 10));
            askHoodConfig.AddRequirement(new RequirementConfig("LoxPelt", 4));

            CustomItem askHood = new CustomItem("ModifiedAskHood", "HelmetAshlandsMediumHood", askHoodConfig);
            ItemManager.Instance.AddItem(askHood);

            var askHoodDrop = askHood.ItemDrop;
            askHoodDrop.m_itemData.m_shared.m_name = "Better Ask Hood";
            askHoodDrop.m_itemData.m_shared.m_description = "Better Ask Hood description";
            askHoodDrop.m_itemData.m_shared.m_setName = "Modified Ask Set";
            askHoodDrop.m_itemData.m_shared.m_setSize = 3;
            askHoodDrop.m_itemData.m_shared.m_setStatusEffect = (StatusEffect)(object)SetEffects;



            //chest
            ItemConfig askChestConfig = new ItemConfig();
            askChestConfig.Name = "Better Ask Chest Config";
            askChestConfig.Description = "Better Ask Chest description config";
            askChestConfig.CraftingStation = "blackforge";
            askChestConfig.AddRequirement(new RequirementConfig("MoltenCore", 2));
            askChestConfig.AddRequirement(new RequirementConfig("LinenThread", 15));
            askChestConfig.AddRequirement(new RequirementConfig("AskHide", 10));
            askChestConfig.AddRequirement(new RequirementConfig("LoxPelt", 4));

            CustomItem askChest = new CustomItem("ModifiedAskChest", "ArmorAshlandsMediumChest", askChestConfig);
            ItemManager.Instance.AddItem(askChest);

            var askChestDrop = askChest.ItemDrop;
            askChestDrop.m_itemData.m_shared.m_name = "Better Ask Chest";
            askChestDrop.m_itemData.m_shared.m_description = "Better Ask Chest description";
            askChestDrop.m_itemData.m_shared.m_setName = "Modified Ask Set";
            askChestDrop.m_itemData.m_shared.m_setSize = 3;
            askChestDrop.m_itemData.m_shared.m_setStatusEffect = (StatusEffect)(object)SetEffects;

            //legs
            ItemConfig askLegsConfig = new ItemConfig();
            askLegsConfig.Name = "Better Ask Legs Config";
            askLegsConfig.Description = "Better Ask Legs description config";
            askLegsConfig.CraftingStation = "blackforge";
            askLegsConfig.AddRequirement(new RequirementConfig("MoltenCore", 2));
            askLegsConfig.AddRequirement(new RequirementConfig("LinenThread", 15));
            askLegsConfig.AddRequirement(new RequirementConfig("AskHide", 10));
            askLegsConfig.AddRequirement(new RequirementConfig("LoxPelt", 4));

            CustomItem askLegs = new CustomItem("ModifiedAskLegs", "ArmorAshlandsMediumlegs", askLegsConfig);
            ItemManager.Instance.AddItem(askLegs);

            var askLegsDrop = askLegs.ItemDrop;
            askLegsDrop.m_itemData.m_shared.m_name = "Better Ask Legs";
            askLegsDrop.m_itemData.m_shared.m_description = "Better Ask Legs description";
            askLegsDrop.m_itemData.m_shared.m_setName = "Modified Ask Set";
            askLegsDrop.m_itemData.m_shared.m_setSize = 3;
            askLegsDrop.m_itemData.m_shared.m_setStatusEffect = (StatusEffect)(object)SetEffects;

            PrefabManager.OnVanillaPrefabsAvailable -= AddModifiedAsksvinArmor;
        }

        private void SetStatusEffects()
        {
            try
            {
                SetEffects = ScriptableObject.CreateInstance<SE_Stats>();
                ((UnityEngine.Object)SetEffects).name = "Modified Ask Effect";
                SetEffects.m_name = "Better Ask's Endurance";
                SetEffects.m_tooltip = "Better Ask's tooltip";
                SetEffects.m_percentigeDamageModifiers.m_slash = 0.15f;
                SetEffects.m_percentigeDamageModifiers.m_pierce = 0.15f;
                SetEffects.m_attackStaminaUseModifier = -0.2f;
                SetEffects.m_runStaminaUseModifier = -0.1f;
                SetEffects.m_jumpStaminaUseModifier = -0.1f;
            }
            catch (Exception e)
            {
                Jotunn.Logger.LogInfo(e);
            }

        }
    }
}

