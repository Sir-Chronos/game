using System;
using RPG.Characters;
using RPG.Strategy;
using RPG.Observer;
using RPG.Singleton;
using RPG.Utils;

namespace RPG
{
    public static class Game
    {
        private static CharacterMemento SaveCharacterState(BaseCharacter character)
        {
            return new CharacterMemento(
                character.GetType().Name,
                character.Health,
                character.Defense,
                character.AttackPower
            );
        }

        private static BaseCharacter LoadCharacterState(CharacterMemento memento)
        {
            return CharacterFactory.PlayerFactory(memento);
        }

        public static void Start(BaseCharacter player, BaseCharacter enemy)
        {
            if (player == null || enemy == null)
            {
                throw new ArgumentNullException("Os personagens não podem ser nulos.");
            }

            Console.WriteLine("\nA batalha começou!");
            Console.WriteLine($"Você está enfrentando um {enemy.CharacterType}!");

            while (player.IsAlive && enemy.IsAlive)
            {
                Console.WriteLine("\nEscolha uma ação: 1. Ataque Básico 2. Defesa 3. Habilidade Especial 4. Salvar Estado 5. Reiniciar Jogo");
                string action = Console.ReadLine() ?? ""; // Garantir que o valor não seja null

                switch (action)
                {
                    case "1":
                        player.AttackStrategy = new BasicAttackStrategy();
                        break;
                    case "2":
                        player.AttackStrategy = new DefenseStrategy(10); // Aplicando defesa temporária
                        Console.WriteLine($"{player.CharacterType} se preparou para defesa!");
                        break;
                    case "3":
                        player.AttackStrategy = new SpecialAbilityStrategy(); // Usando habilidade especial
                        Console.WriteLine($"{player.CharacterType} usou uma habilidade especial!");
                        break;
                    case "4":
                        var savedState = SaveCharacterState(player);
                        Console.WriteLine("Estado do personagem salvo!");
                        player = LoadCharacterState(savedState);
                        Console.WriteLine("Estado do personagem restaurado!");
                        continue;
                    case "5":
                        Console.WriteLine("Reiniciando o jogo...");
                        return; // Reinicia o jogo
                    default:
                        Console.WriteLine("Ação inválida. Tente novamente.");
                        continue;
                }

                // Exibir informações antes de realizar o ataque
                Console.WriteLine($"\n{player.CharacterType} está atacando!");
                player.PerformAttack(enemy);  // Realiza o ataque

                if (!enemy.IsAlive)
                {
                    Console.WriteLine($"{enemy.CharacterType} foi derrotado!");
                    GameState.Instance.IncreaseScore(100);
                    break;
                }

                // Exibir informações antes de o inimigo atacar
                Console.WriteLine($"\n{enemy.CharacterType} contra-ataca!");
                enemy.AttackStrategy = new BasicAttackStrategy();
                enemy.PerformAttack(player);

                if (!player.IsAlive)
                {
                    Console.WriteLine($"{player.CharacterType} foi derrotado! Game Over.");
                    break;
                }

                // Exibir status de saúde após cada rodada
                Console.WriteLine($"\n{player.CharacterType} agora tem {player.Health} de saúde.");
                Console.WriteLine($"{enemy.CharacterType} agora tem {enemy.Health} de saúde.");
            }
        }

    }
}
