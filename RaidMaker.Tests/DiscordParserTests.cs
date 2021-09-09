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
        
        [Test]
        public void ThenTheHealersAreParsed()
        {
            var healers = _result.Players.Where(x=> x.Role == Role.Healer).ToList();
            
            Assert.That(healers[0].Class, Is.EqualTo(Class.Druid));
            Assert.That(healers[0].Name, Is.EqualTo("gamble/savyg"));
            Assert.That(healers[0].SignUpPosition, Is.EqualTo(2));
                
            Assert.That(healers[1].Class, Is.EqualTo(Class.Druid));
            Assert.That(healers[1].Name, Is.EqualTo("Zedeskia"));
            Assert.That(healers[1].SignUpPosition, Is.EqualTo(9));
                
            Assert.That(healers[2].Class, Is.EqualTo(Class.Paladin));
            Assert.That(healers[2].Name, Is.EqualTo("Evola"));
            Assert.That(healers[2].SignUpPosition, Is.EqualTo(12));
                
            Assert.That(healers[3].Class, Is.EqualTo(Class.Paladin));
            Assert.That(healers[3].Name, Is.EqualTo("Maevey"));
            Assert.That(healers[3].SignUpPosition, Is.EqualTo(21));
            
            Assert.That(healers[4].Class, Is.EqualTo(Class.Paladin));
            Assert.That(healers[4].Name, Is.EqualTo("celany"));
            Assert.That(healers[4].SignUpPosition, Is.EqualTo(22));
            
            Assert.That(healers[5].Class, Is.EqualTo(Class.Priest));
            Assert.That(healers[5].Name, Is.EqualTo("Aara"));
            Assert.That(healers[5].SignUpPosition, Is.EqualTo(15));
                
            Assert.That(healers[6].Class, Is.EqualTo(Class.Priest));
            Assert.That(healers[6].Name, Is.EqualTo("Trollfark"));
            Assert.That(healers[6].SignUpPosition, Is.EqualTo(17));
            
            Assert.That(healers[7].Class, Is.EqualTo(Class.Shaman));
            Assert.That(healers[7].Name, Is.EqualTo("Trynet"));
            Assert.That(healers[7].SignUpPosition, Is.EqualTo(30));
        }
    }
}