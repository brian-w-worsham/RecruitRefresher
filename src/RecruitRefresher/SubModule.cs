using System;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace RecruitRefresher
{
    /// <summary>
    /// Entry point for the RecruitRefresher mod. Applies Harmony patches
    /// so towns and villages refill their recruits daily to maximum capacity.
    /// </summary>
    public class SubModule : MBSubModuleBase
    {
        private Harmony _harmony;

        /// <summary>
        /// Called when the module is first loaded.
        /// </summary>
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();

            try
            {
                _harmony = new Harmony("com.recruitrefresher.bannerlord");
                _harmony.PatchAll();
                InformationManager.DisplayMessage(
                    new InformationMessage("Recruit Refresher: Loaded successfully.", Colors.Green));
            }
            catch (Exception ex)
            {
                InformationManager.DisplayMessage(
                    new InformationMessage($"Recruit Refresher load error: {ex.Message}", Colors.Red));
            }
        }

        /// <summary>
        /// Called when the module is unloaded. Reverts all Harmony patches
        /// applied by this mod.
        /// </summary>
        protected override void OnSubModuleUnloaded()
        {
            base.OnSubModuleUnloaded();
            _harmony?.UnpatchAll("com.recruitrefresher.bannerlord");
        }
    }
}
