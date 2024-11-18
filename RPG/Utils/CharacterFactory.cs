using RPG.Characters;
using RPG.Characters.Playables;

namespace RPG.Utils
{
    public static class CharacterFactory
    {
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
