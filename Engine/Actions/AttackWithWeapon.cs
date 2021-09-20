using System;
using Engine.Models;

namespace Engine.Actions
{
    public class AttackWithWeapon : BaseAction, IAction
    {
        private readonly int _maximumDamage;
        private readonly int _minimumDamage;

        public AttackWithWeapon(GameItem itemInUse, int minimumDamage, int maximumDamage)
            : base(itemInUse)
        {
            if (itemInUse.Category != GameItem.ItemCategory.Weapon)
            {
                throw new ArgumentException($"{itemInUse.Name} is not a weapon.");
            }

            if (_minimumDamage < 0)
            {
                throw new ArgumentException("minimumDamage must be 0 or larger.");
            }

            if (_maximumDamage < _minimumDamage)
            {
                throw new ArgumentException("maximumDamage must be greater than or equal to minimumDamage.");
            }

            _maximumDamage = maximumDamage;
            _minimumDamage = minimumDamage;
        }

        public void Execute(LivingEntity actor, LivingEntity target)
        {
            var damage = RandomNumberGenerator.SimpleNumberBetween(_minimumDamage, _maximumDamage);

            var actorName = (actor is Player) ? "You" : $"The {actor.Name.ToLower()}";
            var targetName = (target is Player) ? "you" : $"the {target.Name.ToLower()}";

            if (damage == 0)
            {
                ReportResult($"{actorName} missed {targetName}.");
            }
            else
            {
                ReportResult($"{actorName} hit {targetName} for {damage} points.");
                target.TakeDamage(damage);
            }
        }
    }
}