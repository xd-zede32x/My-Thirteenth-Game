using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public abstract class View : IsPurchaseSuccessful
{
    [SerializeField] private MainButton _mainButton;
    [SerializeField] private Text _textScore;
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform _gridPanel;

    public List<ButtonUI> Button => _buttons;
    public GameObject Template => _template;
    public Transform GridPanel => _gridPanel;

    protected MainButton MainButton => _mainButton;
    private List<ButtonUI> _buttons = new List<ButtonUI>();

    private void Update()
    {
        _textScore.text = _mainButton.Score + "$";
    }

    public abstract bool TryBuy(ButtonData data, int increaseClicks, int productMultiplications = 2);
   
    private void OnApplicationQuit()
    {
        foreach (var item in _buttons)
        {
            item.SaveData();
        }
    }
}