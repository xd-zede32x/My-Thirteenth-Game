using UnityEngine;

[CreateAssetMenu(menuName = "Background", fileName = "Item", order = 51)]
public class BackgroundButtonUIConfig : ScriptableObject
{
    [SerializeField] private Sprite _backgroundImage;
    [SerializeField] private string _countText;

    public Sprite Background => _backgroundImage;
    public string CountText => _countText;
}