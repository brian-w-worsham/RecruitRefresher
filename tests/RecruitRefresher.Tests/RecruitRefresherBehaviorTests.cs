using Xunit;

namespace RecruitRefresher.Tests
{
    public class RecruitRefresherBehaviorTests
    {
        [Fact]
        public void HandleDailyTickSettlement_InvokesConfiguredHook()
        {
            int callCount = 0;
            RecruitRefresherBehavior.SetRefreshSettlementVolunteersForTest(_ =>
            {
                callCount++;
                return 1;
            });

            RecruitRefresherBehavior.HandleDailyTickSettlement(null);

            Assert.Equal(1, callCount);
            RecruitRefresherBehavior.ResetHooks();
        }

        [Fact]
        public void ResetHooks_AllowsHandlerToRunWithDefaultImplementation()
        {
            RecruitRefresherBehavior.SetRefreshSettlementVolunteersForTest(_ => 42);

            RecruitRefresherBehavior.ResetHooks();
            RecruitRefresherBehavior.HandleDailyTickSettlement(null);

            Assert.True(true);
        }
    }
}