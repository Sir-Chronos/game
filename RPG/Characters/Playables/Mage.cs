using RPG.Characters;

namespace RPG.Characters.Playables
{
    public class Mage : BaseCharacter
    {
        public Mage(int health, int defense, int attackPower)
            : base(health, defense, attackPower, "Necromancer")
        {
        }

        public override void TakeDamage(int damage)
        {
            int magicShield = 5; // Exemplo de escudo mágico que reduz dano fixo
            int damageTaken = Math.Max(0, damage - (Defense + magicShield));
            Health -= damageTaken;

            Console.WriteLine($"{GetType().Name} recebeu {damageTaken} de dano após escudo mágico. Saúde restante: {Health}");
            NotifyObservers();
        }
    }
}
