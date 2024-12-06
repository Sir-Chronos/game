using RPG.Characters;

namespace RPG.Characters.Enemies
{
    public class Goblin : BaseEnemy
    {
        public Goblin(int health, int defense, int attackPower)
            : base(health, defense, attackPower)
        {
        }

        // Implementação do ataque do Goblin
        public override void Attack(BaseCharacter target)
        {
            int damage = AttackPower;
            Console.WriteLine($"{GetType().Name} ataca com uma faca causando {damage} de dano!");
            target.TakeDamage(damage);
        }
    }
}
