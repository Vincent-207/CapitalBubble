using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenPreset : MonoBehaviour
{
    [SerializeField]
    float endScaleScalar;
    Vector3 startScale;
    Vector3 endScale;
    void Start()
    {
        startScale = transform.localScale;
        endScale = new Vector3(endScaleScalar, endScaleScalar, endScaleScalar);
    } 
    public void hoverTween()
    {
        LeanTween.cancel(this.gameObject);
        LeanTween.scale(this.gameObject, endScale, 2f).setEaseOutElastic();
    }

    public void exitTween()
    {
        LeanTween.cancel(this.gameObject);
        LeanTween.scale(this.gameObject, startScale, 2f).setEaseOutElastic();
    }

    private void cancelPreviousTweens()
    {
        LeanTween.cancel(this.gameObject);
    }

}
