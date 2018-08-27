using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Item
{
    private int id;
    private string name;
    private string description;
    //private Currencies currencies;
    //private List<string> products;
    private List<Item> products;


    private Dictionary<CurrencyTypes, int> curren = new Dictionary<CurrencyTypes, int>();

    public abstract int propId { get; set; }
    public abstract string propName { get; set; }
    public abstract string propDescription { get; set; }
    //public abstract Currencies propCurrencies { get; set; }
    //public abstract List<string> propProducts { get; set; }
    public abstract List<Item> propProducts { get; set; }

    public int Id { get { return id; } set { id = value; } }
    public string Name { get { return name; } set { name = value; } }
    public string Description { get { return description; } set { description = value; } }
    public List<Item> Products { get { return products; } set { products = value; } }

    /*
    public Currencies Currencies
    {
        get
        {
            return currencies;
        }
        set
        {
            currencies = value;
        }
    }
    */

    //public List<string> Products { get { return products; } set { products = value; } }


    public Dictionary<CurrencyTypes, int> Curren
    {
        get
        {
            return curren;
        }

        set
        {
            curren = value;
        }
    }

    protected Item(int _id, string _name, string _description, Dictionary<CurrencyTypes, int> _curren, List<Item> _products)
    {
        Id = _id;
        Name = _name;
        Description = _description;
        Curren = _curren;
        Products = _products;
    }

    protected Item(string _name, string _description)
    {
        Name = _name;
        Description = _description;
    }

}
