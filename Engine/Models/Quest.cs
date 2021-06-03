using System.Collections.Generic;

namespace Engine.Models
{
    public class Quest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RewardExperiencePoints { get; set; }
        public int RewardGold { get; set; }

        public List<ItemQuantity> ItemsToComplete { get; set; }
        public List<ItemQuantity> RewardItems { get; set; }

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