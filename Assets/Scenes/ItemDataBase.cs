using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemDataBase
{
    public List<Item> itemList;

    public ItemDataBase()
    {
        itemList = new List<Item>();
        AddNewItem(true, 0101, "consumable1", "Es el consumable1", new Dictionary<CurrencyTypes, int>() { {CurrencyTypes.Currency1 , 20 }, {CurrencyTypes.Currency2, 200} } , new List<Item> {new Consumable("ProductP" , "P", 2), new Consumable ("ProductK", "K", 3) });
        AddNewItem(true, 0101, "consumable2", "Es el consumable1", new Dictionary<CurrencyTypes, int>() { { CurrencyTypes.Currency1, 100 }, { CurrencyTypes.Currency3, 200 } }, new List<Item> { new Consumable("ProductN", "N", 1), new Consumable("ProductP", "P", 1) });
        AddNewItem(true, 0104, "consumable3", "Es el consumable1", new Dictionary<CurrencyTypes, int>() { { CurrencyTypes.Currency2, 2000 }, { CurrencyTypes.Currency3, 200 } }, new List<Item> { new Consumable("ProductA", "A", 4) } );
        AddNewItem(true, 0102, "consumable4", "Es el consumable1", new Dictionary<CurrencyTypes, int>() { { CurrencyTypes.Currency1, 2000 }, { CurrencyTypes.Currency2, 200 } , {CurrencyTypes.Currency3, 500 } }, new List<Item> {new Consumable("ProductH", "H", 5), new Consumable("ProductY", "Y", 7) });
        AddNewItem(false, 0201, "nonconsumable1", "Es el nonconsumable1", new Dictionary<CurrencyTypes, int>() { { CurrencyTypes.Currency1, 2000 }, { CurrencyTypes.Currency2, 200 } }, new List<Item> { new NonConsumable("ProductQ", "Q"), new NonConsumable("ProductD", "D") });
        AddNewItem(false, 0202, "nonconsumable1", "Es el nonconsumable2", new Dictionary<CurrencyTypes, int>() { { CurrencyTypes.Currency1, 2000 }, { CurrencyTypes.Currency2, 100 } }, new List<Item> { new NonConsumable("ProductY", "Y") });
    }

    public void AddNewItem(bool isConsumable, int id, string name, string description, Dictionary<CurrencyTypes, int> curren, List<Item> productList)
    {
        switch (isConsumable)
        {
            case true:
                itemList.Add(new Consumable(id, name, description, curren, productList));
                break;

            case false:
                itemList.Add(new NonConsumable(id, name, description, curren, productList));
                break;

            default:
                break;
        }
    }

}
