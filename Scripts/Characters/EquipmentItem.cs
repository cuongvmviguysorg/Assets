
using System.Collections.Generic;
using UnityEngine;

/*
 * Đây là enum list các loại đồ trong game
 */
public enum TypeEquipmentCharacter
{
    None = 0, Weapon, Shield, Head, Torso, Leg, Belt, Gloves, Boots, Ring, Amulet, Gem, AlchemyMaterial, Avatar, Buff, VIPCard, Scroll, HPRecovery, LuckMaterial
}

/*
 * Đây là enum list các loại phân nhóm giáp trong game ( giáp nặng, giáp nhẹ, giáp vải)
 * Mỗi class sẽ thích hợp mặc các loại nhóm giáp riêng
 */
public enum ClassCharacterItem
{
    IronArmor, LeatherArmor, SilkArmor, None
}

/*
 * Đây là độ hiếm của các item trong game
 */
public enum RarelyItem
{
    Common, Rare, Mystical, Legendary, Unique
}


/*
 * Class này thể hiện một đồ bất kỳ trong game
 */
public class EquipmentItem
{
    internal int idItem;
    internal TypeEquipmentCharacter typeItem; //99 loại : 2 số đầu
    internal ClassCharacterItem classItem;
    internal RarelyItem rarelyItem;
    internal int idGroupSetItems;
    internal string nameItem;
    internal int levelRequired;
    internal int levelUpgraded;
    internal List<AttributeEquipmentItem> attributeItems;
    internal int valueItem;
    internal int numberItem; // dành cho các item có số lượng : nguyên liệu,...

    private int _valueEstimate;

    internal void ReadBasicInfor()
    {

    }
    internal int EstimateItem()
    {
        _valueEstimate = 0;
        //Chỉ số cơ bản của đồ

        //chỉ số cộng thêm từ các dòng thuộc tính
        for (int i = 0; i < attributeItems.Count; i++) _valueEstimate += attributeItems[i].valuePoint;
        return _valueEstimate;
    }
    internal void UpgradeItem()
    {

    }
    internal void ChangeAttributes()
    {

    }

    public EquipmentItem()
    {
        idItem = 0;
        typeItem = TypeEquipmentCharacter.None;
    }
    public EquipmentItem(int id, int type)
    {
        idItem = id;
        typeItem = MappingData.ConvertStringToTypeItem(type);
    }
    public EquipmentItem(int id, TypeEquipmentCharacter _type)
    {
        idItem = id;
        typeItem = _type;
        levelRequired = 0;
    }
    public void RemoveItem()
    {
        idItem = 0;
        typeItem = TypeEquipmentCharacter.None;
        classItem = ClassCharacterItem.None;
        rarelyItem = RarelyItem.Common;
        idGroupSetItems = -1;
        nameItem = string.Empty;
        levelRequired = 0;
        levelUpgraded = 0;
        attributeItems = new List<AttributeEquipmentItem>();
        valueItem = 0;
        numberItem = 1;
    }
}
