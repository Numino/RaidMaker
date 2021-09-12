using System.Collections.Generic;
using NUnit.Framework;
using RaidMaker.Core;
using RaidMaker.Tests.Helpers;

namespace RaidMaker.Tests
{
    [TestFixture]
    public class PossibleRaidCompTests
    {
        private List<PossibleRaidComp> _result;

        [OneTimeSetUp]
        public void Setup()
        {
            var subject = new TheRaidMaker();
            var raid = new DiscordParser().Parse(EmbeddedResourceHelper.GetLinesFromEmbeddedResource("RaidMaker.Tests.TestData.wedsgruulmag.txt"));
            _result = subject.CompsFor(4, 5, new List<DiscordRaid>{raid});
        }

        [Test]
        public void Test()
        {
            
        }
        
    }
}