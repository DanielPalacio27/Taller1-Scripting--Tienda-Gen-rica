using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class inventoryController : MonoBehaviour {

    [SerializeField] GameObject consItemButton, nonConsItemButt, consumContainer, nonConsumContainer;
    [SerializeField] GameObject inputDiscard;
    [SerializeField] Text equipped;
    //NonConsumable nonCons;

    public static event Action<string> OnDiscardItem;

    private void OnEnable()
    {
        Inventory.Instance.ListItems();


        foreach (Transform child in consumContainer.transform)
            Destroy(child.gameObject);
        foreach (Transform child in nonConsumContainer.transform)
            Destroy(child.gameObject);


        foreach (Consumable c in Inventory.Instance.mConsumables)
        {
            foreach (Consumable p in c.propProducts)
            {
                if (p.Amount > 0)
                {
                    GameObject consumButt = Instantiate(consItemButton) as GameObject;
                    consumButt.transform.SetParent(consumContainer.transform, false);

                    Slider amount = consumButt.transform.GetChild(4).GetComponent<Slider>();
                    amount.maxValue = p.Amount;

                    consumButt.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => ConsumItem(c, p, consumButt, amount));
                    consumButt.transform.GetChild(2).GetComponent<Text>().text = p.Name;
                    consumButt.transform.GetChild(3).GetComponent<Text>().text = p.Amount.ToString();
                    consumButt.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() => discardItem(c, p, consumButt, amount));

                    
                }
            }

        }

        foreach (NonConsumable n in Inventory.Instance.mNonConsumables)
        {
            foreach (NonConsumable p in n.propProducts)
            {
                GameObject nonConsumButt = Instantiate(nonConsItemButt) as GameObject;
                nonConsumButt.transform.SetParent(nonConsumContainer.transform, false);
                nonConsumButt.transform.GetChild(1).GetComponent<Text>().text = p.Name;
                nonConsumButt.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => equipItem(p, nonConsumButt));
            }
        }      
    }    

    public void equipItem(NonConsumable _nonCons, GameObject butt)
    {
        AudioClipController.Instance.audioSource.clip = AudioClipController.Instance.consumeButton;
        AudioClipController.Instance.audioSource.Play();

        Inventory.Instance.nonConsEquipped = _nonCons;
        GameObject text = butt.transform.GetChild(2).gameObject;
        equipped.transform.position = text.transform.position;      
    }

    public void discardItem(Consumable _item, Consumable _product, GameObject butt, Slider amount)
    {
        AudioClipController.Instance.audioSource.clip = AudioClipController.Instance.consumeButton;
        AudioClipController.Instance.audioSource.Play();

        int indexItem, indexProduct;
        //Slider amount = butt.transform.GetChild(4).GetComponent<Slider>();
        amount.maxValue = _product.Amount;
        _product.Amount -= Mathf.RoundToInt(amount.value);
        
        indexItem = Inventory.Instance.myItems.IndexOf(_item);

        indexProduct = Inventory.Instance.myItems[indexItem].propProducts.IndexOf(_product);
        Inventory.Instance.myItems[indexItem].propProducts[indexProduct] = _product;
        butt.transform.GetChild(3).gameObject.GetComponent<Text>().text = _product.Amount.ToString();

        OnDiscardItem("Discarded " + Mathf.RoundToInt(amount.value) + " items, press any key to continue ");

        if (_product.Amount <= 0)
        {
            //Inventory.Instance.myItems[indexItem].propProducts.Remove(_product);
            _item.Amount = 0;
            Destroy(butt);
        }
        
        Inventory.Instance.myItems[indexItem] = _item;
        //OnEnable();
    }

    public void ConsumItem(Consumable _item,Consumable _product, GameObject _consButt, Slider amount)
    {
        AudioClipController.Instance.audioSource.clip = AudioClipController.Instance.consumeButton;
        AudioClipController.Instance.audioSource.Play();
        //Debug.Log(Inventory.Instance.mConsumables.Count);
        int indexItem, indexProduct;
        //Slider amount = _consButt.transform.GetChild(4).GetComponent<Slider>();
        _product.Amount -= Mathf.RoundToInt(amount.value);

        indexItem = Inventory.Instance.myItems.IndexOf(_item);

        indexProduct = Inventory.Instance.myItems[indexItem].propProducts.IndexOf(_product);
        Inventory.Instance.myItems[indexItem].propProducts[indexProduct] = _product;
        _consButt.transform.GetChild(3).gameObject.GetComponent<Text>().text = _product.Amount.ToString();

        if (_product.Amount <= 0)
        {
            //Inventory.Instance.myItems[indexItem].propProducts.Remove(_product);
            _item.Amount = 0;
            Destroy(_consButt);
        }

        Inventory.Instance.myItems[indexItem] = _item;
        //OnEnable();

    }
}



        


    
