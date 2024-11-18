using RPG.Characters;
using RPG.Characters.Playables;

namespace RPG.Utils
{
    public static class CharacterFactory
    {
        // Factory to create a new player with default stats
        public static BaseCharacter PlayerFactory(string characterClass)
        {
            return characterClass.ToLower() switch
            {
                "knight" => new Knight(100, 30, 20),
                "mage" => new Mage(80, 10, 40),
                "archer" => new Archer(90, 15, 25),
                _ => throw new ArgumentException("Invalid character class.")
            };
        }

        // Overloaded factory to create a player with stats from a memento
        public static BaseCharacter PlayerFactory(CharacterMemento memento)
        {
            return memento.ClassName.ToLower() switch
            {
                "knight" => new Knight(memento.Health, memento.Defense, memento.AttackPower),
                "mage" => new Mage(memento.Health, memento.Defense, memento.AttackPower),
                "archer" => new Archer(memento.Health, memento.Defense, memento.AttackPower),
                _ => throw new ArgumentException("Invalid character class.")
            };
        }

        // Factory to create enemies
        public static BaseCharacter EnemyFactory(string enemyType)
        {
            return enemyType.ToLower() switch
            {
                "orc" => new Knight(120, 25, 15),      // Fixed stats for Orc
                "goblin" => new Archer(60, 10, 20),   // Fixed stats for Goblin
                "necromancer" => new Mage(70, 15, 35), // Fixed stats for Necromancer
                _ => throw new ArgumentException("Invalid enemy type.")
            };
        }
    }
}
