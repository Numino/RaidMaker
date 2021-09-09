﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace RaidMaker.Core
{
    public class DiscordParser
    {
        public DiscordRaid Parse(string input)
        {
            var lines = input.Split("\r\n");
            var tankLine = 0;
            var players = new List<Player>();

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];

                if (line.Contains(":Tank:"))
                    tankLine = i;
            }

            while (true)
            {
                tankLine += 1;
                var line = lines[tankLine];
                if (!line.StartsWith(":Guardian") && !line.StartsWith(":Prot") && !line.StartsWith("Blood"))
                    break;
                var split = line.Replace(":", "").Split(" ");
                Class playerClass = Class.Unknown;
                var classString = split[0];
                if (classString == "Protection")
                    playerClass = Class.Warrior;
                if (classString == "Protection1")
                    playerClass = Class.Paladin;
                if (classString == "Guardian")
                    playerClass = Class.Druid;
                players.Add(new Player {Role = Role.Tank, Class = playerClass, Name = split[2], SignUpPosition = int.Parse(split[1])});
            }
            


            return new DiscordRaid
            {
                Title = lines[1].Replace(" ", "").Replace(":", "").Replace("empty", " "),
                SubTitle = lines[3],
                Date = DateTime.ParseExact(lines[6].Replace(":CMcalendar: ", ""), "d MMMM yyyy", CultureInfo.InvariantCulture),
                Players = players
            };
        }
    }

    public class DiscordRaid
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public List<Player> Players { get; set; }
    }

    public class Player
    {
        public Class Class { get; set; }
        public Spec Spec { get; set; }
        public Role Role { get; set; }
        public string Name { get; set; }
        public int SignUpPosition { get; set; }
    }

    public enum Role
    {
        Unknown = 0,
        Tank = 1,
        Healer = 2,
        Dps = 3
    }

    public enum Class
    {
        Unknown = 0,
        Warrior = 1,
        Paladin = 2,
        Shaman = 3,
        Rogue = 4,
        Hunter = 5,
        Druid = 6,
        Priest = 7,
        Mage = 8,
        Warlock = 9,
        DeathKnight = 10
    }

    public enum Spec
    {
        Unknown = 0,
    }
}