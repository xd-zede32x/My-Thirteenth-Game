using UnityEngine;

[CreateAssetMenu(menuName = "Bonus", fileName = "Item", order = 51)]
public class BonusButtonUIConfig : ButtonUIConfig
{
    [SerializeField] private Color _colorTextBonus;
    public Color Color => _colorTextBonus;
}