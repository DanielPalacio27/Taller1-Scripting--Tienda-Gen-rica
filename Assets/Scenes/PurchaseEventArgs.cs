using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PurchaseEventArgs : EventArgs {

    public Item item;
    public CurrencyTypes currency;

    public PurchaseEventArgs(Item _item, CurrencyTypes _currency)
    {
        item = _item;
        currency = _currency;
    }    

}
