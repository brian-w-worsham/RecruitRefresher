using Xunit;
using RecruitRefresher;

namespace RecruitRefresher.Tests
{
    /// <summary>
    /// Tests for the RecruitRefresherLogic core functionality.
    /// </summary>
    public class RecruitRefresherLogicTests
    {
        [Theory]
        [InlineData(0, 10)]
        [InlineData(500, 11)]
        [InlineData(1000, 12)]
        [InlineData(2500, 15)]
        public void CalculateTownMaxRecruits_ReturnsExpectedValue(int prosperity, int expected)
        {
            var result = RecruitRefresherLogic.CalculateTownMaxRecruits(prosperity);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(100, 6)]
        [InlineData(500, 10)]
        [InlineData(1000, 15)]
        [InlineData(5000, 20)]
        [InlineData(10000, 20)]
        public void CalculateVillageMaxRecruits_ReturnsExpectedValue(int hearth, int expected)
        {
            var result = RecruitRefresherLogic.CalculateVillageMaxRecruits(hearth);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculateTownMaxRecruits_ReturnsZeroWhenTownIsNull()
        {
            var result = RecruitRefresherLogic.CalculateTownMaxRecruits(null);

            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculateVillageMaxRecruits_ReturnsZeroWhenVillageIsNull()
        {
            var result = RecruitRefresherLogic.CalculateVillageMaxRecruits(null);

            Assert.Equal(0, result);
        }
    }
}
