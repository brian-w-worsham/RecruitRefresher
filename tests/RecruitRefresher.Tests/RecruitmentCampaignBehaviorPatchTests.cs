using RecruitRefresher.Patches;
using TaleWorlds.CampaignSystem.Settlements;
using Xunit;

namespace RecruitRefresher.Tests
{
    public class RecruitmentCampaignBehaviorPatchTests
    {
        [Fact]
        public void Postfix_InvokesRuntimeHook()
        {
            int callCount = 0;
            RecruitmentCampaignBehaviorPatch.EnsureSettlementVolunteers = _ =>
            {
                callCount++;
                return 1;
            };

            RecruitmentCampaignBehaviorPatch.Postfix(null);

            Assert.Equal(1, callCount);
            RecruitmentCampaignBehaviorPatch.ResetHooks();
        }

        [Fact]
        public void ResetHooks_RestoresDefaultDelegate()
        {
            RecruitmentCampaignBehaviorPatch.EnsureSettlementVolunteers = _ => 42;

            RecruitmentCampaignBehaviorPatch.ResetHooks();

            Assert.NotNull(RecruitmentCampaignBehaviorPatch.EnsureSettlementVolunteers);
        }
    }
}
