using RPG;
using RPG.Characters;
using RPG.Utils;

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
                    player = CreateNewCharacter(); // Create a new character
                    if (player != null)
                    {
                        Game.Start(player); // Start the game with the new character
                    }
                    else
                    {
                        Console.WriteLine("Invalid character class selected. Please try again.");
                    }
                    break;
                case "2":
                    player = SaveSystem.LoadCharacter(); // Load saved character
                    if (player != null)
                    {
                        Game.Start(player); // Start the game with the loaded character
                    }
                    else
                    {
                        Console.WriteLine("No saved character found.");
                    }
                    break;
                case "3":
                    Console.WriteLine("Multiplayer is not implemented yet.");
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

    private static BaseCharacter CreateNewCharacter()
    {
        Console.Clear();
        Console.WriteLine("Choose your character class:");
        Console.WriteLine("1. Knight");
        Console.WriteLine("2. Mage");
        Console.WriteLine("3. Archer");

        Console.Write("\nSelect a class: ");
        string classChoice = Console.ReadLine();

        // Use a switch expression to return the correct character, or null if invalid.
        return classChoice switch
        {
            "1" => CharacterFactory.PlayerFactory("knight"),
            "2" => CharacterFactory.PlayerFactory("mage"),
            "3" => CharacterFactory.PlayerFactory("archer"),
            _ => null // Return null if the choice is invalid
        };
    }
}
