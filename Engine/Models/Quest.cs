using System.Collections.Generic;

namespace Engine.Models
{
    public class Quest
    {
        public int ID { get; }
        public string Name { get; }
        public string Description { get; }
        public int RewardExperiencePoints { get; }
        public int RewardGold { get; }

        public List<ItemQuantity> ItemsToComplete { get; }
        public List<ItemQuantity> RewardItems { get; }

        public Quest(int id, string name, string description, int rewardExperiencePoints, int rewardGold, 
            List<ItemQuantity> itemsToComplete, List<ItemQuantity> rewardItems)
        {
            ID = id;
            Name = name;
            Description = description;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;
            ItemsToComplete = itemsToComplete;
            RewardItems = rewardItems;
        }
    }
}