using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;

namespace RecruitRefresher
{
    /// <summary>
    /// Core logic for refreshing recruits in settlements.
    /// Provides methods to calculate and apply recruit replenishment.
    /// </summary>
    public static class RecruitRefresherLogic
    {
        /// <summary>
        /// The default maximum recruits available in settlements daily.
        /// This matches Bannerlord's base recruit pool.
        /// </summary>
        public const int DefaultMaxRecruitsPerDay = 10;

        /// <summary>
        /// Calculates the maximum number of recruits that should be available in a town.
        /// Based on town prosperity.
        /// </summary>
        /// <param name="town">The town to calculate max recruits for.</param>
        /// <returns>The maximum number of recruits available.</returns>
        public static int CalculateTownMaxRecruits(Town town)
        {
            if (town == null)
            {
                return 0;
            }

            return CalculateTownMaxRecruits(town.Prosperity);
        }

        /// <summary>
        /// Calculates the maximum number of recruits that should be available in a town
        /// from raw prosperity, for tests and pure logic usage.
        /// </summary>
        /// <param name="prosperity">Town prosperity.</param>
        /// <returns>The maximum number of recruits available.</returns>
        public static int CalculateTownMaxRecruits(float prosperity)
        {
            if (prosperity <= 0f)
            {
                return DefaultMaxRecruitsPerDay;
            }

            // Base calculation for town recruitment
            // Increased prosperity leads to more available recruits
            int baseRecruits = DefaultMaxRecruitsPerDay;
            
            // Add prosperity-based bonus
            int prosperityBonus = (int)(prosperity / 500f); // 500 prosperity = +1 recruit

            return baseRecruits + prosperityBonus;
        }

        /// <summary>
        /// Calculates the maximum number of recruits that should be available in a village.
        /// Based on village hearth population (population size).
        /// </summary>
        /// <param name="village">The village to calculate max recruits for.</param>
        /// <returns>The maximum number of recruits available.</returns>
        public static int CalculateVillageMaxRecruits(Village village)
        {
            if (village == null)
            {
                return 0;
            }

            return CalculateVillageMaxRecruits(village.Hearth);
        }

        /// <summary>
        /// Calculates the maximum number of recruits that should be available in a village
        /// from raw hearth value, for tests and pure logic usage.
        /// </summary>
        /// <param name="hearth">Village hearth value.</param>
        /// <returns>The maximum number of recruits available.</returns>
        public static int CalculateVillageMaxRecruits(float hearth)
        {
            if (hearth <= 0f)
            {
                return 5;
            }

            // Village base: hearth-based recruitment
            // Higher hearth (population) = more recruits
            int hearths = (int)hearth;
            int baseRecruits = 5 + (hearths / 100); // Base 5, +1 per 100 hearths

            // Cap at 20 for balance
            return System.Math.Min(baseRecruits, 20);
        }
    }
}
