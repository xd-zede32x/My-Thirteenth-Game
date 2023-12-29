using UnityEngine;
using System.Collections.Generic;

public class ShopView : View
{
    [SerializeField] private List<PickaxeButtonUIConfig> _configs;

    private void Awake()
    {
        foreach (var item in _configs)
        {
            GameObject prefab = Instantiate(Template, GridPanel);
            PickaxeButtonUI pickaxeButton = prefab.GetComponent<PickaxeButtonUI>();
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
            MainButton.ClickScore += bonus;

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