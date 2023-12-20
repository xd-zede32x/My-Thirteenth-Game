using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Text[] _priceText;
    [SerializeField] private double[] _priceProduct;
    [SerializeField] private AudioClip[] _audioClips;

    private AudioSource _audioSource;
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

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void OnClickByWoodenPickaxe()
    {
        IsBuyWooden(0, 1.1, 2);
    }

    public void OnClickByWoodenStone()
    {
        IsBuyWooden(1, 1.2, 3);
    }

    public void OnClickByWoodenIron()
    {
        IsBuyWooden(2, 1.5, 4);
    }

    public void OnClickByWoodenGolden()
    {
        IsBuyWooden(3, 2, 5);
    }

    public void OnClickByWoodenDiamond()
    {
        IsBuyWooden(4, 2.3, 6);
    }

    public void OnClickByWoodenEtherate()
    {
        IsBuyWooden(5, 2.6, 7);
    }

    public void OnClickByWoodenMagical()
    {
        IsBuyWooden(6, 3, 8);
    }

    public void OnClickByWoodenUndead()
    {
        IsBuyWooden(7, 3.5, 9);
    }

    public void OnClickByWoodenSpace()
    {
        IsBuyWooden(8, 4, 10);
    }

    public void OnClickByWoodenEndless()
    {
        IsBuyWooden(9, 5, 11);
    }

    private void IsBuyWooden(int index, double increaseClicks, double productMultiplications)
    {
        if (_button.Score >= _priceProduct[index])
        {
            _button.Score -= _priceProduct[index];
            _priceProduct[index] *= productMultiplications;
            _button.ClickScore *= increaseClicks;
            _priceText[index].text = _priceProduct[index] + "$";
            AudioPlayback(0);
        }

        else
            AudioPlayback(1);
    }

    private void AudioPlayback(int index)
    {
        _audioSource.PlayOneShot(_audioClips[index]);
    }

    private void OnApplicationQuit()
    {
        _saveShop.PriceProduct = new double[10];

        for (int index = 0; index < 10; index++)
            _saveShop.PriceProduct[index] = _priceProduct[index];

        PlayerPrefs.SetString("SaveShop", JsonUtility.ToJson(_saveShop));
    }
}