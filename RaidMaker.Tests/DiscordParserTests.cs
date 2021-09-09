using System;
using System.Linq;
using NUnit.Framework;
using RaidMaker.Core;
using RaidMaker.Tests.Helpers;

namespace RaidMaker.Tests
{
    [TestFixture]
    public class GivenATestForMondaySscTk
    {
        private DiscordRaid _result;

        [OneTimeSetUp]
        public void WhenParsing()
        {
            var subject = new DiscordParser();
            _result = subject.Parse(EmbeddedResourceHelper.GetLinesFromEmbeddedResource("RaidMaker.Tests.TestData.mondayssctk.txt"));
        }

        [Test]
        public void ThenTheRaidMetaInfoIsParsedCorrectly()
        {
            Assert.That(_result.Date.Date, Is.EqualTo(DateTime.Parse("2021-09-20")));
            Assert.That(_result.Title, Is.EqualTo("MONDAY 25MAN"));
            Assert.That(_result.SubTitle, Is.EqualTo("Come clear SSC / TK"));
        }

        [Test]
        public void ThenTheTanksAreParsed()
        {
            var tanks = _result.Players.Where(x=> x.Role == Role.Tank).ToList();
            
            Assert.That(tanks[0].Class, Is.EqualTo(Class.Warrior));
            Assert.That(tanks[0].Name, Is.EqualTo("Flisfan"));
            Assert.That(tanks[0].SignUpPosition, Is.EqualTo(11));
                
            Assert.That(tanks[1].Class, Is.EqualTo(Class.Paladin));
            Assert.That(tanks[1].Name, Is.EqualTo("yeb"));
            Assert.That(tanks[1].SignUpPosition, Is.EqualTo(14));
                
            Assert.That(tanks[2].Class, Is.EqualTo(Class.Paladin));
            Assert.That(tanks[2].Name, Is.EqualTo("Alzalahina"));
            Assert.That(tanks[2].SignUpPosition, Is.EqualTo(28));
                
            Assert.That(tanks[3].Class, Is.EqualTo(Class.Druid));
            Assert.That(tanks[3].Name, Is.EqualTo("Lyri"));
            Assert.That(tanks[3].SignUpPosition, Is.EqualTo(37));
        }
    }
}