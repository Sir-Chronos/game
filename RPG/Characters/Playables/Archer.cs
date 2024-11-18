namespace RPG.Characters.Playables
{
    internal class Archer : BaseCharacter
    {
        private static readonly Random Randomizer = new Random();

        // Constructor
        public Archer(int health, int defense, int attackPower)
            : base(health, defense, attackPower)
        {
        }

        // Archers take normal damage but can attack multiple times with randomized damage
        public override void PerformAttack(BaseCharacter target)
        {
            for (int i = 0; i < 2; i++) // Attack twice
            {
                int randomDamage = Randomizer.Next((int)(AttackPower * 0.8), (int)(AttackPower * 1.2) + 1);
                target.TakeDamage(randomDamage);
            }
        }
    }
}
