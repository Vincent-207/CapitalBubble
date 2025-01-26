using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance;
    [SerializeField]
    PlayerManager playerMG;
    public  float baseScore;
    public  float swizzleCorruptValue;
    public  float meatCorruptValue;
    public  float steelCorruptValue;
    public  float coinCorruptValue;
    public Stock meatStock;
    public Stock swizzleStock;
    public Stock SteelStock;
    public Stock coinStock;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void getData()
    {
        baseScore = playerMG.cash;
        swizzleCorruptValue = swizzleStock.bubbledAmount;
        meatCorruptValue = meatStock.bubbledAmount;
        steelCorruptValue = SteelStock.bubbledAmount;
        coinCorruptValue = coinStock.bubbledAmount;
        Debug.Log("Saving swizzle: " + swizzleStock.bubbledAmount);
    }
}
