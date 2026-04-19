using System;
using HarmonyLib;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.Settlements;

namespace RecruitRefresher.Patches
{
    [HarmonyPatch(
        typeof(RecruitmentCampaignBehavior),
        "UpdateVolunteersOfNotablesInSettlement",
        new[] { typeof(Settlement) })]
    internal static class RecruitmentCampaignBehaviorPatch
    {
        internal static Func<Settlement, int> EnsureSettlementVolunteers =
            RecruitVolunteerRuntime.EnsureMaximumVolunteersForSettlement;

        internal static void ResetHooks()
        {
            EnsureSettlementVolunteers = RecruitVolunteerRuntime.EnsureMaximumVolunteersForSettlement;
        }

        internal static void Postfix(Settlement settlement)
        {
            EnsureSettlementVolunteers(settlement);
        }
    }
}
