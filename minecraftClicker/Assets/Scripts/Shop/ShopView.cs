using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShopView : IsPurchaseSuccessful
{
    [SerializeField] private Text _textScore;
    [SerializeField] private MainButton _mainButton;
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform _gridPanel;
    [SerializeField] private List<PickaxeButtonUIConfig> _configs;

    private List<PickaxeButtonUI> _buttons;

    private void Awake()
    {
        _buttons = new List<PickaxeButtonUI>();

        foreach (var item in _configs)
        {
            GameObject prefab = Instantiate(_template, _gridPanel);
            PickaxeButtonUI pickaxeButton = prefab.GetComponent<PickaxeButtonUI>();
            _buttons.Add(pickaxeButton);

            pickaxeButton.Initialize(item, this);
        }
    }

    private void Update()
    {
        _textScore.text = _mainButton.Score + "$";
    }

    public bool TryBuyPickaxe(PickaxeButtonData data, int increaseClicks, int productMultiplications = 2)
    {
        if (_mainButton.Score >= data.Price)
        {
            _mainButton.Score -= data.Price;
            data.Price *= productMultiplications;
            _mainButton.ClickScore += increaseClicks;

            AudioPlayback(0);
            return true;
        }

        else
        {
            AudioPlayback(1);
            return false;
        }
    }

    private void OnApplicationQuit()
    {
        foreach (var item in _buttons)
        {
            item.SaveData();
        }
    }
}