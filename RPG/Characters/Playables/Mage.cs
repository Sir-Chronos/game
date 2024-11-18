namespace RPG.Characters.Playables
{
    internal class Mage : BaseCharacter
    {
        // Constructor
        public Mage(int health, int defense, int attackPower)
            : base(health, defense, attackPower)
        {
        }

        // Mages take extra damage but deal more damage
        public override void TakeDamage(int damage)
        {
            int increasedDamage = (int)(damage * 1.2); // Take 20% more damage
            base.TakeDamage(increasedDamage);
        }

        public override void PerformAttack(BaseCharacter target)
        {
            int enhancedAttack = (int)(AttackPower * 1.3); // Deal 30% more damage
            target.TakeDamage(enhancedAttack);
        }
    }

}
