using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item
{
    private float amount;
    private float maxAmount;

    public float auxAmount;
    public float Amount
    {
        get
        {
            return Mathf.Clamp(amount, 0, maxAmount);
        }

        set
        {
            amount = value;
        }
    }

    public override int propId { get; set; }
    public override string propName { get; set; }
    public override string propDescription { get; set; }
    public override List<Item> propProducts { get; set; }
    /*
    public override Currencies propCurrencies
    {
        get
        {
            return Currencies;
        }
        set
        {
            //Currencies.Currency1 *= 0.5f;
            Currencies = value;
        }
    }
    */

    //public override List<string> propProducts { get; set; }

    

    public Consumable(int _id, string _name, string _description, Dictionary<CurrencyTypes, int> _curren , List<Item> _products) : base(_id, _name, _description, _curren, _products)
    {
        propId = _id;
        propName = _name;
        propDescription = _description;
        //propCurrencies = _currencies;
        Curren = _curren;
   
        propProducts = _products;
        Amount = 0;
        maxAmount = 50f;
    }

    public Consumable(string _name, string _description, float _amount) : base(_name, _description)
    {
        propName = _name;
        propDescription = _description;
        auxAmount = _amount;
        Amount = _amount;
        maxAmount = 100f;
        
    }

}
