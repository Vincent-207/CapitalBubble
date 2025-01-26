using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MarketTimer : MonoBehaviour
{
    public PlayerData playerDAT;
    public float timerDuration;
    public float currentTimerDuration;
    private TMP_Text timerTextObject;
    private string timerText;
    // Start is called before the first frame update
    void Start()
    {
        timerTextObject = transform.GetChild(0).GetComponent<TMP_Text>();
        currentTimerDuration = timerDuration;
    }

    // Update is called once per frame
    void Update()
    {
        currentTimerDuration -= Time.deltaTime;
        timerTextObject.text = currentTimerDuration.ToString("#.##"); // returns ".5" when decimalVar == 0.5m
        if(currentTimerDuration <= 0)
        {
            Debug.LogWarning("TRADE PERIOD END");
            playerDAT.getData();
            SceneManager.LoadScene(2);
            //Debug.Break();
        }
    }
}
