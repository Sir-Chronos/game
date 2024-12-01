using System;
using RPG.Characters;
using RPG.Characters.Playables;
using RPG.Characters.Enemies;

namespace RPG.Utils
{
    public static class CharacterFactory
    {
        // Factory para criar um jogador com stats padrão
        public static BaseCharacter PlayerFactory(string characterClass)
        {
            if (string.IsNullOrEmpty(characterClass))
            {
                throw new ArgumentException("O nome da classe do personagem não pode ser nulo ou vazio.", nameof(characterClass));
            }

            return characterClass.ToLower() switch
            {
                "knight" => new Knight(100, 20, 20),
                "mage" => new Mage(80, 10, 40),
                "archer" => new Archer(90, 15, 25),
                _ => throw new ArgumentException("Classe de personagem inválida.", nameof(characterClass))
            };
        }

        // Factory para criar um jogador a partir de um memento
        public static BaseCharacter PlayerFactory(CharacterMemento memento)
        {
            if (memento == null)
            {
                throw new ArgumentNullException(nameof(memento), "O memento não pode ser nulo.");
            }

            return memento.ClassName.ToLower() switch
            {
                "knight" => new Knight(memento.Health, memento.Defense, memento.AttackPower),
                "mage" => new Mage(memento.Health, memento.Defense, memento.AttackPower),
                "archer" => new Archer(memento.Health, memento.Defense, memento.AttackPower),
                _ => throw new ArgumentException("Classe de personagem inválida no memento.", nameof(memento))
            };
        }

        // Factory para criar inimigos com stats fixos (sem necessidade de memento)
        public static BaseCharacter EnemyFactory(string enemyType)
        {
            if (string.IsNullOrEmpty(enemyType))
            {
                throw new ArgumentException("O tipo de inimigo não pode ser nulo ou vazio.", nameof(enemyType));
            }

            return enemyType.ToLower() switch
            {
                "orc" => new Orc(120, 25, 40),
                "goblin" => new Goblin(60, 10, 30),
                "necromancer" => new Necromancer(70, 15, 45),
                _ => throw new ArgumentException("Tipo de inimigo inválido.", nameof(enemyType))
            };
        }
    }
}
