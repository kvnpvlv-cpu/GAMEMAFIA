using UnityEngine;
using System.Collections;

public class WindowAnimator : MonoBehaviour
{
    [Header("UI Elements")]
    public CanvasGroup canvasGroup;
    public GameObject darkBackground;

    [Header("Animation Settings")]
    public float fadeDuration = 0.3f;
    public float moveDistance = 200f; // насколько окно выезжает
    public float bounceStrength = 20f; // сила подпрыгивания

    private RectTransform rectTransform;
    private Vector2 originalPosition;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;

        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    public void OpenWindow()
    {
        gameObject.SetActive(true);
        darkBackground.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(FadeInAndBounce());
    }

    public void CloseWindow()
    {
        StopAllCoroutines();
        StartCoroutine(FadeOutAndMove());
    }

    IEnumerator FadeInAndBounce()
    {
        float t = 0;
        Vector2 startPos = originalPosition - new Vector2(0, moveDistance);
        Vector2 endPos = originalPosition;

        rectTransform.anchoredPosition = startPos;
        canvasGroup.alpha = 0;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float normalized = Mathf.Clamp01(t / fadeDuration);

            canvasGroup.alpha = Mathf.Lerp(0, 1, normalized);
            rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, Mathf.SmoothStep(0, 1, normalized));
            yield return null;
        }

        // Подпрыгивание
        float bounceTime = 0.15f;
        float elapsed = 0;
        while (elapsed < bounceTime)
        {
            elapsed += Time.deltaTime;
            float yOffset = Mathf.Sin(elapsed / bounceTime * Mathf.PI) * bounceStrength;
            rectTransform.anchoredPosition = endPos + new Vector2(0, yOffset);
            yield return null;
        }

        rectTransform.anchoredPosition = endPos;
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    IEnumerator FadeOutAndMove()
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        float t = 0;
        Vector2 startPos = rectTransform.anchoredPosition;
        Vector2 endPos = originalPosition - new Vector2(0, moveDistance);

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float normalized = Mathf.Clamp01(t / fadeDuration);

            canvasGroup.alpha = Mathf.Lerp(1, 0, normalized);
            rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, Mathf.SmoothStep(0, 1, normalized));
            yield return null;
        }

        canvasGroup.alpha = 0;
        rectTransform.anchoredPosition = originalPosition;
        gameObject.SetActive(false);
        darkBackground.SetActive(false);
    }
}
