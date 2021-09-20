using System.Collections.Generic;
using Engine.Factories;

namespace Engine.Models
{
    public class Monster : LivingEntity
    {
        private readonly List<ItemPercentage> _lootTable = new List<ItemPercentage>();

        public int ID { get; }
        public string ImageName { get; }
        public int RewardExperiencePoints { get; }

        public Monster(int id, string name, string imageName, int maximumHitPoints, GameItem currentWeapon, int rewardExperiencePoints, int rewardGold) 
            : base(name, maximumHitPoints, maximumHitPoints, rewardGold)
        {
            ID = id;
            ImageName = imageName;
            CurrentWeapon = currentWeapon;
            RewardExperiencePoints = rewardExperiencePoints;
        }

        public void AddItemToLootTable(int id, int percentage)
        {
            // Remove the entry from the loot table, if entry with the id already exists.
            _lootTable.RemoveAll(ip => ip.ID == id);
            _lootTable.Add(new ItemPercentage(id, percentage));
        }

        public Monster GetNewInstance()
        {
            // Clone this monster to a new Monster object.
            var newMonster = new Monster(ID, Name, ImageName, MaximumHitPoints, CurrentWeapon, RewardExperiencePoints, Gold);

            foreach (var itemPercentage in _lootTable)
            {
                // Clone the loottable
                newMonster.AddItemToLootTable(itemPercentage.ID, itemPercentage.Percentage);

                // Populate the new monster's inventory, using the loot table
                if (RandomNumberGenerator.SimpleNumberBetween(1, 100) <= itemPercentage.Percentage)
                {
                    newMonster.AddItemToInventory(ItemFactory.CreateGameItem(itemPercentage.ID));
                }
            }

            return newMonster;
        }
    }
}