using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonUI : MonoBehaviour
{
    [SerializeField] private Text _nameProductText;
    [SerializeField] private Text _coinBonusText;
    [SerializeField] private Text _priceProductText;
    [SerializeField] private Button _button;

    protected Text CoinBonusText => _coinBonusText;
    public ButtonData Data => _data;
    protected ButtonData _data;

    private ButtonUIConfig _buttonConfig;

    protected virtual void SetButtonParametrons()
    {
        _nameProductText.text = _buttonConfig.Name;
        _priceProductText.text = _data.Price + "$";
        _coinBonusText.text = _buttonConfig.Bonus + "$";
    }

    protected ButtonData GetButtonData()
    {
        if (PlayerPrefs.HasKey(_buttonConfig.Name))
            return JsonUtility.FromJson<ButtonData>(PlayerPrefs.GetString(_buttonConfig.Name));

        else
            return new ButtonData(_buttonConfig);
    }

    public void SaveData()
    {
        PlayerPrefs.SetString(_buttonConfig.Name, JsonUtility.ToJson(_data));
    }

    protected void AddListenerButtonClicked(View view)
    {
        _button.onClick.AddListener(() =>
        {
            bool isBuy = view.TryBuy(_data, _buttonConfig.Bonus);   

            if (isBuy)
            {
                _priceProductText.text = _data.Price + "$";
            }
        });
    }

    protected void SetConfig(ButtonUIConfig config)
    {
        _buttonConfig = config;
    }
}