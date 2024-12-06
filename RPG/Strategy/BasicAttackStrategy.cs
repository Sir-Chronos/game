using RPG.Characters;

namespace RPG.Strategy
{
  public class BasicAttackStrategy : IAttackStrategy
  {
      public void Execute(BaseCharacter attacker, BaseCharacter target)
      {
          int damage = attacker.AttackPower;
          target.TakeDamage(damage); 
      }
  }
}
