using UnityEngine;
using UnityEngine.UI;

public class FittingRoomController : MonoBehaviour
{
    public static int LastItemSelected;

    public Image _helmsItem, _weaponItem, _shieldItem, _armorItem, _pantItem, _glovesItem, _bootItem, _beltItem, _NecklaceItem, _ringItem;
    public GameObject _optionChangeItem, _fliterBag;

    private EquipmentsCharacter _characterEquip;
    private TypeEquipmentCharacter _typeItem;

    private Vector3 _offsetOptionNormal = new Vector3(0, -100);
    private Vector3 _offsetOptionSmall = new Vector3(0, -50);

    public PlayerShowFittingRoom _playerSprite;
    void Start()
    {
        LastItemSelected = -1;
        if (CharacterInfo._instance == null)
        {
            Debug.LogError("Lỗi to đùng");
            return;
        }
        _characterEquip = CharacterInfo._instance._myEquipments;

        MappingIndexToImage(0).sprite = ControllerItemsInGame._instance.GetIconForItem(_characterEquip.headItem);
        MappingIndexToImage(1).sprite = ControllerItemsInGame._instance.GetIconForItem(_characterEquip.weaponItem);
        MappingIndexToImage(2).sprite = ControllerItemsInGame._instance.GetIconForItem(_characterEquip.shieldItem);
        MappingIndexToImage(3).sprite = ControllerItemsInGame._instance.GetIconForItem(_characterEquip.torsoItem);
        MappingIndexToImage(4).sprite = ControllerItemsInGame._instance.GetIconForItem(_characterEquip.legItem);
        MappingIndexToImage(5).sprite = ControllerItemsInGame._instance.GetIconForItem(_characterEquip.glovesItem);
        MappingIndexToImage(6).sprite = ControllerItemsInGame._instance.GetIconForItem(_characterEquip.bootsItem);
        MappingIndexToImage(7).sprite = ControllerItemsInGame._instance.GetIconForItem(_characterEquip.beltItem);
        MappingIndexToImage(8).sprite = ControllerItemsInGame._instance.GetIconForItem(_characterEquip.amuletItem);
        MappingIndexToImage(9).sprite = ControllerItemsInGame._instance.GetIconForItem(_characterEquip.ringItem);

        EquipmentsCharacter.ChangeItemEvent += EquipmentsCharacter_ChangeItemEvent;
    }
    void OnDisable()
    {
        EquipmentsCharacter.ChangeItemEvent -= EquipmentsCharacter_ChangeItemEvent;
    }

    void EquipmentsCharacter_ChangeItemEvent()
    {
        int id = int.Parse(MappingData.ConvertTypeItemToString(_characterEquip._lastEquipmentChange).Substring(1));
        MappingIndexToImage(id).sprite = ControllerItemsInGame._instance.GetIconForItem(_characterEquip.MappingTypeItemToItem(_characterEquip._lastEquipmentChange));
        if (id == 3) _playerSprite.ChangeSkin();
    }

    public void BtnItemClick(int id)
    {
        if (_optionChangeItem.activeSelf && id == LastItemSelected)
        {
            _optionChangeItem.SetActive(false);
            LastItemSelected = -1;
        }
        else
        {
            _optionChangeItem.SetActive(false);
            _optionChangeItem.transform.localPosition = MappingIndexToImage(id).transform.parent.localPosition + (id < 8 ? _offsetOptionNormal : _offsetOptionSmall);
            _optionChangeItem.SetActive(true);
            LastItemSelected = id;
        }
    }
    public void BtnOptionClick(int id)
    {
        if (id == 0)//Btn Replace
        {
            _fliterBag.SetActive(true);
        }
        else if (id == 1) //BtnRemove
        {
            _typeItem = MappingData.ConvertStringToTypeItem(LastItemSelected);

            if (_characterEquip.isHaveItem(_typeItem))
            {
                PlayerBag._instance._myItems.Add(_characterEquip.MappingTypeItemToItem(_typeItem));
                _characterEquip.EquipItem(_typeItem, new EquipmentItem(0, _typeItem));
            }
            else Debug.Log("Không có gì đâu");
        }
        _optionChangeItem.SetActive(false);
        LastItemSelected = -1;
    }

    private Image MappingIndexToImage(int id)
    {
        switch (id)
        {
            case 0: return _helmsItem;
            case 1: return _weaponItem;
            case 2: return _shieldItem;
            case 3: return _armorItem;
            case 4: return _pantItem;
            case 5: return _glovesItem;
            case 6: return _bootItem;
            case 7: return _beltItem;
            case 8: return _NecklaceItem;
            case 9: return _ringItem;
        }
        return null;
    }
}
