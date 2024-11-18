namespace RPG.Utils
{
    public class CharacterMemento
    {
        public string ClassName { get; }
        public int Health { get; }
        public int Defense { get; }
        public int AttackPower { get; }

        public CharacterMemento(string className, int health, int defense, int attackPower)
        {
            ClassName = className;
            Health = health;
            Defense = defense;
            AttackPower = attackPower;
        }
    }
}
