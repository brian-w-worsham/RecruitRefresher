using System.Runtime.Serialization;
using TaleWorlds.CampaignSystem;
using Xunit;

namespace RecruitRefresher.Tests
{
    public class RecruitVolunteerRuntimeTests
    {
        [Fact]
        public void FillVolunteerSlots_ReturnsFalse_WhenVolunteerArrayIsNull()
        {
            CharacterObject basicVolunteer = CreateCharacter();

            bool changed = RecruitVolunteerRuntime.FillVolunteerSlots(null, basicVolunteer);

            Assert.False(changed);
        }

        [Fact]
        public void FillVolunteerSlots_ReturnsFalse_WhenBasicVolunteerIsNull()
        {
            var slots = new CharacterObject[6];

            bool changed = RecruitVolunteerRuntime.FillVolunteerSlots(slots, null);

            Assert.False(changed);
        }

        [Fact]
        public void FillVolunteerSlots_FillsAllMissingSlots_UpToSix()
        {
            CharacterObject basicVolunteer = CreateCharacter();
            var slots = new CharacterObject[6];
            slots[1] = CreateCharacter();

            bool changed = RecruitVolunteerRuntime.FillVolunteerSlots(slots, basicVolunteer);

            Assert.True(changed);
            Assert.NotNull(slots[0]);
            Assert.NotNull(slots[2]);
            Assert.NotNull(slots[3]);
            Assert.NotNull(slots[4]);
            Assert.NotNull(slots[5]);
            Assert.NotNull(slots[1]);
        }

        [Fact]
        public void FillVolunteerSlots_DoesNothing_WhenAllSixSlotsAlreadyFilled()
        {
            CharacterObject basicVolunteer = CreateCharacter();
            var slots = new CharacterObject[6];
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i] = CreateCharacter();
            }

            bool changed = RecruitVolunteerRuntime.FillVolunteerSlots(slots, basicVolunteer);

            Assert.False(changed);
        }

        [Fact]
        public void FillVolunteerSlots_OnlyTouchesFirstSixSlots()
        {
            CharacterObject basicVolunteer = CreateCharacter();
            var slots = new CharacterObject[8];

            bool changed = RecruitVolunteerRuntime.FillVolunteerSlots(slots, basicVolunteer);

            Assert.True(changed);
            Assert.NotNull(slots[0]);
            Assert.NotNull(slots[5]);
            Assert.Null(slots[6]);
            Assert.Null(slots[7]);
        }

        private static CharacterObject CreateCharacter()
        {
            return (CharacterObject)FormatterServices.GetUninitializedObject(typeof(CharacterObject));
        }
    }
}
