using RPG.Characters;

namespace RPG.Strategy
{
  public class BasicAttackStrategy : IAttackStrategy
  {
    public void Execute(BaseCharacter attacker, BaseCharacter target)
    {
      // Chamando TakeDamage corretamente
      target.TakeDamage(attacker.AttackPower);
    }
  }
}
