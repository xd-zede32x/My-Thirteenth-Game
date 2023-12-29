using UnityEngine;

[CreateAssetMenu(menuName = "Achievements", fileName = "Item", order = 51)]
public class AchievementsButtonUIConfig : ScriptableObject    
{
    [SerializeField] private int _reward;
    [SerializeField] private int _achievementsClickCount;

    public int Reward => _reward;
    public int AchievementsClickCount => _achievementsClickCount;
}