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
    [SerializeField] private Text[] _achievementsText;
    [SerializeField] private Text[] _achievementsConst;
    [SerializeField] private Text _achievementsClicksCount;

    private int _clickScore = 1;
    private AudioSource _audioSources;
    private SaveGame _saveGame = new SaveGame();

    [SerializeField] private int _achievementsMax;
    private bool _isAchievements = true;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("SaveGame"))
        {
            _saveGame = JsonUtility.FromJson<SaveGame>(PlayerPrefs.GetString("SaveGame"));
            _score = _saveGame.Score;
            _clickScore = _saveGame.ClickScore;
            _achievementsMax = _saveGame.AchievementMax;
            _isAchievements = _saveGame.IsAchievement;

            for (int index = 0; index < 1; index++)
            {
                _constBonus[index] = _saveGame.ConstBonus[index];
            }

            for (int index = 0; index < 2; index++)
            {
                _priceProduct[index] = _saveGame.PriceProduct[index];
                _priceText[index].text = _saveGame.PriceProduct[index] + "$";
            }
        }
    }

    private void Start()
    {
        _audioSources = GetComponent<AudioSource>();
        StartCoroutine(Bonus());
    }

    private void Update()
    {
        _scoreText.text = _score + "$";
        _achievementsClicksCount.text = "Click " + _achievementsMax + " /100 once";

        if (_isAchievements == false)
        {
            _achievementsConst[0].text = "Received";
        }

        if (_achievementsMax == 100)
        {
            _achievementsText[0].text = "Complete";
        }
    }

    public void OnClickButton()
    {
        _score += _clickScore;

        if (_isAchievements == true && _achievementsMax <= 100)
        {
            _achievementsMax++;
        }
    }

    public void OnClickByLevel()
    {
        if (_score >= _priceProduct[0])
        {
            _score -= _priceProduct[0];
            _priceProduct[0] *= 2;
            _clickScore *= 2;
            _priceText[0].text = _priceProduct[0] + "$";
            AudioPlayback(0);
        }

        else
        {
            AudioPlayback(1);
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
            AudioPlayback(0);
        }

        else
        {
            AudioPlayback(1);
        }
    }

    public void OnClickAchievementsButton()
    {
        if (_isAchievements == true && _achievementsMax == 100)
        {
            _score += 200;          
            _isAchievements = false;
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

    private void AudioPlayback(int index)
    {
        _audioSources.PlayOneShot(_audioClips[index]);
    }

    private void OnApplicationQuit()
    {
        _saveGame.Score = _score;
        _saveGame.ClickScore = _clickScore;
        _saveGame.ConstBonus = new int[1];
        _saveGame.PriceProduct = new int[2];
        _saveGame.IsAchievement = _isAchievements;
        _saveGame.AchievementMax = _achievementsMax;

        for (int bonus = 0; bonus < 1; bonus++)
            _saveGame.ConstBonus[bonus] = _constBonus[bonus];


        for (int product = 0; product < 2; product++)
            _saveGame.PriceProduct[product] = _priceProduct[product];


        PlayerPrefs.SetString("SaveGame", JsonUtility.ToJson(_saveGame));
    }
}