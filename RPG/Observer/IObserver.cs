using RPG.Characters;

namespace RPG.Observer
{
  public interface IObserver
  {
    void Update(BaseCharacter character);
  }
}
