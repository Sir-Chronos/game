using RPG.Characters;
using System.Text.Json;

namespace RPG.Utils
{
    internal class SaveSystem
    {
        private static readonly string saveFilePath = "savefile.json";

        // Save the character's memento to a file
        public static void SaveCharacter(BaseCharacter character)
        {
            try
            {
                var memento = character.SaveState(); // Create a memento
                string json = JsonSerializer.Serialize(memento);
                File.WriteAllText(saveFilePath, json);
                Console.WriteLine("Game saved successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving game: {ex.Message}");
            }
        }

        // Load the character's state from a file and apply it
        public static BaseCharacter LoadCharacter()
        {
            try
            {
                if (!File.Exists(saveFilePath))
                {
                    Console.WriteLine("No save file found.");
                    return null;
                }

                string json = File.ReadAllText(saveFilePath);
                var memento = JsonSerializer.Deserialize<CharacterMemento>(json);

                if (memento == null)
                {
                    Console.WriteLine("Error: Invalid save file.");
                    return null;
                }

                return CharacterFactory.PlayerFactory(memento); // Use the overloaded method
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading game: {ex.Message}");
                return null;
            }
        }

    }
}
