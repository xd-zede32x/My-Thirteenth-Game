using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainButton : MonoBehaviour
{
    [SerializeField] private int _score = 0;
    [SerializeField] private Text _scoreText;

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
    public int BonusScore
    {
        get { return _bonusScore; }
        set { _bonusScore = value; }
    }
    public int ClickCount => _clickCount;

    private int _clickCount;
    private int _clickScore = 1;
    private int _bonusScore = 0;
    private Save _save = new Save();

    private void Awake()
    {   
        if (PlayerPrefs.HasKey("Save"))
        {
            _save = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("Save"));

            _score = _save.Score;
            _clickScore = _save.ClickScore;
            _bonusScore = _save.BonusScore;
            _clickCount = _save.ClickCount;
        }
    }       

    private void Start()
    {
        StartCoroutine(BonusAccruals());
    }

    private void Update()
    {
        _scoreText.text = _score + "$";
    }

    public void OnClickButton()
    {
        _score += _clickScore;
        _clickCount++;
    }

    private void OnApplicationQuit()
    {
        _save.Score = _score;
        _save.ClickScore = _clickScore;
        _save.BonusScore = _bonusScore;
        _save.ClickCount = _clickCount;

        PlayerPrefs.SetString("Save", JsonUtility.ToJson(_save));
    }

    private IEnumerator BonusAccruals()
    {
        while (true)
        {
            _score += _bonusScore;
            yield return new WaitForSeconds(1.5f);
        }
    }
}