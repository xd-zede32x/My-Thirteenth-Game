using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Bonus : IsPurchaseSuccessful
{
    [SerializeField] private MainButton _mainButton;
    [SerializeField] private int[] _priceProduct;
    [SerializeField] private int[] _constBonus;
    [SerializeField] private Text[] _priceText;

    private SaveBonus _saveBonus = new SaveBonus();

    private void Awake()
    {
        if (PlayerPrefs.HasKey("SaveBonus"))
        {
            _saveBonus = JsonUtility.FromJson<SaveBonus>(PlayerPrefs.GetString("SaveBonus"));

            for (int index = 0; index < 8; index++)
            {
                _priceProduct[index] = _saveBonus.PriceProduct[index];
                _priceText[index].text = _saveBonus.PriceProduct[index] + "$";
            }

            for (int index = 0; index < 8; index++)
                _constBonus[index] = _saveBonus.ConstBonus[index];
        }
    }

    private void Start()
    {
        StartCoroutine(BonusAccruals(0));
    }

    public void BonusPlaceTrade()
    {
        BuyBonus(0, 2);
    }

    public void BonusMobFarm()
    {
        BuyBonus(1, 3);
    }

    public void BonusPaddock()
    {
        BuyBonus(2, 4);
    }

    public void BonusVillage()
    {
        BuyBonus(3, 5);
    }

    public void BonusCastle()
    {
        BuyBonus(4, 6);
    }

    public void BonusHell()
    {
        BuyBonus(5, 7);
    }

    public void BonusBastion()
    {
        BuyBonus(6, 8);
    }

    public void BonusEnd()
    {
        BuyBonus(7, 10);
    }

    private void BuyBonus(int index, int accruals, int multiplied = 2)
    {
        if (_mainButton.Score >= _priceProduct[index])
        {
            _mainButton.Score -= _priceProduct[index];
            _priceProduct[index] *= multiplied;
            _constBonus[index] += accruals;
            _priceText[index].text = _priceProduct[index] + "$";

            AudioPlayback(0);
        }

        else
            AudioPlayback(1);
    }

    private IEnumerator BonusAccruals(int index)
    {
        while (true)
        {
            _mainButton.Score += _constBonus[index];
            yield return new WaitForSeconds(2);
        }
    }

    private void OnApplicationQuit()
    {
        _saveBonus.PriceProduct = new int[8];
        _saveBonus.ConstBonus = new int[8];

        for (int index = 0; index < 8; index++)
            _saveBonus.PriceProduct[index] = _priceProduct[index];

        for (int index = 0; index < 8; index++)
            _saveBonus.ConstBonus[index] = _constBonus[index];

        PlayerPrefs.SetString("SaveBonus", JsonUtility.ToJson(_saveBonus));
    }
}