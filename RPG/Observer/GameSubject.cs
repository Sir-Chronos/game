using RPG.Characters;
using System;
using System.Collections.Generic;

namespace RPG
{
    public class GameSubject
    {
        // Lista de observadores que implementam a interface IObserver<BaseCharacter>
        private readonly List<IObserver<BaseCharacter>> _observers = new();

        // Método para adicionar um observador
        public void RegisterObserver(IObserver<BaseCharacter> observer)
        {
            _observers.Add(observer);
        }

        // Método para notificar os observadores
        public void NotifyObservers(BaseCharacter character)
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(character);
            }
        }

        // Método para simular uma mudança no estado do personagem
        public void ChangeCharacterState(BaseCharacter character)
        {
            // Exemplo de alteração no personagem (dano, ataque, etc.)
            character.TakeDamage(10); // Dando um dano de exemplo

            // Após a alteração, notifique os observadores
            NotifyObservers(character);
        }
    }
}
