using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;

namespace RecruitRefresher
{
    /// <summary>
    /// Runtime helpers that enforce full volunteer slots on notables.
    /// </summary>
    internal static class RecruitVolunteerRuntime
    {
        internal static int EnsureMaximumVolunteersForSettlement(Settlement settlement)
        {
            if (settlement == null || Campaign.Current?.Models?.VolunteerModel == null)
            {
                return 0;
            }

            int changedNotables = 0;

            foreach (Hero notable in settlement.Notables)
            {
                if (notable == null || !notable.IsAlive || !notable.CanHaveRecruits)
                {
                    continue;
                }

                CharacterObject basicVolunteer = Campaign.Current.Models.VolunteerModel.GetBasicVolunteer(notable);
                if (FillVolunteerSlots(notable.VolunteerTypes, basicVolunteer))
                {
                    changedNotables++;
                }
            }

            return changedNotables;
        }

        internal static bool FillVolunteerSlots(CharacterObject[] volunteerTypes, CharacterObject basicVolunteer)
        {
            if (volunteerTypes == null || basicVolunteer == null)
            {
                return false;
            }

            bool changed = false;
            int slotCount = volunteerTypes.Length < 6 ? volunteerTypes.Length : 6;

            for (int i = 0; i < slotCount; i++)
            {
                if (volunteerTypes[i] == null)
                {
                    volunteerTypes[i] = basicVolunteer;
                    changed = true;
                }
            }

            return changed;
        }
    }
}
