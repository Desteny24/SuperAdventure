using System.Collections.Generic;
using System.Linq;
using Engine.Models;

namespace Engine.Factories
{
    public static class ItemFactory
    {
        private static readonly List<GameItem> _standardGameItems = new();

        static ItemFactory()
        {
            _standardGameItems.Add(new Weapon(1001, "Pointy Stick", 1, 1, 2));
            _standardGameItems.Add(new Weapon(1002, "Rusty Sword", 5, 1, 3));
            _standardGameItems.Add(new GameItem(9001, "Snake fang", 1, false));
            _standardGameItems.Add(new GameItem(9002, "Snakeskin", 2, false));
            _standardGameItems.Add(new GameItem(9003, "Rat tail", 1, false));
            _standardGameItems.Add(new GameItem(9004, "Rat fur", 2, false));
            _standardGameItems.Add(new GameItem(9005, "Spider fang", 1, false));
            _standardGameItems.Add(new GameItem(9006, "Spider silk", 2, false));
        }

        public static GameItem CreateGameItem(int itemTypeId)
        {
            var standardItem = _standardGameItems.FirstOrDefault(item => item.ItemTypeID == itemTypeId);

            if (standardItem != null)
            {
                if (standardItem is Weapon)
                {
                    return (standardItem as Weapon).Clone();
                }
                return standardItem.Clone();
            }

            return null;
        }
    }
}