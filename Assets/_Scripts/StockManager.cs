using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject stockHolder;
    public float tickTimer;
    public float timerDuration;
    Stock[] stocks;
    void Start()
    {
        int stockAmount = stockHolder.transform.childCount;
        Debug.Log("There are " + stockAmount + " stocks.");
        stocks = new Stock[stockAmount];
        for(int childIndex = 0; childIndex < stockAmount; childIndex++)
        {
            stocks[childIndex] = stockHolder.transform.GetChild(childIndex).GetComponent<Stock>();    
        }

        timerDuration = tickTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timerDuration -= Time.deltaTime;
        if(timerDuration <= 0)
        {
            foreach(Stock stock in stocks)
            {
                stock.tick();
            }
            timerDuration = tickTimer;
        }
    }

    public float getSumStockValue()
    {
        float sum = 0;
        foreach(Stock stock in stocks)
        {
            sum += stock.value * stock.amount;
        }

        return sum;
    }
}
