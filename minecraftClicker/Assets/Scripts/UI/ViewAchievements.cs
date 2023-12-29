using UnityEngine;
using System.Collections.Generic;

public class ViewAchievements : MonoBehaviour
{
    [SerializeField] private MainButton _mainButton;
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform _gridPanel;
    [SerializeField] private List<AchievementsButtonUIConfig> _configs;

    private List<AchievementsButtonUI> _buttons = new List<AchievementsButtonUI>();

    private void Awake()
    {
        foreach (var item in _configs)
        {
            GameObject prefab = Instantiate(_template, _gridPanel);
            AchievementsButtonUI button = prefab.GetComponent<AchievementsButtonUI>();
            _buttons.Add(button);
            button.Initialize(item, this, _mainButton);
        }
    }

    public bool TryGetRewarded(int clickCount, int reward)
    {
        if (_mainButton.ClickCount >= clickCount)
        {
            _mainButton.Score += reward;
            return true;
        }

        return false;
    }
       
    private void OnApplicationQuit()
    {
        foreach (var item in _buttons)
        {
            item.Save();
        }
    }
}