using RPG.Characters;

namespace RPG.Characters.Enemies
{
    public class Orc : BaseEnemy
    {
        public Orc(int health, int defense, int attackPower)
            : base(health, defense, attackPower)
        {
        }

        // Implementação do ataque do Orc
        public override void Attack(BaseCharacter target)
        {
            int damage = AttackPower;
            Console.WriteLine($"{GetType().Name} ataca com um machado causando {damage} de dano!");
            target.TakeDamage(damage);
        }
    }
}
