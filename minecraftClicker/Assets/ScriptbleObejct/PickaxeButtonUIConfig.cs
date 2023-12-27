using UnityEngine;

[CreateAssetMenu(menuName = "Pickaxe", fileName = "item", order = 51)]
public class PickaxeButtonUIConfig : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _price;
    [SerializeField] private int _increaseClicks;
    [SerializeField] private Sprite _icon;

    public string Name => _name;
    public int Price => _price;
    public Sprite Icon => _icon;
    public int IncreaseClicks => _increaseClicks;
}