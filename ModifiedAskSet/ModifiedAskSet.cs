using System;
using BepInEx;
using Jotunn.Utils;
using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;

//TODO convert over to a more generic config structure

namespace ModifiedAskSet
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class ModifiedAskSet : BaseUnityPlugin
    {
        public const string PluginGUID = "com.jumb0frame.ModifiedAskSet";
        public const string PluginName = "ModifiedAskSet";
        public const string PluginVersion = "1.0.0";
        
        // Use this class to add your own localization to the game
        // https://valheim-modding.github.io/Jotunn/tutorials/localization.html
        public static CustomLocalization Localization = LocalizationManager.Instance.GetLocalization();

        //set status effects config
        private static StatusEffectsConfig setStatusEffects;
        //equip status effects config
        private static StatusEffectsConfig hoodEquipEffects;
        private static StatusEffectsConfig chestEquipEffects;
        private static StatusEffectsConfig legsEquipEffects;
        //armor config
        private static ArmorConfig hoodArmorConfig;
        private static ArmorConfig chestArmorConfig;
        private static ArmorConfig legsArmorConfig;
        //craft config
        private static RecipeConfig hoodRecipeConfig;
        private static RecipeConfig chestRecipeConfig;
        private static RecipeConfig legsRecipeConfig;


        private void Awake()
        {
            // Jotunn comes with its own Logger class to provide a consistent Log style for all mods using it
            Jotunn.Logger.LogInfo("ModifiedAskSet has landed");

            try
            {
                //set effects config
                setStatusEffects = new StatusEffectsConfig("Modified Ask Effect", "Better Ask's Endurance", "Better Ask's tooltip");
                setStatusEffects.SEAttackConfig(0f, 0.15f, 0.15f, 0f, 0f, 0f, 0f, 0f, 0f, 0f);
                setStatusEffects.SEStaminaConfig(0f, 0f, 0f, -0.1f, -0.1f, -0.2f, 0f, 0f, 0f, 0f, 0f, 0f);
                
                //get the armor going
                PrefabManager.OnVanillaPrefabsAvailable += AddModifiedAsksvinArmor;
            }
            catch (Exception e)
            {
                Jotunn.Logger.LogInfo(e);
            }
        }
        private void AddModifiedAsksvinArmor()
        {
            //get set effects
            SE_Stats setEffects = setStatusEffects.getSetEffects();

            //todo : equip effects for each piece if anych

            //hood
            hoodRecipeConfig = new RecipeConfig("Better Ask Hood Config", "Better Ask Hood description config", "blackforge", "blackforge", 3, new RequirementConfig("MoltenCore", 2, 1),
                                                new RequirementConfig("LinenThread", 15, 10), new RequirementConfig("AskHide", 10, 5), new RequirementConfig("LoxPelt", 4, 2));
            hoodArmorConfig = new ArmorConfig("Better Ask Hood", "Better Ask Hood description", 4, 1f, null, "Modified Ask Set", 3, setEffects, 0f, 28f, 2f, 1000f, 200f, 0f);
            CustomItem askHood = new CustomItem("ModifiedAskHood", "HelmetAshlandsMediumHood", hoodRecipeConfig.GetRecipeConfig());
            ItemManager.Instance.AddItem(askHood);
            hoodArmorConfig.ApplyConfig(askHood.ItemDrop);


            //chest
            chestRecipeConfig = new RecipeConfig("Better Ask Chest Config", "Better Ask Chest description config", "blackforge", "blackforge", 3, new RequirementConfig("MoltenCore", 2, 1),
                                                new RequirementConfig("LinenThread", 15, 10), new RequirementConfig("AskHide", 10, 5), new RequirementConfig("LoxPelt", 4, 2));
            chestArmorConfig = new ArmorConfig("Better Ask Chest", "Better Ask Chest description", 4, 5f, null, "Modified Ask Set", 3, setEffects, 0f, 28f, 2f, 1000f, 200f, 0f);
            CustomItem askChest = new CustomItem("ModifiedAskChest", "ArmorAshlandsMediumChest", chestRecipeConfig.GetRecipeConfig());
            ItemManager.Instance.AddItem(askChest);
            chestArmorConfig.ApplyConfig(askChest.ItemDrop);

            //legs
            legsRecipeConfig = new RecipeConfig("Better Ask Legs Config", "Better Ask Legs description config", "blackforge", "blackforge", 3, new RequirementConfig("MoltenCore", 2, 1),
                                                new RequirementConfig("LinenThread", 15, 10), new RequirementConfig("AskHide", 10, 5), new RequirementConfig("LoxPelt", 4, 2));
            legsArmorConfig = new ArmorConfig("Better Ask Legs", "Better Ask Legs description", 4, 5f, null, "Modified Ask Set", 3, setEffects, 0f, 28f, 2f, 1000f, 200f, 0f);
            CustomItem askLegs = new CustomItem("ModifiedAskLegs", "ArmorAshlandsMediumlegs", legsRecipeConfig.GetRecipeConfig());
            ItemManager.Instance.AddItem(askLegs);
            legsArmorConfig.ApplyConfig(askLegs.ItemDrop);

            PrefabManager.OnVanillaPrefabsAvailable -= AddModifiedAsksvinArmor;
            
        }
    }
}

