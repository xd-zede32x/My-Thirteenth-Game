using UnityEngine;
using UnityEngine.UI;

public class BackgroundButtonUI : MonoBehaviour
{
    [SerializeField] Text _countText;
    [SerializeField] private Image _background;
    [SerializeField] private Button _button;
    [SerializeField] private Image _checkMark;

    private BackgroundButtonUIConfig _config;

    public void Initialize(BackgroundButtonUIConfig config, BackgroundView view)
    {
        SetConfig(config);
        SetButtonParametrons();

        AddListenerButtonClicked(view);
    }

    private void SetConfig(BackgroundButtonUIConfig config)
    {
        _config = config;
    }

    private void SetButtonParametrons()
    {
        _background.sprite = _config.Background;
        _countText.text = _config.CountText;
    }

    private void AddListenerButtonClicked(BackgroundView view)
    {
        _button.onClick.AddListener(() =>
        {
            view.DefaultBackground.sprite = _background.sprite;
        });
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
    }
}