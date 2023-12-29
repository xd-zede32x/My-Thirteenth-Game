using UnityEngine;
using System.Collections.Generic;

public class BonusView : View
{
    [SerializeField] private List<BonusButtonUIConfig> _configs;

    private void Awake()
    {
        foreach (var item in _configs)
        {
            GameObject prefab = Instantiate(Template, GridPanel);
            BonusButtonUI pickaxeButton = prefab.GetComponent<BonusButtonUI>();
            Button.Add(pickaxeButton);
            pickaxeButton.Initialize(item, this);
        }
    }

    public override bool TryBuy(ButtonData data, int bonus, int productMultiplications = 2)
    {
        if (MainButton.Score >= data.Price)
        {
            MainButton.Score -= data.Price;
            data.Price *= productMultiplications;
            MainButton.BonusScore += bonus;

            AudioPlayback(0);
            return true;
        }

        else
        {
            AudioPlayback(1);
            return false;
        }
    }
}