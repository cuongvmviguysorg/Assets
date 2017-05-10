/*
 * Đây là đơn vị chỉ số của thuộc tính
 * Bao gốm giá trị cộng tuyệt đối, cộng theo %
 */
using UnityEngine;
public enum UnitAtributeItem { Percent, Absolute }


/*
 * Đây là class thể hiện các dòng thuộc tính của trang bị
 */
public class AttributeEquipmentItem
{
    internal int idAttribute;
    internal string nameAttribute;
    internal RarelyItem rarelyAttributes;
    internal UnitAtributeItem unitValue;
    internal float valueAttribute;
    internal int valuePoint;
    public AttributeEquipmentItem()
    {
        idAttribute = Random.Range(0, 10) % 15 + 1;
        nameAttribute = ControllerItemsInGame._instance.GetNameAttributeByID(idAttribute);
        unitValue = Random.Range(0, 10) % 2 == 0 ? UnitAtributeItem.Absolute : UnitAtributeItem.Percent;
        valueAttribute = Random.Range(1, 10);
    }
}
