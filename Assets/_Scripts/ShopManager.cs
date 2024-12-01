using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public int playerCurrency = 100;
    public List<Item> itemsForSale = new List<Item>();
    public Button potionButton;
    public Button weaponButton;
    public Button defensiveItemButton;
    private PlayerStatsHandler playerStatsHandler;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemsForSale.Add(new Item("Potion", 10));
        itemsForSale.Add(new Item("Weapon", 50));
        itemsForSale.Add(new Item("Defensive Item", 30));

        potionButton.onClick.AddListener(() => PurchaseItem(itemsForSale[0]));
        weaponButton.onClick.AddListener(() => PurchaseItem(itemsForSale[1]));
        defensiveItemButton.onClick.AddListener(() => PurchaseItem(itemsForSale[2]));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PurchaseItem(Item item)
    {
        Debug.Log(playerStatsHandler.totalCoins);
        if (playerCurrency >= item.price)
        {
            playerCurrency -= item.price;
            Debug.Log($"Purchased {item.itemName}");
        }
        else
        {
            Debug.Log("Not enough currency");
        }
    }
}

public class Item
{
    public string itemName;
    public int price;

    public Item(string name, int price)
    {
        this.itemName = name;
        this.price = price;
    }
}
