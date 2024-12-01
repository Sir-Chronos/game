using RPG.Characters;
using System;

namespace RPG
{
    public class HealthObserver : IObserver<BaseCharacter>
    {
        // Implementação do método OnNext para reagir às mudanças no estado de BaseCharacter
        public void OnNext(BaseCharacter character)
        {
            // Aqui verificamos se a saúde do personagem foi alterada e fazemos algo
            Console.WriteLine($"{character.GetType().Name} tem {character.Health} de saúde.");
            if (character.Health <= 0)
            {
                Console.WriteLine($"{character.GetType().Name} morreu!");
            }
        }

        // Esses dois métodos são necessários, mas não precisamos implementá-los agora para o caso simples
        public void OnCompleted()
        {
            // Podemos deixar vazio por enquanto
        }

        public void OnError(Exception error)
        {
            // Podemos deixar vazio por enquanto
        }
    }
}
