using RPG.Characters;

namespace RPG.Characters.Enemies
{
    public class Necromancer : BaseEnemy
    {
        public Necromancer(int health, int defense, int attackPower)
            : base(health, defense, attackPower)
        {
        }

        // Implementação do ataque do Necromancer (Exemplo: Dano mágico)
        public override void Attack(BaseCharacter target)
        {
            int damage = AttackPower * 2; // Dano mágico é dobrado
            Console.WriteLine($"{GetType().Name} lança um feitiço causando {damage} de dano mágico!");
            target.TakeDamage(damage);
        }
    }
}
