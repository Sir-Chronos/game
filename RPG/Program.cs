using RPG.Utils;
using RPG.Characters;
using RPG; // Ensure this is included if Character is part of this namespace

class Program
{
    private static void Main(string[] args)
    {
        BaseCharacter player = null; // Declare player here for access in all cases
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the RPG Game!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("\n1. New Game");
            Console.WriteLine("2. Load Game");
            Console.WriteLine("3. Multiplayer");
            Console.WriteLine("4. Exit");

            Console.Write("\nSelect an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    player = CharacterFactory.PlayerFactory(); // Create a new character
                    Game.Start(player); // Start the game with the new character
                    break;
                case "2":
                    player = SaveSystem.LoadCharacter(); // Load saved character
                    if (player != null)
                    {
                        Game.Start(player); // Start the game with the loaded character
                    }
                    break;
                case "3":
                    // Multiplayer feature placeholder
                    break;
                case "4":
                    exit = true;
                    Console.WriteLine("Exiting the game. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select a valid option.");
                    break;
            }

            if (!exit)
            {
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
            }
        }
    }
}
