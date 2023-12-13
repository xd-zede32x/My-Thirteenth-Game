using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour
{
    [SerializeField] private int _score = 0;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text[] _priceText;
    [SerializeField] private int[] _constBonus;
    [SerializeField] private int[] _priceProduct;
    [SerializeField] private AudioClip[] _audioClips;

    private int _clickScore = 1;
    private AudioSource _audioSources;
    private float _speedRotateButton = 5f;
    private RectTransform _rectTransform;
    private Save _save = new Save();

    private void Awake()
    {
        if (PlayerPrefs.HasKey("SaveGame"))
        {
            _save = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("SaveGame"));
            _score = _save.Score;
            _clickScore = _save.ClickScore;

            for (int index = 0; index < 1; index++)
            {
                _constBonus[index] = _save.ConstBonus[index];
            }

            for (int index = 0; index < 2; index++)
            {
                _priceProduct[index] = _save.PriceProduct[index];
                _priceText[index].text = _save.PriceProduct[index] + "$";

            }
        }
    }

    private void Start()
    {
        _audioSources = GetComponent<AudioSource>();
        _rectTransform = GetComponent<RectTransform>();
        StartCoroutine(Bonus());
    }

    private void Update()
    {
        _scoreText.text = _score + "$";
        _rectTransform.Rotate(0, 0, 1 * _speedRotateButton);
    }

    public void OnClickButton()
    {
        _score += _clickScore;
    }

    public void OnClickByLevel()
    {
        if (_score >= _priceProduct[0])
        {
            _score -= _priceProduct[0];
            _priceProduct[0] *= 2;
            _clickScore *= 2;
            _priceText[0].text = _priceProduct[0] + "$";
            _audioSources.PlayOneShot(_audioClips[0]);
        }

        else
        {
            _audioSources.PlayOneShot(_audioClips[1]);
        }
    }

    public void OnClickBuyBonus()
    {
        if (_score >= _priceProduct[1])
        {
            _score -= _priceProduct[1];
            _priceProduct[1] *= 2;
            _constBonus[0] += 2;
            _priceText[1].text = _priceProduct[1] + "$";
        }
    }

    private IEnumerator Bonus()
    {
        while (true)
        {
            _score += _constBonus[0];
            yield return new WaitForSeconds(2);
        }
    }

    private void OnApplicationQuit()
    {
        _save.Score = _score;
        _save.ClickScore = _clickScore;
        _save.ConstBonus = new int[1];
        _save.PriceProduct = new int[2];

        for (int bonus = 0; bonus < 1; bonus++)
            _save.ConstBonus[bonus] = _constBonus[bonus];


        for (int product = 0; product < 2; product++)
            _save.PriceProduct[product] = _priceProduct[product];


        PlayerPrefs.SetString("SaveGame", JsonUtility.ToJson(_save));
    }

    public void ButtonDown()
    {
        _rectTransform.transform.localScale = new Vector2(3.2f, 3.2f);
    }

    public void ButtonUp()
    {
        _rectTransform.transform.localScale = new Vector2(2.8f, 2.8f);
    }
}

[System.Serializable]
public class Save
{
    public int Score;
    public int ClickScore;
    public int[] ConstBonus;
    public int[] PriceProduct;
}