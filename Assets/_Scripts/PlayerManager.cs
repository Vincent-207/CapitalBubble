using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text cashText, capitalText;
    public StockManager stockLogic;
    public float cash;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        capitalText.text = "Capital: " + stockLogic.getSumStockValue().ToString("#.##");
        cashText.text = "Cash: " + cash.ToString("#.##");
    }

    public bool canBuy(float cost)
    {
        if(cash < cost)
        {
            return false;
        }
        else{
            return true;
        }
    }
}
