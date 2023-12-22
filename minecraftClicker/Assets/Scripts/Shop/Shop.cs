using UnityEngine;
using UnityEngine.UI;

public class Shop : IsPurchaseSuccessful
{
    [SerializeField] private MainButton _mainButton;
    [SerializeField] private int[] _priceProduct;
    [SerializeField] private Text[] _priceText;

    private SaveShop _saveShop = new SaveShop();

    private void Awake()
    {
        if (PlayerPrefs.HasKey("SaveShop"))
        {
            _saveShop = JsonUtility.FromJson<SaveShop>(PlayerPrefs.GetString("SaveShop"));

            for (int index = 0; index < 10; index++)
            {
                _priceProduct[index] = _saveShop.PriceProduct[index];
                _priceText[index].text = _saveShop.PriceProduct[index] + "$";
            }
        }
    }

    public void OnClickByPickaxeWooden()
    {
        BuyPickaxe(0, 1);
    }

    public void OnClickByPickaxeStone()
    {
        BuyPickaxe(1, 2);
    }

    public void OnClickByPickaxeIron()
    {
        BuyPickaxe(2, 3);
    }

    public void OnClickByPickaxeGolden()
    {
        BuyPickaxe(3, 4);
    }

    public void OnClickByPickaxeDiamond()
    {
        BuyPickaxe(4, 5);
    }

    public void OnClickByPickaxeEtherate()
    {
        BuyPickaxe(5, 6);
    }

    public void OnClickByPickaxeMagical()
    {
        BuyPickaxe(6, 7);
    }

    public void OnClickByPickaxeUndead()
    {
        BuyPickaxe(7, 8);
    }

    public void OnClickByPickaxeSpace()
    {
        BuyPickaxe(8, 9);
    }

    public void OnClickByPickaxeEndless()
    {
        BuyPickaxe(9, 10);
    }

    private void BuyPickaxe(int index, int increaseClicks, int productMultiplications = 2)
    {
        if (_mainButton.Score >= _priceProduct[index])
        {
            _mainButton.Score -= _priceProduct[index];
            _priceProduct[index] *= productMultiplications;
            _mainButton.ClickScore += increaseClicks;
            _priceText[index].text = _priceProduct[index] + "$";

            AudioPlayback(0);
        }

        else
            AudioPlayback(1);
    }

    private void OnApplicationQuit()
    {
        _saveShop.PriceProduct = new int[10];

        for (int index = 0; index < 10; index++)
            _saveShop.PriceProduct[index] = _priceProduct[index];

        PlayerPrefs.SetString("SaveShop", JsonUtility.ToJson(_saveShop));
    }
}