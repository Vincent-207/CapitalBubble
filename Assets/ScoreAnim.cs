using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreAnim : MonoBehaviour
{
    [SerializeField]
    TMP_Text baseScore, score1Show, score2Show, score3Show, score4Show, totalScoreShow;
    bool tweenBase, tweenOne, tweenTwo, tweenThree, tweenFour, tweenTotal;
    [SerializeField]
    float bigScale, backScale;
    Vector3 bigScaleVector, finalScale;
    AudioSource boomSFX;
    // Start is called before the first frame update
    void Start()
    {
        boomSFX = transform.GetComponent<AudioSource>();
        bigScaleVector = new Vector3(bigScale, bigScale, bigScale);
        finalScale = new Vector3(backScale, backScale, backScale);
        baseScore.enabled = true;
        baseScore.transform.localScale = bigScaleVector;
        score1Show.enabled = false;
        score2Show.enabled = false;
        score3Show.enabled = false;
        score4Show.enabled = false; 
        totalScoreShow.enabled = false;
        
        LeanTween.scale(baseScore.gameObject, finalScale, 1f).setEaseInOutElastic().setDelay(Random.Range(0.01f, 0.2f));
        tweenBase = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(tweenBase && LeanTween.isTweening(baseScore.gameObject) == false)
        {
            tweenBase = false;
            score1Show.enabled = true;
            score1Show.transform.localScale = bigScaleVector;
            LeanTween.scale(score1Show.gameObject, finalScale, .5f).setEaseInOutElastic().setDelay(Random.Range(0.01f, 0.2f));
            tweenOne = true; 
            boomSFX.Play();
            return;
        }
        else if(tweenOne && LeanTween.isTweening(score1Show.gameObject) == false)
        {
            tweenOne = false;
            score2Show.enabled = true;
            score2Show.transform.localScale = bigScaleVector;
            LeanTween.scale(score2Show.gameObject, finalScale, .5f).setEaseInOutElastic().setDelay(Random.Range(0.01f, 0.2f));
            tweenTwo = true; 
            boomSFX.Play();
            return;
        }
        else if(tweenTwo && LeanTween.isTweening(score2Show.gameObject) == false)
        {
            tweenTwo = false;
            score3Show.enabled = true;
            score3Show.transform.localScale = bigScaleVector;
            LeanTween.scale(score3Show.gameObject, finalScale, .5f).setEaseInOutElastic().setDelay(Random.Range(0.01f, 0.2f));
            tweenThree = true; 
            boomSFX.Play();
            return;
        }
        else if(tweenThree && LeanTween.isTweening(score3Show.gameObject) == false)
        {
            tweenThree = false;
            score4Show.enabled = true;
            score4Show.transform.localScale = bigScaleVector;
            LeanTween.scale(score4Show.gameObject, finalScale, .5f).setEaseInOutElastic().setDelay(Random.Range(0.01f, 0.2f));
            tweenFour = true; 
            boomSFX.Play();
            return;
        }
        else if(tweenFour && LeanTween.isTweening(score4Show.gameObject) == false)
        {
            tweenFour = false;
            totalScoreShow.enabled = true;
            totalScoreShow.transform.localScale = bigScaleVector;
            LeanTween.scale(totalScoreShow.gameObject, finalScale, 1f).setEaseInOutElastic().setDelay(Random.Range(0.01f, 0.2f));
            boomSFX.Play();
        }
        
    }
}
