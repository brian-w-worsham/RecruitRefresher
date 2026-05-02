using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.CampaignSystem.Settlements;

namespace RecruitRefresher.Patches
{
    [HarmonyPatch(
        typeof(DefaultVolunteerModel),
        nameof(DefaultVolunteerModel.GetDailyVolunteerProductionProbability),
        new[] { typeof(Hero), typeof(int), typeof(Settlement) })]
    internal static class GetDailyVolunteerProductionProbabilityPatch
    {
        internal static float ApplyOverride(Hero hero, Settlement settlement, float originalProbability)
        {
            return VolunteerModelRuntime.GetDailyVolunteerProductionProbability(hero, settlement, originalProbability);
        }

        internal static void Postfix(Hero hero, Settlement settlement, ref float __result)
        {
            __result = ApplyOverride(hero, settlement, __result);
        }
    }

    [HarmonyPatch(
        typeof(DefaultVolunteerModel),
        nameof(DefaultVolunteerModel.MaximumIndexHeroCanRecruitFromHero),
        new[] { typeof(Hero), typeof(Hero), typeof(int) })]
    internal static class MaximumIndexHeroCanRecruitFromHeroPatch
    {
        internal static int ApplyOverride(Hero buyerHero, Hero sellerHero, int originalMaximumIndex)
        {
            return VolunteerModelRuntime.GetMaximumRecruitIndex(buyerHero, sellerHero, originalMaximumIndex);
        }

        internal static void Postfix(Hero buyerHero, Hero sellerHero, ref int __result)
        {
            __result = ApplyOverride(buyerHero, sellerHero, __result);
        }
    }
}