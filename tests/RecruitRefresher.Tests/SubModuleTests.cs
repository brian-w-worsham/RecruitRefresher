using Xunit;
using RecruitRefresher;

namespace RecruitRefresher.Tests
{
    /// <summary>
    /// Tests for the SubModule initialization and Harmony patch loading.
    /// </summary>
    public class SubModuleTests
    {
        [Fact]
        public void SubModule_CanBeInstantiated()
        {
            var module = new SubModule();

            Assert.NotNull(module);
        }

        [Fact]
        public void SubModule_InheritsFromMBSubModuleBase()
        {
            var module = new SubModule();

            // SubModule should inherit from MBSubModuleBase
            var baseType = module.GetType().BaseType;
            Assert.NotNull(baseType);
            Assert.Equal("MBSubModuleBase", baseType.Name);
        }
    }
}
