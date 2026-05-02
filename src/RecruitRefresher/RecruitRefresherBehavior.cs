using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;

namespace RecruitRefresher
{
    /// <summary>
    /// Public campaign behavior that guarantees settlement volunteer top-ups
    /// through Bannerlord's public daily settlement event pipeline.
    /// </summary>
    public class RecruitRefresherBehavior : CampaignBehaviorBase
    {
        private static Func<Settlement, int> _refreshSettlementVolunteers =
            RecruitVolunteerRuntime.EnsureMaximumVolunteersForSettlement;

        public override void RegisterEvents()
        {
            CampaignEvents.DailyTickSettlementEvent.AddNonSerializedListener(this, OnDailyTickSettlement);
        }

        public override void SyncData(IDataStore dataStore)
        {
        }

        internal static void ResetHooks()
        {
            _refreshSettlementVolunteers = RecruitVolunteerRuntime.EnsureMaximumVolunteersForSettlement;
        }

        internal static void SetRefreshSettlementVolunteersForTest(Func<Settlement, int> refreshSettlementVolunteers)
        {
            _refreshSettlementVolunteers = refreshSettlementVolunteers ?? RecruitVolunteerRuntime.EnsureMaximumVolunteersForSettlement;
        }

        internal static void HandleDailyTickSettlement(Settlement settlement)
        {
            _refreshSettlementVolunteers(settlement);
        }

        private static void OnDailyTickSettlement(Settlement settlement)
        {
            HandleDailyTickSettlement(settlement);
        }
    }
}