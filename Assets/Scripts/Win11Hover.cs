using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class Win11Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image highlight;
    public RectTransform icon;

    Coroutine fadeRoutine;
    Coroutine scaleRoutine;

    public void OnPointerEnter(PointerEventData eventData)
    {
        FadeTo(0.28f);
        ScaleTo(1.05f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        FadeTo(0f);
        ScaleTo(1f);
    }

    void FadeTo(float target)
    {
        if (fadeRoutine != null) StopCoroutine(fadeRoutine);
        fadeRoutine = StartCoroutine(Fade(target));
    }

    IEnumerator Fade(float target)
    {
        Color c = highlight.color;

        while (Mathf.Abs(c.a - target) > 0.01f)
        {
            c.a = Mathf.Lerp(c.a, target, Time.deltaTime * 10f);
            highlight.color = c;
            yield return null;
        }
    }

    void ScaleTo(float target)
    {
        if (scaleRoutine != null) StopCoroutine(scaleRoutine);
        scaleRoutine = StartCoroutine(Scale(target));
    }

    IEnumerator Scale(float target)
    {
        Vector3 start = icon.localScale;
        Vector3 end = Vector3.one * target;

        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * 10f;
            icon.localScale = Vector3.Lerp(start, end, t);
            yield return null;
        }
    }
}