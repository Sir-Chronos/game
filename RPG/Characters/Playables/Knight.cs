using RPG.Characters;

namespace RPG.Characters.Playables
{
    public class Knight : BaseCharacter
    {
        public Knight(int health, int defense, int attackPower)
            : base(health, defense, attackPower, "Orc")
        {
        }

        public override void TakeDamage(int damage)
        {
            int heavyArmorReduction = 10; // Exemplo de redução adicional para o Cavaleiro
            int damageTaken = Math.Max(0, damage - (Defense + heavyArmorReduction));
            Health -= damageTaken;

            Console.WriteLine($"{GetType().Name} recebeu {damageTaken} de dano após proteção pesada. Saúde restante: {Health}");
            NotifyObservers();
        }
    }
}
