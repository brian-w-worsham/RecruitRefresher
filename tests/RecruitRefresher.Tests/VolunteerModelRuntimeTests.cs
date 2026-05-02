using RecruitRefresher.Patches;
using Xunit;

namespace RecruitRefresher.Tests
{
    public class VolunteerModelRuntimeTests
    {
        [Theory]
        [InlineData(true, true, true, false, true)]
        [InlineData(true, true, false, true, true)]
        [InlineData(true, true, false, false, false)]
        [InlineData(true, false, true, false, false)]
        [InlineData(false, true, true, false, false)]
        public void ShouldGuaranteeDailyVolunteerProduction_ReturnsExpectedValue(
            bool notableIsAlive,
            bool notableCanHaveRecruits,
            bool settlementIsTown,
            bool settlementIsVillage,
            bool expected)
        {
            bool result = VolunteerModelRuntime.ShouldGuaranteeDailyVolunteerProduction(
                notableIsAlive,
                notableCanHaveRecruits,
                settlementIsTown,
                settlementIsVillage);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(true, true, true, false, 0.05f, 1f)]
        [InlineData(true, true, false, true, 0.33f, 1f)]
        [InlineData(true, false, true, false, 0.25f, 0.25f)]
        [InlineData(false, true, true, false, 0.25f, 0.25f)]
        [InlineData(true, true, false, false, 0.25f, 0.25f)]
        public void GetDailyVolunteerProductionProbability_ReturnsExpectedValue(
            bool notableIsAlive,
            bool notableCanHaveRecruits,
            bool settlementIsTown,
            bool settlementIsVillage,
            float originalProbability,
            float expected)
        {
            float result = VolunteerModelRuntime.GetDailyVolunteerProductionProbability(
                notableIsAlive,
                notableCanHaveRecruits,
                settlementIsTown,
                settlementIsVillage,
                originalProbability);

            Assert.Equal(expected, result, 3);
        }

        [Theory]
        [InlineData(true, true, true, true, false, -1, 6)]
        [InlineData(true, true, true, false, true, 2, 6)]
        [InlineData(true, true, true, false, false, 6, 6)]
        [InlineData(false, true, true, true, false, 2, 2)]
        [InlineData(true, false, true, true, false, 2, 2)]
        [InlineData(true, true, false, false, false, 2, 2)]
        public void GetMaximumRecruitIndex_ReturnsExpectedValue(
            bool buyerIsMainHero,
            bool sellerIsAlive,
            bool sellerCanHaveRecruits,
            bool settlementIsTown,
            bool settlementIsVillage,
            int originalMaximumIndex,
            int expected)
        {
            int result = VolunteerModelRuntime.GetMaximumRecruitIndex(
                buyerIsMainHero,
                sellerIsAlive,
                sellerCanHaveRecruits,
                settlementIsTown,
                settlementIsVillage,
                originalMaximumIndex);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void DailyVolunteerProductionPatch_LeavesOriginalValue_WhenInputsAreNull()
        {
            float result = GetDailyVolunteerProductionProbabilityPatch.ApplyOverride(null, null, 0.42f);

            Assert.Equal(0.42f, result, 3);
        }

        [Fact]
        public void MaximumRecruitIndexPatch_LeavesOriginalValue_WhenInputsAreNull()
        {
            int result = MaximumIndexHeroCanRecruitFromHeroPatch.ApplyOverride(null, null, 3);

            Assert.Equal(3, result);
        }
    }
}