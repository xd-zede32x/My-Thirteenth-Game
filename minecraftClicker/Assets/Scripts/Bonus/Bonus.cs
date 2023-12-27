using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Bonus : IsPurchaseSuccessful
{
    [SerializeField] private MainButton _mainButton;
    [SerializeField] private int[] _priceProduct;
    [SerializeField] private int[] _passiveIncome;
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
            {
                _passiveIncome[index] = _saveBonus.PassiveIncome[index];
            }
        }
    }

    private void Start()
    {
        StartCoroutine(BonusAccruals(0));
        StartCoroutine(BonusAccruals(1));
        StartCoroutine(BonusAccruals(2));
        StartCoroutine(BonusAccruals(3));
        StartCoroutine(BonusAccruals(4));
        StartCoroutine(BonusAccruals(5));
        StartCoroutine(BonusAccruals(6));
        StartCoroutine(BonusAccruals(7));
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

    private void BuyBonus(int index, int income, int multiplied = 2)
    {
        if (_mainButton.Score >= _priceProduct[index])
        {
            _mainButton.Score -= _priceProduct[index];
            _priceProduct[index] *= multiplied;
            _passiveIncome[index] += income;
            _priceText[index].text = _priceProduct[index] + "$";

            AudioPlayback(0);
        }

        else
        {
            AudioPlayback(1);
        }
    }

    private IEnumerator BonusAccruals(int index)
    {
        while (true)
        {
            _mainButton.Score += _passiveIncome[index];
            yield return new WaitForSeconds(1.5f);
        }
    }

    private void OnApplicationQuit()
    {
        _saveBonus.PriceProduct = new int[8];
        _saveBonus.PassiveIncome = new int[8];

        for (int index = 0; index < 8; index++)
            _saveBonus.PriceProduct[index] = _priceProduct[index];

        for (int index = 0; index < 8; index++)
            _saveBonus.PassiveIncome[index] = _passiveIncome[index];

        PlayerPrefs.SetString("SaveBonus", JsonUtility.ToJson(_saveBonus));
    }
}