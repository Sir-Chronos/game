using RPG.Characters;

namespace RPG.Strategy
{
  public class DefenseStrategy : IAttackStrategy
  {
    private readonly int _defenseBoost;

    public DefenseStrategy(int defenseBoost)
    {
      _defenseBoost = defenseBoost;
    }

    public void Execute(BaseCharacter attacker, BaseCharacter target)
    {
      target.ApplyDefenseBoost(_defenseBoost);  // Aplica o aumento de defesa
      Console.WriteLine($"{target.GetType().Name} aplicou uma defesa aumentada de {_defenseBoost} pontos.");
    }
  }
}
