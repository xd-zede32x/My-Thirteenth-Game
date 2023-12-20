using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour
{
    [SerializeField] private double _score = 0;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text[] _priceText;
    [SerializeField] private int[] _constBonus;
    [SerializeField] private int[] _priceProduct;
    [SerializeField] private Text[] _achievementsText;
    [SerializeField] private Text[] _achievementsConst;
    [SerializeField] private Text _achievementsClicksCount;
    [SerializeField] private int _achievementsMax;

    public double Score
    {
        get
        {
            return _score;
        }

        set
        {
            _score = value;
        }
    }
    public double ClickScore
    {
        get
        {
            return _clickScore;
        }

        set
        {
            _clickScore = value;
        }
    }

    private double _clickScore = 1;
    private Save _save = new Save();
    private bool _isAchievements = true;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Save"))
        {
            _save = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("Save"));

            _score = _save.Score;
            _clickScore = _save.ClickScore;
            _achievementsMax = _save.AchievementMax;
            _isAchievements = _save.IsAchievement;

            for (int index = 0; index < 1; index++)
                _constBonus[index] = _save.ConstBonus[index];
        }
    }

    private void Start()
    {
        StartCoroutine(Bonus());
    }

    private void Update()
    {
        _scoreText.text = _score + "$";
        _achievementsClicksCount.text = "Click " + _achievementsMax + " /100 once";

        if (_isAchievements == false)
            _achievementsConst[0].text = "Received";

        if (_achievementsMax == 100)
            _achievementsText[0].text = "Complete";
    }

    public void OnClickButton()
    {
        _score += _clickScore;

        if (_isAchievements == true && _achievementsMax <= 100)
            _achievementsMax++;
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

    private void OnApplicationQuit()
    {
        _save.Score = _score;
        _save.ClickScore = _clickScore;
        _save.ConstBonus = new int[1];
        _save.IsAchievement = _isAchievements;
        _save.AchievementMax = _achievementsMax;

        for (int bonus = 0; bonus < 1; bonus++)
            _save.ConstBonus[bonus] = _constBonus[bonus];

        PlayerPrefs.SetString("Save", JsonUtility.ToJson(_save));
    }
}