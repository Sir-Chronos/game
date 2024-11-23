using RPG.Characters;

namespace RPG.Characters.Playables
{
    public class Archer : BaseCharacter
    {
        public Archer(int health, int defense, int attackPower)
            : base(health, defense, attackPower, "Goblin")
        {
        }

        public override void PerformAttack(BaseCharacter target)
        {
            bool isCriticalHit = new Random().Next(0, 100) < 25; // 25% chance de crítico
            int damage = isCriticalHit ? AttackPower * 2 : AttackPower;

            Console.WriteLine($"{GetType().Name} dispara {(isCriticalHit ? "um golpe crítico" : "uma flecha")} causando {damage} de dano!");
            target.TakeDamage(damage);

            NotifyObservers();
        }
    }
}
