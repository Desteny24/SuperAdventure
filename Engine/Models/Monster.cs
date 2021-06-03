﻿using System.Collections.ObjectModel;

namespace Engine.Models
{
    public class Monster : BaseNotificationClass
    {
        private int _hitpoints;

        public string Name { get; private set; }
        public string ImageName { get; set; }
        public int MaximumHitPoints { get; private set; }

        public int HitPoints
        {
            get { return _hitpoints; }
            private set
            {
                _hitpoints = value;
                OnPropertyChanged(nameof(HitPoints));
            }
        }

        public int RewardExperiencePoints { get; private set; }
        public int RewardGold { get; private set; }

        public ObservableCollection<ItemQuantity> Inventory { get; set; }

        public Monster(string name, string imageName, int maximumHitPoints, int hitpoints, int rewardExperiencePoints, int rewardGold)
        {
            Name = name;
            ImageName = string.Format("pack://application:,,,/Engine;component/Images/Monsters/{0}", imageName);
            MaximumHitPoints = maximumHitPoints;
            HitPoints = hitpoints;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;

            Inventory = new ObservableCollection<ItemQuantity>();
        }
    }
}