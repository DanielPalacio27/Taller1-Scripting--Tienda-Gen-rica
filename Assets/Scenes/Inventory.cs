using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Inventory {

    private static Inventory instance = null;
    public static Inventory Instance
    {
        get
        {
            if (instance == null)
                instance = new Inventory();
            return instance;
        }
    }
    
    public List<Item> myItems = new List<Item>();
    public List<Consumable> mConsumables;
    public List<NonConsumable> mNonConsumables;
    public NonConsumable nonConsEquipped;

    public void ListItems()
    {
        foreach (Item i in myItems)
        {
            if (i is Consumable)
            {
                Consumable c = i as Consumable;
                if (!mConsumables.Contains(i as Consumable))
                {
                    mConsumables.Add(i as Consumable);
                }
            }
            else if (i is NonConsumable)
            {
                if (!mNonConsumables.Contains(i as NonConsumable))
                {
                    mNonConsumables.Add(i as NonConsumable);
                }
            }
        }
    }

    public Inventory()
    {
        mConsumables = new List<Consumable>();
        mNonConsumables = new List<NonConsumable>();
    }

}
