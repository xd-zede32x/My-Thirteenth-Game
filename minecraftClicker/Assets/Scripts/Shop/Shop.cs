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

            for (int index = 0; index < 5; index++)
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
        IsBuyWooden(0, 1.5, 2);
    }

    public void OnClickByWoodenStone()
    {
        IsBuyWooden(1, 2, 3);
    }

    public void OnClickByWoodenIron()
    {
        IsBuyWooden(2, 3, 4);
    }

    public void OnClickByWoodenGolden()
    {
        IsBuyWooden(3, 4, 5);
    }

    public void OnClickByWoodenDiamond()
    {
        IsBuyWooden(4, 5, 6);
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
        _saveShop.PriceProduct = new double[5];

        for (int index = 0; index < 5; index++)
            _saveShop.PriceProduct[index] = _priceProduct[index];

        PlayerPrefs.SetString("SaveShop", JsonUtility.ToJson(_saveShop));
    }
}