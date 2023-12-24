using UnityEngine;
using UnityEngine.UI;

public class MainButton : MonoBehaviour
{
    [SerializeField] private int _score = 0;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text[] _achievementsText;
    [SerializeField] private Text[] _achievementsConst;
    [SerializeField] private Text _achievementsClicksCount;

    public int Score
    {
        get { return _score; }
        set { _score = value; }
    }
    public int ClickScore
    {
        get { return _clickScore; }
        set { _clickScore = value; }
    }

    private int _clickScore = 1;
    private int _achievementsMax;
    private bool _isAchievements = true;
    private Save _save = new Save();

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Save"))
        {
            _save = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("Save"));

            _score = _save.Score;
            _clickScore = _save.ClickScore;
            _achievementsMax = _save.AchievementMax;
            _isAchievements = _save.IsAchievement;
        }
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

    public void OnClickAchievementsButton()
    {
        if (_isAchievements == true && _achievementsMax >= 100)
        {
            _score += 200;
            _isAchievements = false;
        }
    }

    private void OnApplicationQuit()
    {
        _save.Score = _score;
        _save.ClickScore = _clickScore;
        _save.IsAchievement = _isAchievements;
        _save.AchievementMax = _achievementsMax;

        PlayerPrefs.SetString("Save", JsonUtility.ToJson(_save));
    }
}