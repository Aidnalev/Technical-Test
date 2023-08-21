using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Store : MonoBehaviour
{
    [SerializeField] private ItemBase[] itemsInStore;
    [SerializeField] private Image[] itemImages;
    [SerializeField] private TMP_Text[] itemNameText;
    [SerializeField] private TMP_Text[] itemPriceText;
    [SerializeField] private TMP_Text[] itemDescription;
    [SerializeField] private Button[] itemButton;

    void Start()
    {
        for (int i = 0; i < itemsInStore.Length; i++)
        {
            if (itemsInStore[i] != null && i < itemImages.Length)
            {
                itemsInStore[i].isAvailable = true;
                itemImages[i].sprite = itemsInStore[i].icon;
                itemNameText[i].text = itemsInStore[i].itemName;
                itemPriceText[i].text = "Price: " + itemsInStore[i].buyPrice;
                itemDescription[i].text = itemsInStore[i].description;
            }
        }
    }
    public void BuyItem(int index)
    {
        if (index >= 0 && index < itemsInStore.Length)
        {
            ItemBase itemToBuy = itemsInStore[index];

            if (itemToBuy != null && itemToBuy.isAvailable)
            {
                GameController.Instance.PurchaseItem(itemToBuy);
            }
        }
    }
    public void UpdateStoreUI()
    {
        for (int i = 0; i < itemsInStore.Length; i++)
        {
            if (itemsInStore[i].isAvailable)
            {
                itemImages[i].color = new Color(1,1,1); 
            }
            else
            {
                itemImages[i].color = new Color(0.5f, 0.5f, 0.5f); // Color oscuro
            }
        }
    }

}
