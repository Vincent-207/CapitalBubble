using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSaver : MonoBehaviour
{
    float highScore;
    float localHighScore;
    [SerializeField]
    GameOverShow gmShow;
    [SerializeField]
    TMP_Text isHighScoreText, HighScoreText;

    string highScoreKey = "HighScore";
    // Start is called before the first frame update
    void Start()
    {
        localHighScore = gmShow.getFinalScore();
        isHighScoreText.enabled = false;
        if(PlayerPrefs.HasKey(highScoreKey))
        {
            float savedHighScore =  PlayerPrefs.GetFloat(highScoreKey);
            if(savedHighScore < localHighScore)
            {
                Debug.Log("New High Score!");
                PlayerPrefs.SetFloat(highScoreKey, localHighScore);
                isHighScoreText.enabled = true;
                HighScoreText.text = "HIGH SCORE: " + localHighScore;
            }
            else{
                HighScoreText.text = "HIGH SCORE: " + savedHighScore;
            }
        }
        else{
            PlayerPrefs.SetFloat(highScoreKey, localHighScore);
            Debug.Log("New high score!");
        }
    }

}
