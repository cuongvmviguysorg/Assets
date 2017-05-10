using System.Collections.Generic;
using UnityEngine;

public class PlayerBag : MonoBehaviour
{
    public static PlayerBag _instance;
    internal List<EquipmentItem> _myItems;

    IDictionary<int, int> _mapBagToFliter;
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);

            _mapBagToFliter = new Dictionary<int, int> { };
            _myItems = new List<EquipmentItem>();
            //Loading data bag

            //fake items;
            for (int i = 0; i < 10; i++)
            {
                _myItems.Add(new EquipmentItem(2, i));
                _myItems.Add(new EquipmentItem(3, i));
            }
            this.RegisterListener(EventID.AddItemToBag, (sender, param) => AddItemToBag((EquipmentItem)param));
        }
        else DestroyObject(this.gameObject);
    }
    public List<EquipmentItem> FliterByTypeEquipment(TypeEquipmentCharacter _type)
    {
        _mapBagToFliter.Clear();
        List<EquipmentItem> _newList = new List<EquipmentItem>();
        for (int i = 0; i < _myItems.Count; i++)
        {
            if (_myItems[i].typeItem == _type)
            {
                _mapBagToFliter.Add(i, _newList.Count);
                _newList.Add(_myItems[i]);
            }
        }
        return _newList;
    }
    public void RemoveEquipmentFromFliterBag(int _index)
    {
        foreach (var _map in _mapBagToFliter)
        {
            if (_map.Value == _index)
            {
                _myItems.RemoveAt(_map.Key);
                return;
            }
        }
        Debug.Log("Không tìm thấy");
    }

    public void AddItemToBag(EquipmentItem _item)
    {
        _myItems.Add(_item);
    }
    internal void SortBag()
    {
    }
}
