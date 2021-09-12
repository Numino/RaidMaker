using System.Collections.Generic;
using System.Linq;

namespace RaidMaker.Core
{
    public class TheRaidMaker
    {
        static List<List<T>> GetCombinations<T>(List<T> list, int length)//FROM Pengyang at https://stackoverflow.com/questions/1952153/what-is-the-best-way-to-find-all-combinations-of-items-in-an-array
        {
            if (length == 1)
                return list.Select(x => new List<T>{x}).ToList();
            
            return GetCombinations(list, length - 1)
                .SelectMany(t => list.Where(o => !o.Equals(t.Last())).ToList(), 
                    (t1, t2) => t1.Concat(new T[] { t2 }).ToList()).ToList();
        }
        
        static List<List<T>> GetCombinations2<T>(List<T> list, int length)
        {
            if (length == 1)
                return list.Select(x => new List<T>{x}).ToList();

            var comps = new List<List<T>>();
            var offset = 0;
            for (var index = 0; index < list.Count; index++)
            {
                var currentPlayer = index;
                
                var item = list[index];
                var comp = new List<T>();
                for (var i = offset; i < length; i++)
                {
                   // var people = 
                }
            }

            return comps;
        }
        
        public List<PossibleRaidComp> CompsFor(int minimumNumberOfTanks, int minimumNumberOfHealers, List<DiscordRaid> raids)
        {
            var uniqueTanks = new HashSet<Player>();
            var uniqueHealers = new HashSet<Player>();

            foreach (var raid in raids)
            {
                var tanks = raid.Players.Where(x => x.Role == Role.Tank);
                foreach (var tank in tanks)
                    uniqueTanks.Add(tank);
                
                var healers = raid.Players.Where(x => x.Role == Role.Healer);
                foreach (var healer in healers)
                    uniqueHealers.Add(healer);
            }

            var availableTanks = uniqueTanks.Count;
            var numberOfComps = 0;
            while (availableTanks > minimumNumberOfTanks)
            {
                numberOfComps += 1;
                availableTanks -= minimumNumberOfTanks;
            }

            var possibleRaidComps = new List<PossibleRaidComp>();

            foreach (var raid in raids)
            {
                var possibleComps = GetCombinations(raid.Players, 25);
                foreach (var possibleComp in possibleComps)
                {
                    possibleRaidComps.Add(new PossibleRaidComp{Players = possibleComp});
                }
            }


            return possibleRaidComps;
        }
        
    }
    
    public class PossibleRaidComp
    {
        public List<Player> Players { get; set; }
    }
}