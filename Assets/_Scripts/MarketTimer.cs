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
    public float warningScaleScalar, warningTweenTime;
    public Color warningTextColor;
    Vector3 warningScale;
    // Start is called before the first frame update
    void Start()
    {
        timerTextObject = transform.GetChild(0).GetComponent<TMP_Text>();
        currentTimerDuration = timerDuration;
        warningScale = new Vector3(warningScaleScalar, warningScaleScalar, warningScaleScalar);
    }

    // Update is called once per frame
    void Update()
    {
        currentTimerDuration -= Time.deltaTime;
        timerTextObject.text = currentTimerDuration.ToString("#.##"); // returns ".5" when decimalVar == 0.5m
        if(currentTimerDuration <= 10 && transform.localScale != warningScale)
        {
            if(!LeanTween.isTweening(this.gameObject))
            {
                LeanTween.scale(this.gameObject, warningScale, warningTweenTime).setEaseOutElastic();
                timerTextObject.color = warningTextColor;
            }
        }
        if(currentTimerDuration <= 0)
        {
            Debug.LogWarning("TRADE PERIOD END");
            playerDAT.getData();
            SceneManager.LoadScene(2);
            //Debug.Break();
        }
    }
}
