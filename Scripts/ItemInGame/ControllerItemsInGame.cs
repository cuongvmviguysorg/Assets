using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class ControllerItemsInGame : MonoBehaviour
{
    public static ControllerItemsInGame _instance;
    ReadXML _dataEquipment, _dataGem;
    private IDictionary<string, Sprite> _myIcons;
    Sprite[] _listSpriteArmor, _listSpriteRings;
    void Awake()
    {
        if (_instance == null)
        {
            //Debug.Log("instance");
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
            _myIcons = new Dictionary<string, Sprite> { };
            _dataEquipment = new ReadXML("XMLFiles/Items/Armor");
            _dataGem = new ReadXML("XMLFiles/AttributeItem");
            _listSpriteArmor = Resources.LoadAll<Sprite>("Textures/Items/Armors");
            _listSpriteRings = Resources.LoadAll<Sprite>("Textures/Items/Rings");
        }
        else DestroyImmediate(this.gameObject);
    }
    internal Sprite GetIconForItem(EquipmentItem _item)
    {
        if (_item.idItem == 0 || _item.typeItem == TypeEquipmentCharacter.None) return null;
        else return GetIconForItem(_item.idItem, _item.typeItem);
    }
    internal Sprite GetIconForItem(int _idItem, TypeEquipmentCharacter _typeItem)
    {
        string newKey = FormatItemToKey(_idItem, _typeItem);
        foreach (var icon in _myIcons)
        {
            if (icon.Key == newKey)//nếu đã load rồi
            {
                return icon.Value;
            }
        }
        XmlNode _myItemXml = _dataEquipment.getDataByValue("id", _idItem.ToString(), "posi", _typeItem.ToString());
        if (_myItemXml == null) return null;
        Sprite _tempSprite = GetSpriteByName(_myItemXml.Attributes["name"].Value);
        _myIcons.Add(newKey, _tempSprite);
        return _tempSprite;
    }

    private string FormatItemToKey(int _id, TypeEquipmentCharacter _type)
    {   //AABB
        string Prefixes = MappingData.ConvertTypeItemToString(_type);
        string Suffixes = _id > 9 ? _id.ToString() : ("0" + _id.ToString());
        return string.Format("{0}{1}", Prefixes, Suffixes);
    }
    internal Sprite GetSpriteByName(string name)
    {
        for (int i = 0; i < _listSpriteArmor.Length; i++)
        {
            if (_listSpriteArmor[i].name == name)
                return _listSpriteArmor[i];
        }
        for (int i = 0; i < _listSpriteRings.Length; i++)
        {
            if (_listSpriteRings[i].name == name)
                return _listSpriteRings[i];
        }
        return null;
    }
    internal string GetNameAttributeByID(int id)
    {
        Debug.Log(_dataGem.ToString());
        XmlNode _data = _dataGem.getDataByValue("id", id.ToString());
        if (_data == null)
        {
            Debug.LogError("Không tìm thấy gem id=" + id);
            return string.Empty;
        }
        else
        {
            Debug.Log("Tìm thấy gem id =" + id);
            return _data.Attributes["attribute"].Value;
        }
    }


}

