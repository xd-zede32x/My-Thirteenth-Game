using UnityEngine;
using UnityEngine.UI;

public class PickaxeButtonUI : MonoBehaviour
{
    [SerializeField] private Text _nameProductText;
    [SerializeField] private Text _coinBonusText;
    [SerializeField] private Text _priceProductText;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _button;

    public PickaxeButtonData Data => _data;

    private PickaxeButtonUIConfig _config;
    private PickaxeButtonData _data;

    public void Initialize(PickaxeButtonUIConfig config, ShopView shop)
    {
        _config = config;

        if (PlayerPrefs.HasKey(config.Name))
            _data = JsonUtility.FromJson<PickaxeButtonData>(PlayerPrefs.GetString(_config.Name));

        else
            _data = new PickaxeButtonData(config);

        _nameProductText.text = config.Name;
        _priceProductText.text = _data.Price + "$";
        _coinBonusText.text = config.IncreaseClicks + "$";
        _icon.sprite = config.Icon;

        _button.onClick.AddListener(() =>
        {
            bool isBuy = shop.TryBuyPickaxe(_data, config.IncreaseClicks);

            if (isBuy)
            {
                _priceProductText.text = _data.Price + "$";
            }
        });
    }

    public void SaveData()
    {
        PlayerPrefs.SetString(_config.Name, JsonUtility.ToJson(_data));
    }
}