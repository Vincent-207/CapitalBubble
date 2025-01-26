using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameOverShow : MonoBehaviour
{
    [SerializeField]
    TMP_Text scoreText, swizzleText, meatText, steelText, coinText, finalScoreText;
    float firstScore, swizzleCorrupt, meatCorrupt, steelCorrupt, coinCorrupt, finalScore;
    // Start is called before the first frame update
    void Start()
    {
        firstScore = PlayerData.instance.baseScore;
        swizzleCorrupt = PlayerData.instance.swizzleCorruptValue;
        steelCorrupt = PlayerData.instance.steelCorruptValue;
        meatCorrupt = PlayerData.instance.meatCorruptValue;
        coinCorrupt = PlayerData.instance.coinCorruptValue;
        finalScore = firstScore + swizzleCorrupt + steelCorrupt + meatCorrupt + coinCorrupt;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE: " + firstScore;
        swizzleText.text = "x " +swizzleCorrupt + " Cities affected";
        meatText.text = "x " + meatCorrupt + " Orphans Employed";
        steelText.text = "x " + steelCorrupt + " tanks built";
        coinText.text = "+ " + coinCorrupt + " people rug pulled";
        finalScoreText.text = "FINAL SCORE: " + finalScore;
    }
}
