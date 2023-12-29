using UnityEngine;
using UnityEngine.UI;

public class AchievementsButtonUI : MonoBehaviour
{
    [SerializeField] private Text _textAchievementName;
    [SerializeField] private Text _reward;
    [SerializeField] private Button _button;
    [SerializeField] private Text _completeText;

    private MainButton _mainButton;
    private bool _isComplected = false;
    private AchievementsButtonUIConfig _config;

    private void Update()
    {
        if (_config == null || _mainButton == null)     
            return;

        _textAchievementName.text = $"Click {Mathf.Clamp(_mainButton.ClickCount, 0, _config.AchievementsClickCount)}/{_config.AchievementsClickCount} once";
    }

    public void AddListenerButtonClicked(ViewAchievements view)
    {
        _button.onClick.AddListener(() =>
        {
            bool isBuy = view.TryGetRewarded(_config.AchievementsClickCount, _config.Reward);

            if (isBuy)
            {
                _isComplected = true;
                _completeText.text = "Complete";
                _reward.text = "Made";
                ButtonRemoveAllListener();
            }
        });
    }

    public void Initialize(AchievementsButtonUIConfig config, ViewAchievements view, MainButton mainButton)
    {
        _config = config;
        _mainButton = mainButton;

        Load();

        SetButtonParametrons();

        if (_isComplected == false)
        {
            AddListenerButtonClicked(view);
        }
    }

    public void SetButtonParametrons()
    {
        if (_isComplected)
        {
            _reward.text = "Made";
            _completeText.text = "Complete";
            _button.interactable = false;
        }

        else
        {
            _reward.text = _config.Reward + "$";
        }
    }

    public void Save()
    {
        PlayerPrefs.SetInt($"AchievementsClickCount {_config.AchievementsClickCount}", _isComplected ? 1 : 0);
    }

    public void Load()
    {
        int complected = PlayerPrefs.GetInt($"AchievementsClickCount {_config.AchievementsClickCount}", 0);
        _isComplected = complected == 1 ? true : false;
    }

    private void OnDestroy()
    {
        ButtonRemoveAllListener();
    }

    private void ButtonRemoveAllListener()
    {
        _button.onClick.RemoveAllListeners();
    }
}