using RPG;
using RPG.Characters;
using RPG.Utils;

class Program
{
    private static void Main(string[] args)
    {
        BaseCharacter? player = null; // Declare player as nullable BaseCharacter
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Bem-vindo ao Jogo de RPG!");
            Console.WriteLine("O que você gostaria de fazer?");
            Console.WriteLine("\n1. Novo Jogo");
            Console.WriteLine("2. Carregar Jogo");
            Console.WriteLine("3. Multiplayer");
            Console.WriteLine("4. Sair");

            Console.Write("\nSelecione uma opção: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    player = CreateNewCharacter(); // Criar um novo personagem
                    if (player != null)
                    {
                        Game.Start(player); // Iniciar o jogo com o novo personagem
                    }
                    else
                    {
                        Console.WriteLine("Classe de personagem inválida. Tente novamente.");
                    }
                    break;
                case "2":
                    player = SaveSystem.LoadCharacter(); // Carregar personagem salvo
                    if (player != null)
                    {
                        Game.Start(player); // Iniciar o jogo com o personagem carregado
                    }
                    else
                    {
                        Console.WriteLine("Nenhum personagem salvo encontrado.");
                    }
                    break;
                case "3":
                    Console.WriteLine("Multiplayer não implementado ainda.");
                    break;
                case "4":
                    exit = true;
                    Console.WriteLine("Saindo do jogo. Até logo!");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Por favor, selecione uma opção válida.");
                    break;
            }

            if (!exit)
            {
                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
            }
        }
    }

    private static BaseCharacter? CreateNewCharacter()
    {
        Console.Clear();
        Console.WriteLine("Escolha sua classe de personagem:");
        Console.WriteLine("1. Cavaleiro");
        Console.WriteLine("2. Mago");
        Console.WriteLine("3. Arqueiro");

        Console.Write("\nSelecione uma classe: ");
        string? classChoice = Console.ReadLine();

        // Verificar se classChoice não é null e retornar o personagem correto
        if (string.IsNullOrEmpty(classChoice))
        {
            return null; // Se o input for inválido ou vazio, retornar null
        }

        return classChoice switch
        {
            "1" => CharacterFactory.PlayerFactory("knight"),
            "2" => CharacterFactory.PlayerFactory("mage"),
            "3" => CharacterFactory.PlayerFactory("archer"),
            _ => null // Retorna null se a escolha for inválida
        };
    }
}
