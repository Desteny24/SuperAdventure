using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Engine.Models
{
    public class Player : LivingEntity
    {
        #region Properties

        private int _experiencePoints;
        private string _characterClass;

        public string CharacterClass
        {
            get => _characterClass;
            set
            {
                _characterClass = value;
                OnPropertyChanged();
            }
        }
        public int ExperiencePoints
        {
            get => _experiencePoints;
            set
            {
                _experiencePoints = value;
                OnPropertyChanged();
                SetLevelAndMaximumHitpoints();
            }
        }
        public ObservableCollection<QuestStatus> Quests { get; }
        public ObservableCollection<Recipe> Recipes { get; }

        #endregion

        public event EventHandler OnLeveledUp;

        public Player(string name, string characterClass, int experiencePoints, int maxHitpoints, int currentHitpoints, int gold) 
                : base(name, maxHitpoints, currentHitpoints, gold)
        {
            CharacterClass = characterClass;
            ExperiencePoints = experiencePoints;
            Quests = new ObservableCollection<QuestStatus>();
            Recipes = new ObservableCollection<Recipe>();
        }

        public void AddExperience(int experiencePoints)
        {
            ExperiencePoints += experiencePoints;
        }

        public void LearnRecipe(Recipe recipe)
        {
            if (Recipes.All(r => r.ID != recipe.ID))
            {
                Recipes.Add(recipe);
            }
        }

        private void SetLevelAndMaximumHitpoints()
        {
            var originalLvl = Level;
            Level = (ExperiencePoints / 100) + 1;

            if (Level != originalLvl)
            {
                MaximumHitPoints = Level * 10;
                OnLeveledUp?.Invoke(this, System.EventArgs.Empty);
            }
        }
    }
}