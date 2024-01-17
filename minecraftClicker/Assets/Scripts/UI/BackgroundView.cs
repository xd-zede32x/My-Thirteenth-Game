using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BackgroundView : MonoBehaviour
{
    [SerializeField] private Transform _gridPanel;
    [SerializeField] private GameObject _template;
    [SerializeField] private Image _defaultBackground;
    [SerializeField] private List<BackgroundButtonUIConfig> _configs;

    private List<BackgroundButtonUI> _buttons = new List<BackgroundButtonUI>();

    private void Awake()
    {
        foreach (var config in _configs)
        {
            GameObject prefab = Instantiate(_template, _gridPanel);
            BackgroundButtonUI backgroundButton = prefab.GetComponent<BackgroundButtonUI>();
            _buttons.Add(backgroundButton);
            backgroundButton.Initialize(config, this);
        }
    }

    public void SetBackground(Sprite sprite)
    {
        if (sprite == null)
            return;

        _defaultBackground.sprite = sprite;
    }
}