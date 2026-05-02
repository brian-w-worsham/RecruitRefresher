using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;

namespace RecruitRefresher
{
    /// <summary>
    /// Pure helper methods used by Harmony patches that override Bannerlord's
    /// volunteer production and recruit-access calculations.
    /// </summary>
    internal static class VolunteerModelRuntime
    {
        internal const float GuaranteedDailyVolunteerProductionProbability = 1f;
        internal const int MaximumRecruitSlots = 6;

        internal static bool ShouldGuaranteeDailyVolunteerProduction(
            bool notableIsAlive,
            bool notableCanHaveRecruits,
            bool settlementIsTown,
            bool settlementIsVillage)
        {
            return notableIsAlive
                && notableCanHaveRecruits
                && (settlementIsTown || settlementIsVillage);
        }

        internal static float GetDailyVolunteerProductionProbability(
            bool notableIsAlive,
            bool notableCanHaveRecruits,
            bool settlementIsTown,
            bool settlementIsVillage,
            float originalProbability)
        {
            return ShouldGuaranteeDailyVolunteerProduction(
                notableIsAlive,
                notableCanHaveRecruits,
                settlementIsTown,
                settlementIsVillage)
                ? GuaranteedDailyVolunteerProductionProbability
                : originalProbability;
        }

        internal static float GetDailyVolunteerProductionProbability(Hero hero, Settlement settlement, float originalProbability)
        {
            if (hero == null || settlement == null)
            {
                return originalProbability;
            }

            return GetDailyVolunteerProductionProbability(
                hero.IsAlive,
                hero.CanHaveRecruits,
                settlement.IsTown,
                settlement.IsVillage,
                originalProbability);
        }

        internal static int GetMaximumRecruitIndex(
            bool buyerIsMainHero,
            bool sellerIsAlive,
            bool sellerCanHaveRecruits,
            bool settlementIsTown,
            bool settlementIsVillage,
            int originalMaximumIndex)
        {
            if (!buyerIsMainHero || !sellerIsAlive || !sellerCanHaveRecruits || (!settlementIsTown && !settlementIsVillage))
            {
                return originalMaximumIndex;
            }

            return originalMaximumIndex >= MaximumRecruitSlots
                ? originalMaximumIndex
                : MaximumRecruitSlots;
        }

        internal static int GetMaximumRecruitIndex(Hero buyerHero, Hero sellerHero, int originalMaximumIndex)
        {
            if (buyerHero == null || sellerHero == null)
            {
                return originalMaximumIndex;
            }

            Settlement settlement = sellerHero.CurrentSettlement;
            return GetMaximumRecruitIndex(
                buyerIsMainHero: buyerHero == Hero.MainHero,
                sellerHero.IsAlive,
                sellerHero.CanHaveRecruits,
                settlement?.IsTown == true,
                settlement?.IsVillage == true,
                originalMaximumIndex);
        }
    }
}