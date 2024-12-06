using RPG.Characters;

namespace RPG.Strategy
{
  public class SpecialAbilityStrategy : IAttackStrategy
  {
    public void Execute(BaseCharacter attacker, BaseCharacter target)
    {
      int specialDamage = attacker.AttackPower * 2;
      target.TakeDamage(specialDamage);
      Console.WriteLine($"{attacker.GetType().Name} usou uma habilidade especial causando {specialDamage} de dano!");
    }
  }
}
