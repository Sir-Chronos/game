using System;
using RPG.Characters;

namespace RPG.Observer
{
  public class HealthObserver : IObserver<BaseCharacter>
  {
    public void OnNext(BaseCharacter character)
    {
      Console.WriteLine($"{character.GetType().Name} agora tem {character.Health} de saúde.");
    }

    public void OnError(Exception error)
    {
      Console.WriteLine($"Erro: {error.Message}");
    }

    public void OnCompleted()
    {
      Console.WriteLine("Notificações concluídas.");
    }
  }
}
