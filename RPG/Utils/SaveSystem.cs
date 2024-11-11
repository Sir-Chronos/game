using RPG.Characters;
using System.Text.Json;

namespace RPG.Utils
{
    internal class SaveSystem
    {
        private static string saveFilePath = "savefile.json";

        // Método para salvar o personagem em um arquivo JSON
        public static void SaveCharacter(BaseCharacter character)
        {
            try
            {
                string json = JsonSerializer.Serialize(character);
                File.WriteAllText(saveFilePath, json);
                Console.WriteLine("Game saved successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving game: {ex.Message}");
            }
        }

        // Método para carregar o personagem de um arquivo JSON
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
                BaseCharacter character = JsonSerializer.Deserialize<BaseCharacter>(json);
                Console.WriteLine("Game loaded successfully!");
                return character;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading game: {ex.Message}");
                return null;
            }
        }
    }
}
