using System.Collections.Generic;
using RPG.Characters;

namespace RPG.Observer
{
  public class GameSubject
  {
    private readonly List<IObserver> _observers = new List<IObserver>();

    public void AddObserver(IObserver observer)
    {
      _observers.Add(observer);
    }

    public void Notify(BaseCharacter character)
    {
      foreach (var observer in _observers)
      {
        observer.Update(character);
      }
    }
  }
}
