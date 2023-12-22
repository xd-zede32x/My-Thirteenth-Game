using UnityEngine;
using UnityEngine.UI;

public class ButtonClicks : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;

    private Image _image;
    private RectTransform _rectTransform;
    private float _speedRotateButton = 3f;

    private void Start()
    {
        _image = GetComponent<Image>();
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        ButtonRotate(_speedRotateButton);
    }

    public void ButtonDown()
    {
        _rectTransform.transform.localScale = new Vector2(3.5f, 3.5f);
    }

    public void ButtonUp()
    {
        _image.sprite = _sprites[Random.Range(0, _sprites.Length)];
        _rectTransform.transform.localScale = new Vector2(3, 3f);
    }

    private void ButtonRotate(float speedRotate)
    {
        _rectTransform.Rotate(0, 0, 1 * speedRotate);
    }
}