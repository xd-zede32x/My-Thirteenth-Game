using UnityEngine;

public class ButtonClicks : MonoBehaviour
{
    private RectTransform _rectTransform;
    private float _speedRotateButton = 5f;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        ButtonRotate(_speedRotateButton);
    }

    public void ButtonDown()
    {
        _rectTransform.transform.localScale = new Vector2(3.2f, 3.2f);
    }

    public void ButtonUp()
    {
        _rectTransform.transform.localScale = new Vector2(2.8f, 2.8f);
    }

    private void ButtonRotate(float speedRotate)
    {
        _rectTransform.Rotate(0, 0, 1 * speedRotate);
    }
}