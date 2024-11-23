using System;
using System.Collections.Generic;
using RPG.Strategy;
using RPG.Observer;
using RPG.Utils;


namespace RPG.Characters
{
    public abstract class BaseCharacter
    {
        public int Health { get; protected set; }
        public int Defense { get; protected set; }
        public int AttackPower { get; protected set; }
        public IAttackStrategy AttackStrategy { get; set; } = new BasicAttackStrategy();
        public bool IsAlive => Health > 0;

        private readonly List<IObserver<BaseCharacter>> _observers = new();

        public string CharacterType { get; private set; } // Propriedade com set privado

        protected BaseCharacter(int health, int defense, int attackPower, string characterType)
        {
            Health = health;
            Defense = defense;
            AttackPower = attackPower;
            CharacterType = characterType ?? throw new ArgumentNullException(nameof(characterType));
        }

        public virtual void PerformAttack(BaseCharacter target)
        {
            AttackStrategy.Execute(this, target);
            NotifyObservers();
        }

        public virtual void TakeDamage(int damage)
        {
            int damageTaken = Math.Max(0, damage - Defense);
            Health -= damageTaken;
            Console.WriteLine($"{GetType().Name} recebeu {damageTaken} de dano. Saúde restante: {Health}");
            NotifyObservers();
        }

        public void ApplyDefenseBoost(int boost)
        {
            Defense += boost;
            Console.WriteLine($"{GetType().Name} recebeu um aumento de defesa de {boost}. Defesa total: {Defense}");
        }


        public void RegisterObserver(IObserver<BaseCharacter> observer)
        {
            _observers.Add(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(this);
            }
        }

        public CharacterMemento SaveState()
        {
            return new CharacterMemento(
                GetType().Name,
                Health,
                Defense,
                AttackPower
            );
        }

    }
}
