using RPG.Characters;

namespace RPG.Strategy
{
  public interface IAttackStrategy
  {
    void Execute(BaseCharacter attacker, BaseCharacter target);
  }
}
