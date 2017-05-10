using UnityEngine;
public class MappingData
{
    public static string ConvertTypeItemToString(TypeEquipmentCharacter _type)
    {
        switch (_type)
        {
            case TypeEquipmentCharacter.Head: return "00";
            case TypeEquipmentCharacter.Weapon: return "01";
            case TypeEquipmentCharacter.Shield: return "02";
            case TypeEquipmentCharacter.Torso: return "03";
            case TypeEquipmentCharacter.Leg: return "04";
            case TypeEquipmentCharacter.Gloves: return "05";
            case TypeEquipmentCharacter.Boots: return "06";
            case TypeEquipmentCharacter.Belt: return "07";
            case TypeEquipmentCharacter.Amulet: return "08";
            case TypeEquipmentCharacter.Ring: return "09";
            case TypeEquipmentCharacter.Buff: return "10";
            case TypeEquipmentCharacter.Avatar: return "11";
            case TypeEquipmentCharacter.Gem: return "12";
            case TypeEquipmentCharacter.AlchemyMaterial: return "13";
            case TypeEquipmentCharacter.LuckMaterial: return "14";
            case TypeEquipmentCharacter.HPRecovery: return "15";
            case TypeEquipmentCharacter.Scroll: return "16";
            case TypeEquipmentCharacter.VIPCard: return "17";
        }
        return "99";
    }
    public static TypeEquipmentCharacter ConvertStringToTypeItem(int type)
    {
        string id = type < 10 ? ("0" + type) : type.ToString();
        switch (id)
        {
            case "00": return TypeEquipmentCharacter.Head;
            case "01": return TypeEquipmentCharacter.Weapon;
            case "02": return TypeEquipmentCharacter.Shield;
            case "03": return TypeEquipmentCharacter.Torso;
            case "04": return TypeEquipmentCharacter.Leg;
            case "05": return TypeEquipmentCharacter.Gloves;
            case "06": return TypeEquipmentCharacter.Boots;
            case "07": return TypeEquipmentCharacter.Belt;
            case "08": return TypeEquipmentCharacter.Amulet;
            case "09": return TypeEquipmentCharacter.Ring;
            case "10": return TypeEquipmentCharacter.Buff;
            case "11": return TypeEquipmentCharacter.Avatar;
            case "12": return TypeEquipmentCharacter.Gem;
            case "13": return TypeEquipmentCharacter.AlchemyMaterial;
            case "14": return TypeEquipmentCharacter.LuckMaterial;
            case "15": return TypeEquipmentCharacter.HPRecovery;
            case "16": return TypeEquipmentCharacter.Scroll;
            case "17": return TypeEquipmentCharacter.VIPCard;
        }
        return TypeEquipmentCharacter.None;
    }

    public static Color32 ConvertRarelyToColor(RarelyItem _rarely)
    {
        switch (_rarely)
        {
            case RarelyItem.Common: return Color.white;
            case RarelyItem.Rare: return Color.cyan;
            case RarelyItem.Mystical: return Color.green;
            case RarelyItem.Legendary: return Color.yellow;
            case RarelyItem.Unique: return Color.red;
        }
        return Color.white;
    }
}
