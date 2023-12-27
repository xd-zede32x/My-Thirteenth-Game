using UnityEngine;
using System.Collections;

public class AnimationPanels : MonoBehaviour
{
    [SerializeField, Range(0.1f, 0.4f)] private float _animationDuration;
    [SerializeField] private GameObject _panel;
    [SerializeField] private CanvasGroup _canvasGroup;

    public void IsOpen()
    {
        _panel.SetActive(true);
        StartCoroutine(OpenPanel());
    }

    public void IsHide() => StartCoroutine(HidePanel());

    private IEnumerator OpenPanel()
    {
        float time = 0f;

        while (time < _animationDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, time / _animationDuration);
            _canvasGroup.alpha = alpha;

            yield return null;
        }
    }

    private IEnumerator HidePanel()
    {
        float time = 0f;

        while (time < _animationDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, time / _animationDuration);
            _canvasGroup.alpha = alpha;

            yield return null;
        }

        _panel.SetActive(false);
    }
}