using System;
using System.Collections.Generic;
using RPG.Strategy;
using RPG.Observer;
using RPG.Utils;

namespace RPG.Characters
{
    // Alias para desambiguar o IObserver do seu namespace
    using RPGObserver = RPG.Observer.IObserver<BaseCharacter>;

    public abstract class BaseCharacter
    {
        public int Health { get; protected set; }
        public int Defense { get; protected set; }
        public int AttackPower { get; protected set; }
        public IAttackStrategy AttackStrategy { get; set; } = new BasicAttackStrategy();
        public bool IsAlive => Health > 0;

        private readonly List<RPGObserver> _observers = new();

        // Construtor para inicializar o personagem
        protected BaseCharacter(int health, int defense, int attackPower)
        {
            Health = health;
            Defense = defense;
            AttackPower = attackPower;
        }

        // Método público para atualizar os valores do personagem
        public void UpdateStats(int health, int defense, int attackPower)
        {
            Health = health;
            Defense = defense;
            AttackPower = attackPower;
        }

        public virtual void PerformAttack(BaseCharacter target)
        {
            AttackStrategy.Execute(this, target);
            NotifyObservers();
        }

        public virtual void TakeDamage(int damage)
        {
            int damageTaken = Math.Max(1, damage - Defense);
            Health -= damageTaken;
            Console.WriteLine($"{GetType().Name} recebeu {damageTaken} de dano após escudo mágico. Saúde restante: {Health}");
            NotifyObservers();
        }


        public void ApplyDefenseBoost(int boost)
        {
            Defense += boost;
            Console.WriteLine($"{GetType().Name} recebeu um aumento de defesa de {boost}. Defesa total: {Defense}");
        }

        // Registra o observador
        public void RegisterObserver(RPGObserver observer)
        {
            _observers.Add(observer);
        }

        // Notifica os observadores
        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(this);
            }
        }

        // Método para salvar o estado do personagem
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
