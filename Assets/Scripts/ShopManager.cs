using UnityEngine;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour
{
    public int playerCurrency = 100;
    public List<Item> itemsForSale = new List<Item>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemsForSale.Add(new Item("Potion", 10));
        itemsForSale.Add(new Item("Weapon", 50));
        itemsForSale.Add(new Item("Defensive Item", 30));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PurchaseItem(Item item)
    {
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
