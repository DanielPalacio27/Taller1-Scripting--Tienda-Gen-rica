using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class ShopController {

    public GameObject consAmount;
    public ShopController(ref GameObject _consAmount)
    {
        consAmount = _consAmount;
        ShopUI.OnPurchase += EventPurchase;
    }

    public void EventPurchase(object sender, PurchaseEventArgs purchaseEventArgs)
    {
        GameController.Instance.purchasePopUpMessage.gameObject.SetActive(true);

        if(Singleton.Instance.mCurrencies[(int)purchaseEventArgs.currency] >= purchaseEventArgs.item.Curren[purchaseEventArgs.currency])
            GameController.Instance.StartCoroutine(GameController.Instance.MessageBox("Succesful purchase, press any key to continue"));
        else
            GameController.Instance.StartCoroutine(GameController.Instance.MessageBox("U dont have enough money, press any key to continue"));

        #region  switch
        /*
        switch (purchaseEventArgs.currency)
        {
            case (CurrencyTypes.Currency1):
             
                if (Singleton.Instance.mCurrencies[0] >= purchaseEventArgs.item.Curren[purchaseEventArgs.currency])
                    GameController.Instance.StartCoroutine(GameController.Instance.MessageBox("Succesful purchase"));
                else
                    GameController.Instance.StartCoroutine(GameController.Instance.MessageBox("U dont have enough money"));

                break;

            case (CurrencyTypes.Currency2):

                if (Singleton.Instance.mCurrencies[1] >= purchaseEventArgs.item.Curren[purchaseEventArgs.currency])
                    GameController.Instance.StartCoroutine(GameController.Instance.MessageBox("Succesful purchase"));
                else
                    GameController.Instance.StartCoroutine(GameController.Instance.MessageBox("U dont have enough money"));

                break;

            case (CurrencyTypes.Currency3):

                if (Singleton.Instance.mCurrencies[2] >= purchaseEventArgs.item.Curren[purchaseEventArgs.currency])
                    GameController.Instance.StartCoroutine(GameController.Instance.MessageBox("Succesful purchase"));
                else
                    GameController.Instance.StartCoroutine(GameController.Instance.MessageBox("U dont have enough money"));

                break;
        }
        */
        #endregion

    }

    public void BuyItem(CurrencyTypes _currencyTypes, Item _item, GameObject butt)
    {
        //Button consumButt = butt.transform.GetChild(4).GetComponent<Button>();

        ItemDataBase itemDB = new ItemDataBase();

        int indexProduct = 0;
        List<Item> auxProducts = new List<Item>();
        

        if (Singleton.Instance.mCurrencies[(int)_currencyTypes] >= _item.Curren[_currencyTypes])
        {
            //butt.transform.GetChild(4).gameObject.SetActive(true);

            AudioClipController.Instance.audioSource.clip = AudioClipController.Instance.audioBuyButton;
            AudioClipController.Instance.audioSource.Play();

            if (_item is Consumable)
            {
                Singleton.Instance.mCurrencies[(int)_currencyTypes] -= _item.Curren[_currencyTypes];
                Consumable item = _item as Consumable;
                int index;

                if (item.propProducts.Count <= 0)
                {
                    item.Amount--;
                    Inventory.Instance.myItems.Remove(item);
                }
                
                if (Inventory.Instance.myItems.Contains(item))
                {
                    item.Amount++;


                    foreach (Consumable p in item.propProducts)
                    {
                        p.Amount += p.auxAmount;
                    }

                    index = Inventory.Instance.myItems.IndexOf(item);
                    Inventory.Instance.myItems[index] = item;                
                }
                else
                {

                    foreach (Item i in itemDB.itemList)
                    {
                        if (i.Name == _item.Name)
                        {
                            indexProduct = itemDB.itemList.IndexOf(i);
                            auxProducts = itemDB.itemList[indexProduct].propProducts;
                            _item.propProducts = auxProducts;
                        }
                    }
                    item.Amount++;

                    Inventory.Instance.myItems.Add(item);

                    #region Consumir desde la tienda

                    //consumButt.onClick.RemoveAllListeners();
                    /*
                    consumButt.onClick.AddListener(delegate
                    {
                        List<Item> cons = new List<Item>();

                        foreach (Consumable f in item.propProducts)
                        {
                            f.Amount--;

                            if (f.Amount <= 0)
                            {
                                cons.Remove(f);
                            }
                            else
                            {
                                cons.Add(f);
                            }

                        }

                        item.propProducts = cons;
                        index = Inventory.Instance.myItems.IndexOf(item);

                        if (item.propProducts.Count <= 0)
                        {
                            Inventory.Instance.myItems.Remove(item);
                        }
                        else
                        {
                            Inventory.Instance.myItems[index] = item;
                        }


                        /*
                        index = Inventory.Instance.myItems.IndexOf(item);


                        if (item.Amount > 0 && item.Amount <= 5)
                        {
                            item.Amount--;
                            Inventory.Instance.myItems[index] = item;
                            butt.transform.GetChild(5).gameObject.GetComponent<Text>().text = item.Amount.ToString();
                        }                    
                        else if (item.Amount > 5)
                        {
                            consAmount.SetActive(true);
                            float cantidad = 0;

                            consAmount.GetComponent<InputField>().onEndEdit.AddListener(delegate(string amount) {
                                cantidad = float.Parse(amount);
                                Debug.Log(cantidad.ToString());
                                item.Amount -= cantidad;
                                butt.transform.GetChild(5).gameObject.GetComponent<Text>().text = item.Amount.ToString();
                                consAmount.SetActive(false);

                            });

                        }

                        if (item.Amount < 1)
                        {
                            item.Amount--;
                            Inventory.Instance.myItems.Remove(item);
                            butt.transform.GetChild(5).gameObject.GetComponent<Text>().text = " ";
                            consumButt.gameObject.SetActive(false);
                        }
                        
                    });*/
                    #endregion
                }
            }
            else
            {
                butt.transform.GetChild(1).gameObject.SetActive(false);
                NonConsumable item = _item as NonConsumable;
                
                if (!(item.IsPurchased))
                {
                    Singleton.Instance.mCurrencies[(int)_currencyTypes] -= _item.Curren[_currencyTypes];
                    butt.transform.GetChild(5).gameObject.SetActive(true);
                    butt.transform.GetChild(5).gameObject.GetComponent<Text>().text = "Purchased";

                    if (Inventory.Instance.myItems.Contains(item))
                        return;
                    else
                    {
                        /*
                        consumButt.onClick.AddListener(delegate
                        {
                            //item.InInventory = true;
                            //butt.transform.GetChild(5).gameObject.GetComponent<Text>().text = "Equipped";
                        });
                        */
                        item.IsPurchased = true;
                        Inventory.Instance.myItems.Add(item);
                    }
                }
            }
            GameController.Instance.UpdateUI();
        }
    }
}
            
            

  


