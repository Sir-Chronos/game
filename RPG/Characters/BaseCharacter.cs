using RPG.Utils;

namespace RPG.Characters
{
    public abstract class BaseCharacter
    {
        public int Health { get; protected set; }
        public int Defense { get; protected set; }
        public int AttackPower { get; protected set; }
        public string ClassName { get; protected set; }

        protected BaseCharacter(int health, int defense, int attackPower, string className)
        {
            Health = health;
            Defense = defense;
            AttackPower = attackPower;
            ClassName = className;
        }

        // Create a memento with the character's state
        public CharacterMemento SaveState()
        {
            return new CharacterMemento(ClassName, Health, Defense, AttackPower);
        }

        // Restore the character's state from a memento
        public void RestoreState(CharacterMemento memento)
        {
            if (memento == null)
                throw new ArgumentNullException(nameof(memento));

            Health = memento.Health;
            Defense = memento.Defense;
            AttackPower = memento.AttackPower;
        }
    }
}
