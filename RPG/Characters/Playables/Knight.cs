using RPG.Characters;

namespace RPG.Characters.Playables
{
    public class Knight : BaseCharacter
    {
        public Knight(int health, int defense, int attackPower)
            : base(health, defense, attackPower)
        {
        }

        public override void TakeDamage(int damage)
        {
            int heavyArmorReduction = 10;
            int totalDefense = Defense + heavyArmorReduction;
            int damageTaken = Math.Max(1, damage - totalDefense);

            Health -= damageTaken;

            Console.WriteLine($"{GetType().Name} recebeu {damageTaken} de dano após proteção pesada. Saúde restante: {Health}");
            NotifyObservers();
        }



        public override void PerformAttack(BaseCharacter target)
        {
            int damage = AttackPower; // Ataque normal do cavaleiro
            target.TakeDamage(damage); // Aplica o dano no alvo
            Console.WriteLine($"{GetType().Name} ataca com um golpe pesado causando {damage} de dano!");
        }
    }
}
