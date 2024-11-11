namespace RPG.Characters
{
    public abstract class BaseCharacter
    {
        // Atributos base e atuais
        public Stats BaseStats { get; private set; }
        public Stats CurrentStats { get; private set; }

        public int Level { get; private set; }
        public int Xp { get; private set; }
        public int BaseXp { get; private set; }

        private readonly Random rng = new Random();

        public enum DamageType { Physical, Magical }

        public BaseCharacter(Stats baseStats, int level, int xp, int baseXp)
        {
            BaseStats = baseStats;
            CurrentStats = new Stats(baseStats);
            Level = level;
            Xp = xp;
            BaseXp = baseXp;
        }

        public abstract void BasicAttack(BaseCharacter target);
        public abstract void SpecialAttack(BaseCharacter target);
        public abstract void UtilitySpell();

        public virtual void Rest()
        {
            CurrentStats.Health = Math.Min(CurrentStats.Health + (int)(BaseStats.Health * 0.3), BaseStats.Health);
            CurrentStats.Mana = Math.Min(CurrentStats.Mana + BaseStats.Mana, BaseStats.Mana);
        }

        public virtual void TakeDamage(int damage, DamageType type)
        {
            if (!Dodge())
            {
                int effectiveDefense = (type == DamageType.Physical) ? CurrentStats.Defense : CurrentStats.MagicDefense;
                CurrentStats.Health -= Math.Max(damage - effectiveDefense, 0);
            }
        }

        public virtual bool Dodge()
        {
            return rng.Next(0, 101) < CurrentStats.Agility;
        }

        public virtual void LevelUp()
        {
            if (Xp >= BaseXp)
            {
                Level++;
                Xp -= BaseXp;
                BaseXp = (int)(BaseXp * 1.5);
                ApplyLevelBonuses();
            }
        }

        private void ApplyLevelBonuses()
        {
            BaseStats.ApplyScaling(1.2, Level);
            CurrentStats = new Stats(BaseStats);  // Reinicia os valores atuais com base nos atributos base
        }

        public void GainXp(int amount)
        {
            Xp += amount;
            LevelUp();
        }
    }

    public class Stats
    {
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Defense { get; set; }
        public int MagicDefense { get; set; }
        public int Attack { get; set; }
        public int MagicAttack { get; set; }
        public int Speed { get; set; }
        public int Agility { get; set; }

        public Stats(int health, int mana, int defense, int magicDefense, int attack, int magicAttack, int speed, int agility)
        {
            Health = health;
            Mana = mana;
            Defense = defense;
            MagicDefense = magicDefense;
            Attack = attack;
            MagicAttack = magicAttack;
            Speed = speed;
            Agility = agility;
        }

        public Stats(Stats other)
        {
            Health = other.Health;
            Mana = other.Mana;
            Defense = other.Defense;
            MagicDefense = other.MagicDefense;
            Attack = other.Attack;
            MagicAttack = other.MagicAttack;
            Speed = other.Speed;
            Agility = other.Agility;
        }

        public void ApplyScaling(double factor, int level)
        {
            Health = (int)(Health * Math.Pow(factor, level - 1));
            Mana = (int)(Mana * Math.Pow(factor, level - 1));
            Defense = (int)(Defense * Math.Pow(factor, level - 1));
            MagicDefense = (int)(MagicDefense * Math.Pow(factor, level - 1));
            Attack = (int)(Attack * Math.Pow(factor, level - 1));
            MagicAttack = (int)(MagicAttack * Math.Pow(factor, level - 1));
            Speed = (int)(Speed * Math.Pow(factor, level - 1));
            Agility = (int)(Agility * Math.Pow(factor, level - 1));
        }
    }
}
