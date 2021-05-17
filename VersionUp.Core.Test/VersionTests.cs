using Microsoft.VisualStudio.TestTools.UnitTesting;

/// <summary>
/// [Major].[Minor].[Revision].[BuildNumber]
/// </summary>
namespace VersionUp.Core.Test
{
    [TestClass]
    public class VersionTests
    {
        [TestMethod
            ,DataRow(new string[] {"0","0","0","1" },"2")
            , DataRow(new string[] { "0", "0", "0", "512" },"513")
            , DataRow(new string[] { "0", "0", "0", "6550" },"6551")]
        public void BuildNumber_WhenApplicationRun_IncrementOne(string[] versionDetails, string expectedBuildNumber)
        {
            //arrange
            var version = new Version(versionDetails);
            //act
            version.Renew();
            //assert
            Assert.AreEqual(version.BuildNumber, expectedBuildNumber);
        }

        [TestMethod]
        public void BuildNumberIsEqualTo65535_WhenApplicationRun_BuildNumberBecomeZeroAndRevisionIncrementOne()
        {
            //arrange
            var version = new Version(new string[] { "0", "0", "0", "65535" });
            var revision = version.GenerateRevision();
            //act
            version.Renew();
            var expectedRevision = version.Revision;
            //assert
            Assert.AreEqual(revision, (int.Parse(expectedRevision) - 1).ToString());
            Assert.AreEqual(version.BuildNumber, "0");
        }

        [TestMethod]
        public void Main_CallWithoutPassingParameter_ThrowError() 
        {
            //act
            var result = Program.Main(new string[] { });
            //assert
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void Main_PassingWrongParameter_ThrowError()
        {
            //act
            var result = Program.Main(new string[] { });
            //assert
            Assert.AreEqual(result, 1);
        }
    }
}
