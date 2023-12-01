using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private int _money = 0;

    private RectTransform _rectTransform;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnButtonClick()
    {
        _money++;
        _text.text = _money.ToString();
    }

    public void ButtonDown()
    {
        _rectTransform.transform.localScale = new Vector2(3.5f, 3.5f);
    }

    public void ButtonUp()
    {
        _rectTransform.transform.localScale = new Vector2(3, 3);
    }
}