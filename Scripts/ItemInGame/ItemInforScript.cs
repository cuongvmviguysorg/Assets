using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemInforScript : MonoBehaviour
{
    private EquipmentItem _myItem;
    private List<AttributeEquipmentItem> _listAtributes;

    public Text _txtName, _txtSlot, _txtType, _txtLevel;
    public Image _iconItem;
    public Transform _AttributeTransform;
    private List<Text> _myAttributesTxt;
    public RectTransform _myPopup;
    private int numberAttribute;

    private int basePopup = 320;
    private int maxPopup = 650;
    private int stepAttribute = 30;
    private int startAttribute = 80;
    public GameObject txtAttributePrefabs;
    private GameObject _tempGameObject;
    private Text _tempText;

    public void SetData(EquipmentItem _item)
    {
        _item = _myItem;
        _listAtributes = _item.attributeItems;
    }
    void OnEnable()
    {
        if (_myItem == null) return;
        _txtName.text = _myItem.nameItem;
        _txtName.color = MappingData.ConvertRarelyToColor(_myItem.rarelyItem);
        _txtSlot.text = string.Format("Slot: {0}", MappingData.ConvertTypeItemToString(_myItem.typeItem));
        _txtType.text = string.Format("Type: {0}", _myItem.classItem.ToString());
        _txtLevel.text = string.Format("Level required: {0}", _myItem.levelRequired.ToString());

        ShowAttribute();
    }
    void ShowAttribute()
    {
        if (_myAttributesTxt == null) _myAttributesTxt = new List<Text>();
        _myPopup.sizeDelta = new Vector2(700, basePopup + stepAttribute * _listAtributes.Count);

        numberAttribute = _listAtributes.Count;
        for (int i = 0; i < numberAttribute; i++)
        {
            if (i < _myAttributesTxt.Count)
            {
                _myAttributesTxt[i].gameObject.SetActive(true);
                _tempText = _myAttributesTxt[i];
                _myAttributesTxt[i].transform.localPosition = new Vector3(0, startAttribute + stepAttribute * (numberAttribute - 1 - i));
            }
            else
            {
                _tempGameObject = Instantiate(txtAttributePrefabs) as GameObject;
                _tempGameObject.transform.SetParent(_AttributeTransform);
                _tempGameObject.transform.localScale = Vector3.one;
                _tempGameObject.transform.localPosition = new Vector3(0, startAttribute + stepAttribute * (numberAttribute - 1 - i));
                _tempText = _tempGameObject.GetComponent<Text>();
                _myAttributesTxt.Add(_tempText);
            }

            _tempText.text = string.Format("{0} + {1}{2}", _listAtributes[i].nameAttribute,
                _listAtributes[i].valueAttribute, (_listAtributes[i].unitValue == UnitAtributeItem.Percent ? "%" : ""));
        }

        for (int i = numberAttribute; i < _myAttributesTxt.Count; i++)
        {
            _myAttributesTxt[i].gameObject.SetActive(false);
        }
    }


    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            _listAtributes = new List<AttributeEquipmentItem>();
            int number = Random.Range(1, 11);
            Debug.Log(number);
            for (int i = 0; i < number; i++) _listAtributes.Add(new AttributeEquipmentItem());
            ShowAttribute();
        }
    }
}
