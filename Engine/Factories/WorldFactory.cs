using System;
using System.IO;
using System.Xml;
using Engine.Models;
using Engine.Shared;

namespace Engine.Factories
{
    internal static class WorldFactory
    {
        private const string GAME_DATA_FILENAME = ".\\GameData\\Locations.xml";

        internal static World CreateWorld()
        {
            var newWorld = new World();

            if (File.Exists(GAME_DATA_FILENAME))
            {
                XmlDocument data = new XmlDocument();
                data.LoadXml(File.ReadAllText(GAME_DATA_FILENAME));

                var rootImagePath = data.SelectSingleNode("/Locations").AttributeAsString("RootImagePath");

                LoadLocationsFromNodes(newWorld, rootImagePath, data.SelectNodes("/Locations/Location"));
            }
            else
            {
                throw new FileNotFoundException($"Missing data file: {GAME_DATA_FILENAME}");
            }

            return newWorld;
        }

        private static void LoadLocationsFromNodes(World world, string rootImagePath, XmlNodeList nodes)
        {
            if (nodes == null)
            {
                return;
            }

            foreach (XmlNode node in nodes)
            {
                var location = new Location(node.AttributeAsInt("X"), node.AttributeAsInt("Y"),
                    node.AttributeAsString("Name"), node.SelectSingleNode("./Description")?.InnerText ?? "",
                    $".{rootImagePath}{node.AttributeAsString("ImageName")}");

                AddMonsters(location, node.SelectNodes("./Monsters/Monster"));
                AddQuests(location, node.SelectNodes("./Quests/Quest"));
                AddTrader(location, node.SelectSingleNode("./Trader"));

                world.AddLocation(location);
            }
        }

        private static void AddTrader(Location location, XmlNode trader)
        {
            if (trader == null)
            {
                return;
            }

            location.TraderHere = TraderFactory.GetTraderByID(trader.AttributeAsInt("ID"));
        }

        private static void AddQuests(Location location, XmlNodeList quests)
        {
            if (quests == null)
            {
                return;
            }

            foreach (XmlNode questNode in quests)
            {
                location.QuestsAvailableHere.Add(QuestFactory.GetQuestByID(questNode.AttributeAsInt("ID")));
            }
        }

        private static void AddMonsters(Location location, XmlNodeList monsters)
        {
            if (monsters == null)
            {
                return;
            }

            foreach (XmlNode monsterNode in monsters)
            {
                location.AddMonster(monsterNode.AttributeAsInt("ID"), monsterNode.AttributeAsInt("Percent"));
            }
        }
    }
}