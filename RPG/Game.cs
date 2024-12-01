using RPG.Characters;
using RPG.Strategy;
using RPG.Observer;
using RPG.Singleton;
using RPG.Utils;

namespace RPG
{
    public static class Game
    {
        private static GameSubject _gameSubject = new GameSubject(); // Instância do GameSubject

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

        public static void Start(BaseCharacter? player)  // player é agora anulável
        {
            if (player == null)
            {
                Console.WriteLine("Nenhum personagem válido. O jogo será encerrado.");
                return;
            }

            // Etapa 1: Exibir classe escolhida
            Console.WriteLine($"Você escolheu {player.GetType().Name}!");  // Usando GetType().Name para mostrar a classe

            // Etapa 2: Criar inimigo aleatório
            Console.WriteLine("Um inimigo se aproxima...");
            var enemyTypes = new[] { "orc", "goblin", "necromancer" };
            var randomEnemyType = enemyTypes[new Random().Next(enemyTypes.Length)];
            var enemy = CharacterFactory.EnemyFactory(randomEnemyType);
            Console.WriteLine($"Você enfrenta um {randomEnemyType}!");


            // Registra o HealthObserver para monitorar o estado de saúde do personagem
            HealthObserver healthObserver = new HealthObserver();
            _gameSubject.RegisterObserver(healthObserver);

            // Etapa 3: Iniciar batalha
            Console.WriteLine("\nA batalha começou!");
            Console.WriteLine($"Você está enfrentando um {enemy.GetType().Name}!");  // Usando GetType().Name para mostrar o inimigo

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
                        Console.WriteLine($"{player.GetType().Name} se preparou para defesa!");
                        break;
                    case "3":
                        player.AttackStrategy = new SpecialAbilityStrategy(); // Usando habilidade especial
                        Console.WriteLine($"{player.GetType().Name} usou uma habilidade especial!");
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
                Console.WriteLine($"\n{player.GetType().Name} está atacando!");
                player.PerformAttack(enemy);  // Realiza o ataque

                if (!enemy.IsAlive)
                {
                    Console.WriteLine($"{enemy.GetType().Name} foi derrotado!");
                    GameState.Instance.IncreaseScore(100);
                    break;
                }

                // Exibir informações antes de o inimigo atacar
                Console.WriteLine($"\n{enemy.GetType().Name} contra-ataca!");
                enemy.AttackStrategy = new BasicAttackStrategy();
                enemy.PerformAttack(player);

                if (!player.IsAlive)
                {
                    Console.WriteLine($"{player.GetType().Name} foi derrotado! Game Over.");
                    break;
                }

                // Exibir status de saúde após cada rodada
                Console.WriteLine($"\n{player.GetType().Name} agora tem {player.Health} de saúde.");
                Console.WriteLine($"{enemy.GetType().Name} agora tem {enemy.Health} de saúde.");

                // Notificar os observadores sobre o estado do personagem
                _gameSubject.ChangeCharacterState(player);
            }

            Console.WriteLine("Obrigado por jogar!");
        }
    }
}
