using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventario : MonoBehaviour
{
    [SerializeField] private ItemBase[] itemsInInventario;
    [SerializeField] private Image[] itemImages;
    [SerializeField] private TMP_Text[] itemNameText;
    [SerializeField] private TMP_Text[] itemPriceText;
    [SerializeField] private TMP_Text[] itemDescription;
    [SerializeField] private Button[] itemButton;

    [SerializeField] private ItemBase equippedAttackItem;
    [SerializeField] private ItemBase equippedDefenseItem;
    [SerializeField] private ItemBase equippedHealthItem;

    void Start()
    {
        for (int i = 0; i < itemsInInventario.Length; i++)
        {
            if (itemsInInventario[i] != null && i < itemImages.Length)
            {
                itemImages[i].gameObject.SetActive(true);
                itemImages[i].sprite = itemsInInventario[i].icon;
                itemNameText[i].text = itemsInInventario[i].itemName;
                itemPriceText[i].text = "Price: " + itemsInInventario[i].sellPrice;
                itemDescription[i].text = itemsInInventario[i].description;
            }
            else if (itemsInInventario[i] == null && i < itemImages.Length)
            {
                itemImages[i].gameObject.SetActive(false);
            }
        }
    }
    public void ActualizarItem(ItemBase item)
    {
        // Encontrar el primer espacio disponible en el inventario
        int inventorySlot = -1;
        for (int i = 0; i < itemsInInventario.Length; i++)
        {
            if (itemsInInventario[i] == null)
            {
                inventorySlot = i;
                break;
            }
        }

        if (inventorySlot != -1)
        {
            // Mover el item al inventario
            itemsInInventario[inventorySlot] = item;

            // Actualizar la visualización del inventario
            UpdateInventoryUI();
        }
    }
    public void SellItem(int index)
    {
        if (index >= 0 && index < itemsInInventario.Length)
        {
            ItemBase itemToSell = itemsInInventario[index];

            if (itemToSell != null)
            {
                GameController.Instance.SellItem(itemToSell);
            }
            itemToSell = null;
        }
    }

    public void UpdateInventoryUI()
    {
        for (int i = 0; i < itemsInInventario.Length; i++)
        {
            if (itemsInInventario[i] != null && i < itemImages.Length)
            {
                itemImages[i].gameObject.SetActive(true);
                itemImages[i].sprite = itemsInInventario[i].icon;
                itemNameText[i].text = itemsInInventario[i].itemName;
                itemPriceText[i].text = "Price: " + itemsInInventario[i].sellPrice;
                itemDescription[i].text = itemsInInventario[i].description;
            }
            else if (itemsInInventario[i] == null && i < itemImages.Length)
            {
                itemImages[i].gameObject.SetActive(false);
            }
        }
    }
    public void EquipItem(ItemBase item)
    {
        switch (item.equipmentType)
        {
            case EquipmentType.Attack:
                equippedAttackItem = item;
                ApplyAttackEffects(item); // Aplicar efectos de ataque
                break;
            case EquipmentType.Defense:
                equippedDefenseItem = item;
                ApplyDefenseEffects(item); // Aplicar efectos de defensa
                break;
            case EquipmentType.Health:
                equippedHealthItem = item;
                ApplyHealthEffects(item); // Aplicar efectos de salud
                break;
        }

        UpdateUIWithEquippedItem(item); // Actualizar la interfaz con el ítem equipado
    }
    private void ApplyAttackEffects(ItemBase attackItem)
    {
        // Lógica para aplicar efectos de ataque
    }

    private void ApplyDefenseEffects(ItemBase defenseItem)
    {
        // Lógica para aplicar efectos de defensa
    }

    private void ApplyHealthEffects(ItemBase healthItem)
    {
        // Lógica para aplicar efectos de salud
    }

    private void UpdateUIWithEquippedItem(ItemBase equippedItem)
    {
        // Mostrar un texto en la interfaz con el ítem equipado
    }
}
