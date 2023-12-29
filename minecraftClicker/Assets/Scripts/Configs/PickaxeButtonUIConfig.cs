using UnityEngine;

[CreateAssetMenu(menuName = "Pickaxe", fileName = "item", order = 51)]
public class PickaxeButtonUIConfig : ButtonUIConfig
{
    [SerializeField] private Sprite _sprite;
    public Sprite Icon => _sprite;
}