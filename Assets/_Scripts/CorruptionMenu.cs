using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CorruptionMenu : MonoBehaviour
{
    public Stock currentStock;
    [SerializeField]
    Stock[] stocks;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openCorruption(int selectedStockIndex)
    {
        currentStock = stocks[selectedStockIndex];
    }

    public void messageTest()
    {
        
    }
}
