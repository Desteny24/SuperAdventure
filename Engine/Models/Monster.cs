namespace Engine.Models
{
    public class Monster : LivingEntity
    {
        public string ImageName { get; }
        public int MinimumDamage { get; }
        public int MaximumDamage { get; }
        public int RewardExperiencePoints { get; }

        public Monster(string name, string imageName, int maximumHitPoints, int currentHitpoints, int minimumDamage, int maximumDamage, int rewardExperiencePoints, int rewardGold) 
            : base(name, maximumHitPoints, currentHitpoints, rewardGold)
        {
            ImageName = $"pack://application:,,,/Engine;component/Images/Monsters/{imageName}";
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
            RewardExperiencePoints = rewardExperiencePoints;
        }
    }
}