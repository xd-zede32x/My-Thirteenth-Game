using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private bool _isOpening;
    [SerializeField] private AnimationPanels _panel;

    private void Start()
    {
        if (_isOpening)
            _button.onClick.AddListener(() => _panel.IsOpen());

        else
            _button.onClick.AddListener(() => _panel.IsHide());
    }

    private void OnDestroy()    
    {
        if (_isOpening)
            _button.onClick.RemoveListener(() => _panel.IsOpen());

        else
            _button.onClick.RemoveListener(() => _panel.IsHide());
    }
}