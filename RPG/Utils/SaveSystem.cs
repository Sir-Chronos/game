using System;
using System.IO;
using System.Text.Json;

namespace RPG.Utils
{
    public static class SaveSystem
    {
        public static void Save(CharacterMemento memento, string fileName)
        {
            string json = JsonSerializer.Serialize(memento);
            File.WriteAllText(fileName, json);
            Console.WriteLine($"Estado salvo em {fileName}");
        }

        public static CharacterMemento? Load(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine("Arquivo de save não encontrado.");
                return null;
            }

            string json = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<CharacterMemento>(json);
        }
    }
}
