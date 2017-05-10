using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterBag : MonoBehaviour
{
    private List<Image> _myItems;
    private TypeEquipmentCharacter _myTypeBag;

    private List<EquipmentItem> _myEquipItems;

    private EquipmentsCharacter _equipmentsCharacter;

    private EquipmentItem _tempItem;
    void Awake()
    {
        _myItems = new List<Image>();
        Image[] _myItemsTemp = GetComponentsInChildren<Image>();
        for (int i = 1; i < _myItemsTemp.Length; i++)
            if (i % 2 == 0) _myItems.Add(_myItemsTemp[i]);
        _myEquipItems = new List<EquipmentItem>();
    }
    void OnEnable()
    {
        for (int i = 0; i < _myItems.Count; i++) _myItems[i].sprite = null;
        _myTypeBag = MappingData.ConvertStringToTypeItem(FittingRoomController.LastItemSelected);
        _myEquipItems.Clear();
        _myEquipItems = PlayerBag._instance.FliterByTypeEquipment(_myTypeBag);

        for (int i = 0; i < _myEquipItems.Count; i++)
        {
            _myItems[i].sprite = ControllerItemsInGame._instance.GetIconForItem(_myEquipItems[i].idItem, _myEquipItems[i].typeItem);
        }
    }

    public void BtnExitClick()
    {
        this.gameObject.SetActive(false);
    }
    public void BtnItemClick(int id)
    {
        if (id < _myEquipItems.Count)//item hợp lệ
        {
            /* 3 class cần tham gia thay đổi
             * EquipmentsCharacer cần mặc trang bị mới
             * PlayerBag cần nhận thêm trang bị cũ
             * FittingRoomController cần update hình ảnh
             */
            if (_equipmentsCharacter == null) _equipmentsCharacter = CharacterInfo._instance._myEquipments;
            if (_equipmentsCharacter.IsCanEquipItem(_myEquipItems[id]))
            {
                _tempItem = _equipmentsCharacter.MappingTypeItemToItem(_myTypeBag);
                if (_tempItem.idItem != 0) PlayerBag._instance._myItems.Add(_tempItem);
                _equipmentsCharacter.EquipItem(_myTypeBag, _myEquipItems[id]);
                PlayerBag._instance.RemoveEquipmentFromFliterBag(id);
                this.gameObject.SetActive(false);
            }
            else Debug.Log("Không đủ điều kiện mặc đồ");
        }
    }
}
