using System;
using RPG.Strategy;

namespace RPG.Characters
{
    public abstract class BaseEnemy : BaseCharacter
    {
        protected BaseEnemy(int health, int defense, int attackPower)
            : base(health, defense, attackPower)
        {
        }

        // Método para definir o comportamento do inimigo no combate
        public abstract void Attack(BaseCharacter target);
    }
}
