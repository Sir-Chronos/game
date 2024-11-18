namespace RPG.Characters
{
    public abstract class BaseCharacter
    {
        // Attributes
        public int Health { get; protected set; }
        public int Defense { get; protected set; }
        public int AttackPower { get; protected set; }

        // Constructor
        protected BaseCharacter(int health, int defense, int attackPower)
        {
            Health = health;
            Defense = defense;
            AttackPower = attackPower;
        }

        // Method to take damage
        public virtual void TakeDamage(int damage)
        {
            int damageTaken = damage - Defense;
            if (damageTaken > 0)
            {
                Health -= damageTaken;
                if (Health < 0) Health = 0; // Prevent negative health
            }
        }

        // Method to attack another character
        public virtual void PerformAttack(BaseCharacter target)
        {
            target.TakeDamage(AttackPower);
        }
    }
}
