using RPG.Characters;

namespace RPG.Characters.Playables
{
    public class Archer : BaseCharacter
    {
        public Archer(int health, int defense, int attackPower)
            : base(health, defense, attackPower)
        {
        }

        public override void TakeDamage(int damage)
        {
            int damageTaken = Math.Max(0, damage - Defense);
            Health -= damageTaken;
            Console.WriteLine($"{GetType().Name} recebeu {damageTaken} de dano. Saúde restante: {Health}");
            NotifyObservers();
        }

        public override void PerformAttack(BaseCharacter target)
        {
            bool isCriticalHit = new Random().Next(0, 100) < 25; // 25% chance de crítico
            int damage = isCriticalHit ? AttackPower * 2 : AttackPower;
            target.TakeDamage(damage);

            Console.WriteLine($"{GetType().Name} dispara {(isCriticalHit ? "um golpe crítico" : "uma flecha")} causando {damage} de dano!");
        }
    }
}
