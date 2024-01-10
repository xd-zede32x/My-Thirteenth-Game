using UnityEngine;
using UnityEngine.UI;

public class ButtonClicks : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private RectTransform _rectTransform;

    private float _speedRotateButton = 3f;

    private void Update()
    {
        _rectTransform.Rotate(0, 0, 1 * _speedRotateButton);
    }

    public void ButtonDown()
    {
        _rectTransform.transform.localScale = new Vector2(3f, 3f);
    }

    public void ButtonUp()
    {
        _image.sprite = _sprites[Random.Range(0, _sprites.Length)];
        _rectTransform.transform.localScale = new Vector2(2.5f, 2.5f);
    }
}