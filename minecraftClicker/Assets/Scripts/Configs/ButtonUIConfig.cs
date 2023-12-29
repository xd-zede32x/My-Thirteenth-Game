using UnityEngine;

public abstract class ButtonUIConfig : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _price;
    [SerializeField] private int _bonus;

    public string Name => _name;
    public int Price => _price;
    public int Bonus => _bonus;
}