using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    public static CharacterInfo _instance;
    internal CharacterProperties _baseProperties;
    internal EquipmentsCharacter _myEquipments;
    internal List<SkillCharacter> _mySkills;
    internal List<EffectBuffCharacter> _myEffects;
    internal int _statPoints;
    internal int _actionPoints;

    void Awake()
    {
        _instance = this;
        _myEquipments = new EquipmentsCharacter();
        _baseProperties = new CharacterProperties();
        _baseProperties.Level = 1;
    }
}
