/*
 * Đây là class thể hiện các thông tin cơ bản của nhân vật. Nhiều vãi
 */

public enum ClassPlayer { Marksman }

public  class CharacterProperties
{
    //Level Proerties
    public int Level;
    public long Exp;
    public ClassPlayer _myClass;

    //Base Properties
    public int Strength;
    public int Intelligence;
    public int Dexterity;
    public int Focus;
    public int Viality;
    public int Immortality;
    public int Luck;
    public int Weakness;
    public int Marvel;

    //Public Properties
    public float PhysicalDamage;
    public float MagicalDamage;
    public float CriticalChance;
    public float Blocking;
    public float MultiCastChange;
    public float PhysicalDefense;
    public float MagicalDefense;
    public float Health;
    public float Reputation;

    //Hidden Properties
    public float AttackRate;
    public float ParryRate;
    public float PhysicalReinforce;
    public float MagicalReinforce;
    public float MagicResistance;
    public float FreezeChance;
    public float BurnChance;
    public float PoisonChance;
    public float ShockChance;
    public float KnockBackChance;
    public float ImmobilizeChance;
    public float BlindChance;
    public float SilenceChance;
    public float FreezingDurationReduce;
    public float PoisoningDurationReduce;
    public float ElectricShockDurationReduce;
    public float BurnHourDurationReduce;
    public float KnockBackResistance;
    public float ImmobilizationResistance;
    public float BlindnessResistance;
    public float SilenceResistance;


    //Method
    public  void StartNewCharacter()
    { }
    public  void LevelUpCharacter()
    { }
    public void CalculatirProperties()
    {

    }

}
