using System;
using System.IO;
using System.Text.Json;
using RPG.Characters;
using RPG.Utils;

namespace RPG.Utils
{
    public static class SaveSystem
    {
        private static string saveFilePath = "savegame.json";

        // Método para salvar o estado do personagem
        public static void SaveCharacter(BaseCharacter character)
        {
            try
            {
                var memento = new CharacterMemento(
                    character.GetType().Name,
                    character.Health,
                    character.Defense,
                    character.AttackPower
                );

                string json = JsonSerializer.Serialize(memento);
                File.WriteAllText(saveFilePath, json);

                Console.WriteLine("Estado do personagem salvo com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar o personagem: {ex.Message}");
            }
        }

        // Método para carregar o estado do personagem a partir de um arquivo
        public static BaseCharacter LoadCharacter()
        {
            try
            {
                if (File.Exists(saveFilePath))
                {
                    string json = File.ReadAllText(saveFilePath);
                    CharacterMemento? memento = JsonSerializer.Deserialize<CharacterMemento>(json);

                    if (memento == null)
                    {
                        Console.WriteLine("Erro ao carregar personagem: Memento não encontrado.");
                        return null!;
                    }

                    // Cria o personagem a partir do Memento
                    BaseCharacter character = CharacterFactory.PlayerFactory(memento.ClassName);

                    // Atualiza os stats com os valores do Memento
                    character.UpdateStats(memento.Health, memento.Defense, memento.AttackPower);

                    Console.WriteLine("Personagem carregado com sucesso!");
                    return character;
                }
                else
                {
                    Console.WriteLine("Nenhum arquivo de salvamento encontrado.");
                    return null!;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar personagem: {ex.Message}");
                return null!;
            }
        }

        // Método para deletar o arquivo de salvamento
        public static void DeleteSave()
        {
            try
            {
                if (File.Exists(saveFilePath))
                {
                    File.Delete(saveFilePath);
                    Console.WriteLine("Arquivo de salvamento deletado com sucesso.");
                }
                else
                {
                    Console.WriteLine("Nenhum arquivo de salvamento encontrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar o arquivo de salvamento: {ex.Message}");
            }
        }
    }
}
