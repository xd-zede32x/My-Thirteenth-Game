using System;
using UnityEngine;

[Serializable]
public class ButtonData
{
    [SerializeField] private int _price;

    public int Price
    {
        get { return _price; }

        set
        {
            if (value < 0)
                throw new Exception("Price no valid");

            _price = value;
        }
    }

    public ButtonData(ButtonUIConfig config)
    {
        _price = config.Price;
    }
}