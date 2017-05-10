/*
 * Đây là class lưu trữ các đồ đang mặc của người chơi
 */
using UnityEngine;
public class EquipmentsCharacter
{
    internal EquipmentItem headItem;
    internal EquipmentItem weaponItem;
    internal EquipmentItem shieldItem;
    internal EquipmentItem torsoItem;
    internal EquipmentItem legItem;
    internal EquipmentItem beltItem;
    internal EquipmentItem glovesItem;
    internal EquipmentItem bootsItem;
    internal EquipmentItem amuletItem;
    internal EquipmentItem ringItem;
    internal EquipmentItem buffItem;
    internal EquipmentItem avatarItem;

    private EquipmentItem _tempItem;

    public delegate void ChangeItem();
    public static event ChangeItem ChangeItemEvent;
    internal TypeEquipmentCharacter _lastEquipmentChange;
    public EquipmentsCharacter()
    {
        //fake item
        headItem = new EquipmentItem(1, 0);
        weaponItem = new EquipmentItem(1, 1);
        shieldItem = new EquipmentItem(1, 2);
        torsoItem = new EquipmentItem(1, 3);
        legItem = new EquipmentItem(1, 4);
        glovesItem = new EquipmentItem(1, 5);
        bootsItem = new EquipmentItem(1, 6);
        beltItem = new EquipmentItem(1, 7);
        amuletItem = new EquipmentItem(1, 8);
        ringItem = new EquipmentItem(1, 9);
        buffItem = null;
        avatarItem = null;
    }
    internal void EquipItem(TypeEquipmentCharacter slot, EquipmentItem newEquip)
    {
        if (newEquip.typeItem == slot) // Mặc đồ mới
        {
            if (CharacterInfo._instance._baseProperties.Level >= newEquip.levelRequired)
            {
                _tempItem = MappingTypeItemToItem(slot);// = newEquip;
                _tempItem = newEquip;
                MappingTempItemToItem(slot, _tempItem);
                _lastEquipmentChange = slot;
                ChangeItemEvent();
            }
        }
    }
    internal bool IsCanEquipItem(EquipmentItem newEquip)
    {
        if (CharacterInfo._instance._baseProperties.Level >= newEquip.levelRequired)
        {
            return true;
        }
        return false;
    }
    internal bool isHaveItem(TypeEquipmentCharacter slot)
    {
        return MappingTypeItemToItem(slot).idItem == 0 ? false : true;
    }
    internal EquipmentItem MappingTypeItemToItem(TypeEquipmentCharacter slot)
    {
        switch (slot)
        {
            case TypeEquipmentCharacter.Head: return headItem;
            case TypeEquipmentCharacter.Weapon: return weaponItem;
            case TypeEquipmentCharacter.Shield: return shieldItem;
            case TypeEquipmentCharacter.Torso: return torsoItem;
            case TypeEquipmentCharacter.Leg: return legItem;
            case TypeEquipmentCharacter.Gloves: return glovesItem;
            case TypeEquipmentCharacter.Boots: return bootsItem;
            case TypeEquipmentCharacter.Belt: return beltItem;
            case TypeEquipmentCharacter.Amulet: return amuletItem;
            case TypeEquipmentCharacter.Ring: return ringItem;
        }
        return null;
    }
    internal void MappingTempItemToItem(TypeEquipmentCharacter slot, EquipmentItem _tempItem)
    {
        switch (slot)
        {
            case TypeEquipmentCharacter.Head: headItem = _tempItem; break;
            case TypeEquipmentCharacter.Weapon: weaponItem = _tempItem; break;
            case TypeEquipmentCharacter.Shield: shieldItem = _tempItem; break;
            case TypeEquipmentCharacter.Torso: torsoItem = _tempItem; break;
            case TypeEquipmentCharacter.Leg: legItem = _tempItem; break;
            case TypeEquipmentCharacter.Gloves: glovesItem = _tempItem; break;
            case TypeEquipmentCharacter.Boots: bootsItem = _tempItem; break;
            case TypeEquipmentCharacter.Belt: beltItem = _tempItem; break;
            case TypeEquipmentCharacter.Amulet: amuletItem = _tempItem; break;
            case TypeEquipmentCharacter.Ring: ringItem = _tempItem; break;
        }
    }
}
