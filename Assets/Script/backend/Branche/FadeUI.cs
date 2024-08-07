using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class FadeUI : MonoBehaviour
{
    public TextMeshProUGUI uiText;
    public Image uiImage;
    public float fadeDuration = 1.0f;

    private void Start()
    {
        SetUIVisibility(0);
    }

    public void ShowAndFadeOutUI()
    {
        StartCoroutine(FadeInAndOut());
    }

    private IEnumerator FadeInAndOut()
    {
        yield return StartCoroutine(FadeIn());
        yield return new WaitForSeconds(1.0f); // Attente avant de commencer à disparaître
        yield return StartCoroutine(FadeOut());
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            SetUIVisibility(Mathf.Clamp01(elapsedTime / fadeDuration));
            yield return null;
        }
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            SetUIVisibility(Mathf.Clamp01(1 - (elapsedTime / fadeDuration)));
            yield return null;
        }
    }

    private void SetUIVisibility(float alpha)
    {
        if (uiText != null)
        {
            Color textColor = uiText.color;
            textColor.a = alpha;
            uiText.color = textColor;
        }

        if (uiImage != null)
        {
            Color imageColor = uiImage.color;
            imageColor.a = alpha;
            uiImage.color = imageColor;
        }
    }
}
