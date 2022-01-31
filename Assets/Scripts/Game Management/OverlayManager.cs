using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayManager : Singleton<OverlayManager>
{
    public SpriteRenderer leftOverlay;
    public SpriteRenderer rightOverlay;

    private new void Awake()
    {
        base.Awake();

        Color temp = leftOverlay.color;
        temp.a = 0;
        leftOverlay.color = temp;

        temp = rightOverlay.color;
        temp.a = 0;
        rightOverlay.color = temp;
    }


    #region Fade Coroutines
    public IEnumerator FadeInLeftOverlay(float duration)
    {
        Color color = leftOverlay.color;
        float startAlpha = color.a;
        float time = 0;

        while (time < duration)
        {
            color.a = Mathf.Lerp(startAlpha, 1, time / duration);
            leftOverlay.color = color;
            time += Time.deltaTime;
            yield return null;
        }
        color.a = 1;
        leftOverlay.color = color;
    }

    public IEnumerator FadeOutLeftOverlay(float duration)
    {
        Color color = leftOverlay.color;
        float startAlpha = color.a;
        float time = 0;

        while (time < duration)
        {
            color.a = Mathf.Lerp(startAlpha, 0, time / duration);
            leftOverlay.color = color;
            time += Time.deltaTime;
            yield return null;
        }
        color.a = 0;
        leftOverlay.color = color;
    }

    public IEnumerator FadeInRightOverlay(float duration)
    {
        Color color = rightOverlay.color;
        float startAlpha = color.a;
        float time = 0;

        while (time < duration)
        {
            color.a = Mathf.Lerp(startAlpha, 1, time / duration);
            rightOverlay.color = color;
            time += Time.deltaTime;
            yield return null;
        }
        color.a = 1;
        rightOverlay.color = color;
    }

    public IEnumerator FadeOutRightOverlay(float duration)
    {
        Color color = rightOverlay.color;
        float startAlpha = color.a;
        float time = 0;

        while (time < duration)
        {
            color.a = Mathf.Lerp(startAlpha, 0, time / duration);
            rightOverlay.color = color;
            time += Time.deltaTime;
            yield return null;
        }
        color.a = 0;
        rightOverlay.color = color;
    }

    #endregion
}
