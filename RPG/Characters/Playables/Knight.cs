namespace RPG.Characters.Playables
{
    internal class Knight : BaseCharacter
    {
        // Constructor
        public Knight(int health, int defense, int attackPower)
            : base(health, defense, attackPower)
        {
        }

        public override void TakeDamage(int damage)
        {
            int reducedDamage = (int)(damage * 0.7); // Reduce damage by 30%
            base.TakeDamage(reducedDamage);
        }

        public override void PerformAttack(BaseCharacter target)
        {
            int enhancedAttack = AttackPower;
            target.TakeDamage(enhancedAttack);
        }
    }
}
