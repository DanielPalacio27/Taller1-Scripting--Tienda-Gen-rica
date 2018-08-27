using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [SerializeField] GameObject shop, inventory, inventController;
    private static GameController instance = null;
    public static GameController Instance
    {
        get
        {
            return instance;
        }
    }
    public GameObject lockCanvas;
    public Text currency1, currency2, currency3;
    public Text purchasePopUpMessage;

    [SerializeField] int gCurrency1;
    [SerializeField] int gCurrency2;
    [SerializeField] int gCurrency3;


    private void Awake()
    {
        Singleton.Instance.mCurrencies[0] = gCurrency1;
        Singleton.Instance.mCurrencies[1] = gCurrency2;
        Singleton.Instance.mCurrencies[2] = gCurrency3;


        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        inventoryController.OnDiscardItem += discardedItem;

        UpdateUI();
    }

    public void discardedItem(string n)
    {
        StartCoroutine(MessageBox(n));
    }
    public void UpdateUI()
    {
        currency1.text = Singleton.Instance.mCurrencies[0].ToString();
        currency2.text = Singleton.Instance.mCurrencies[1].ToString();
        currency3.text = Singleton.Instance.mCurrencies[2].ToString();
    }
    void Update () {

        if (Input.GetKeyDown(KeyCode.S))
        {
            shop.SetActive(true);
            inventory.SetActive(false);

            AudioClipController.Instance.audioSource.clip = AudioClipController.Instance.changeWindow;
            AudioClipController.Instance.audioSource.Play();
        }
        
        if (shop.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                inventory.SetActive(true);
                shop.SetActive(false);

                AudioClipController.Instance.audioSource.clip = AudioClipController.Instance.changeWindow;
                AudioClipController.Instance.audioSource.Play();
            }
        }
        
	}

    public IEnumerator MessageBox(string message)
    {
        lockCanvas.gameObject.SetActive(true);
        purchasePopUpMessage.gameObject.SetActive(true);
        purchasePopUpMessage.text = message;


        while (!(Input.anyKey))
            yield return null;

        if (Input.anyKey)
        { 
            lockCanvas.gameObject.SetActive(false);
            purchasePopUpMessage.gameObject.SetActive(false);
        }
    }
}
