using RPG.Characters;
using RPG.Utils;

namespace RPG
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao RPG!");

            // Etapa 1: Seleção de personagem
            Console.WriteLine("Escolha sua classe: 1. Cavaleiro 2. Mago 3. Arqueiro");
            string choice = Console.ReadLine() ?? "";
            BaseCharacter player;

            switch (choice)
            {
                case "1":
                    player = CharacterFactory.PlayerFactory("knight");
                    Console.WriteLine("Você escolheu Cavaleiro!");
                    break;
                case "2":
                    player = CharacterFactory.PlayerFactory("mage");
                    Console.WriteLine("Você escolheu Mago!");
                    break;
                case "3":
                    player = CharacterFactory.PlayerFactory("archer");
                    Console.WriteLine("Você escolheu Arqueiro!");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Escolhendo Cavaleiro por padrão.");
                    player = CharacterFactory.PlayerFactory("knight");
                    break;
            }

            // Etapa 2: Criar inimigo aleatório
            Console.WriteLine("Um inimigo se aproxima...");
            var enemyTypes = new[] { "orc", "goblin", "necromancer" };
            var randomEnemyType = enemyTypes[new Random().Next(enemyTypes.Length)];
            var enemy = CharacterFactory.EnemyFactory(randomEnemyType);
            Console.WriteLine($"Você enfrenta um {randomEnemyType}!");

            // Etapa 3: Iniciar batalha
            Game.Start(player, enemy);

            Console.WriteLine("Obrigado por jogar!");
        }
    }
}
