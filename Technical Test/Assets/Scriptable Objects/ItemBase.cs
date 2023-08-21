using UnityEngine;

public class ItemBase : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite icon;
    public int buyPrice;
    public int sellPrice;
    public bool isAvailable = true;
    public bool isEquipped;
    public EquipmentType equipmentType;
}
