using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;



public class ShopUI : MonoBehaviour
{
    public delegate void PurchaseHandler(object sender, PurchaseEventArgs purchaseEvent);
    public static event PurchaseHandler OnPurchase;


    [SerializeField] GameObject itemContainer;
    [SerializeField] GameObject itemButton;
    [SerializeField] public GameObject consumeAmount;

    public static ItemDataBase itemDataBase;

    public void Start()
    {
        ShopController shopController = new ShopController(ref consumeAmount);
        ItemDataBase itemDataBase = new ItemDataBase();
        GameController.Instance.UpdateUI();

        foreach (Item c in itemDataBase.itemList)
        {
            GameObject consumItemButt = Instantiate(itemButton) as GameObject;
            consumItemButt.transform.GetChild(0).GetComponent<Text>().text = c.propName;
            consumItemButt.transform.GetChild(2).GetComponent<Text>().text = c.propDescription;
            int i = 0;

            foreach (CurrencyTypes curr in c.Curren.Keys)
            {
                consumItemButt.transform.GetChild(1).transform.GetChild(i).gameObject.SetActive(true);
                consumItemButt.transform.GetChild(1).transform.GetChild(i).GetComponentInChildren<Text>().text = c.Curren[curr].ToString();
                consumItemButt.transform.GetChild(1).transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = curr.ToString();

                consumItemButt.transform.GetChild(1).transform.GetChild(i).GetComponent<Button>().onClick.AddListener(delegate
                {
                    PurchaseEventArgs eventArgs = new PurchaseEventArgs(c, curr);
                    OnPurchase(this, eventArgs);
                    shopController.BuyItem(curr, c, consumItemButt);
                });
                i++;
            }

            foreach (Item p in c.propProducts)
            {
                if (p is Consumable)
                {
                    Consumable cons = p as Consumable;
                    consumItemButt.transform.GetChild(3).GetComponent<Text>().text += "\n " + cons.Name + ", amount:  " + cons.Amount;
                }
                else
                    consumItemButt.transform.GetChild(3).GetComponent<Text>().text += "\n " + p.Name;
            }

            consumItemButt.transform.SetParent(itemContainer.transform, false);
        }
    }

    /*
    public void OnEnable()
    {
        ShopController shopController = new ShopController(ref consumeAmount);
        ItemDataBase itemDataBase = new ItemDataBase();

        foreach (Item c in itemDataBase.itemList)
        {
            GameObject consumItemButt = Instantiate(itemButton) as GameObject;
            consumItemButt.transform.GetChild(0).GetComponent<Text>().text = c.propName;
            consumItemButt.transform.GetChild(2).GetComponent<Text>().text = c.propDescription;
            int i = 0;

            foreach (CurrencyTypes curr in c.Curren.Keys)
            {
                consumItemButt.transform.GetChild(1).transform.GetChild(i).gameObject.SetActive(true);
                consumItemButt.transform.GetChild(1).transform.GetChild(i).GetComponentInChildren<Text>().text = c.Curren[curr].ToString();
                consumItemButt.transform.GetChild(1).transform.GetChild(i).GetComponent<Button>().onClick.AddListener(delegate
                {
                    PurchaseEventArgs eventArgs = new PurchaseEventArgs(c, curr);
                    OnPurchase(this, eventArgs);
                    shopController.BuyItem(curr, c, consumItemButt);
                });
                i++;
            }

            foreach (Item p in c.propProducts)
            {
                if (p is Consumable)
                {
                    Consumable cons = p as Consumable;
                    consumItemButt.transform.GetChild(3).GetComponent<Text>().text += "\n " + cons.Name + ", amount:  " + cons.Amount;
                }
                else
                    consumItemButt.transform.GetChild(3).GetComponent<Text>().text += "\n " + p.Name;
            }

            consumItemButt.transform.SetParent(itemContainer.transform, false);
        }
    }
    */
}
    
    
