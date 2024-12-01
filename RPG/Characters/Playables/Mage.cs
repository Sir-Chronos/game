using RPG.Characters;

namespace RPG.Characters.Playables
{
    public class Mage : BaseCharacter
    {
        public Mage(int health, int defense, int attackPower)
            : base(health, defense, attackPower)
        {
        }

        public override void TakeDamage(int damage)
        {
            int magicShield = 5;
            int damageTaken = Math.Max(0, damage - (Defense + magicShield));
            Health -= damageTaken;

            Console.WriteLine($"{GetType().Name} recebeu {damageTaken} de dano após escudo mágico. Saúde restante: {Health}");
            NotifyObservers();
        }

        public override void PerformAttack(BaseCharacter target)
        {
            int magicDamage = AttackPower * 2; // Ataque mágico do mago
            target.TakeDamage(magicDamage);  // Aplica o dano mágico no alvo

            Console.WriteLine($"{GetType().Name} lança um feitiço causando {magicDamage} de dano!");
        }
    }
}
