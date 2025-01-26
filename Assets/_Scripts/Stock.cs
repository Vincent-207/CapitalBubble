using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stock : MonoBehaviour
{
    //public GameObject playerPiggy;
    public string stockName;
    public float value;
    public float bubbledAmount;
    public int amount; 
    private float totalBoughtPrice;
    private float corruptPrice = 10;
    private float currentRelativeValue;
    public PlayerManager playerMG;
    public string[] corruptionText;
    TMP_Text priceText, QuantityText, NewsText, corruptButtonText;
    [SerializeField]
    AudioSource failedSound, clickSound;
    int newsTextIndex = 0;

    // private Company owner
    void Start()
    {
        corruptButtonText = transform.GetChild(0).GetComponentInChildren<TMP_Text>();
        priceText = transform.GetChild(3).GetComponentInChildren<TMP_Text>();
        NewsText = transform.GetChild(transform.childCount - 1).GetComponentInChildren<TMP_Text>();
        QuantityText = transform.GetChild(4).GetComponentInChildren<TMP_Text>();

    }

    void Update()
    {
        priceText.text = "PRICE: " + value.ToString("#.##");
        NewsText.text = corruptionText[newsTextIndex];
        corruptButtonText.text = "CORRUPT: " + corruptPrice.ToString("#.##");
        QuantityText.text = "# " + amount;
    }
    public void tick()
    {
        float randomValue = Random.Range(1, 10);
        value += (randomValue * (bubbledAmount - 1)) + randomValue/3;
    }
    public void Corrupt()
    {
        if(playerMG.canBuy(corruptPrice))
        {
            playerMG.cash -= corruptPrice;
            bubbledAmount *= 7.5f;
            corruptPrice *= 10.0f;
            if(newsTextIndex < corruptionText.Length - 1)
            {
                newsTextIndex++;
            }
            clickSound.Play();
        }
        else
        {
            Debug.LogWarning("Can't Afford");
            failedSound.Play();
        }

    }
    

    public float getBubbleMultiplier()
    {
        return bubbledAmount;
    }
    public void Sell(int sellAmount)
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            Debug.Log("Selling Full!");
            sellAmount = amount;

        }
        if(amount < sellAmount)
        {
            Debug.Log("Can't sell");
            failedSound.Play();
            return;
        }
        clickSound.Play();
        amount -= sellAmount;
        float revenue = value * sellAmount;
        playerMG.cash += revenue;
        totalBoughtPrice -= revenue;
        Debug.Log("SOLD!");
        return;
    }

    public void Buy()
    {
        float buyValue = value;
        int buyQuantity = 1;
        if(Input.GetKey(KeyCode.LeftShift))
        {
            int maxBuyQuantity = (int) Mathf.Round(playerMG.cash) / (int) Mathf.Round(value);
            if(maxBuyQuantity <= 0)
            {
                failedSound.Play();
                return;
            }
            buyQuantity = maxBuyQuantity;
        }
        if(playerMG.canBuy(value * buyQuantity))
        {
            Debug.Log("Buying");
            playerMG.cash -= value * buyQuantity;
            amount += buyQuantity;
            clickSound.Play();
            return;
        }
        else{
            Debug.LogWarning("Can't buy");
            Debug.Log("Value: " + value);
            Debug.Log("Quantity: " + buyQuantity);
            Debug.Log("Combined: " + value * buyQuantity);
            failedSound.Play();
            return;
        }
        
    }

   
}
