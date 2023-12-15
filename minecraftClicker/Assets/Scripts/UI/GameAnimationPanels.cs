using UnityEngine;

public class GameAnimationPanels : MonoBehaviour
{
    private const string App_SHOP_Panel = "AppShop";
    private const string HIDE_SHOP_Panel = "HideShop";

    private const string App_Bonus_Panel = "AppBonus";
    private const string HIDE_Bonus_Panel = "HideBonus";

    private const string App_SETTINGS_Panel = "AppSettings";
    private const string Hide_SETTINGS_Panel = "HideSettings";

    private const string App_ACHIEVEMENTS_Panel = "AppAchievements";
    private const string Hide_ACHIEVEMENTS_Panel = "HideAchievements";

    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private GameObject _bonusPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _achievementsPanel;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OpenShopPanel()
    {
        IsOpen(_shopPanel, App_SHOP_Panel, true);
    }

    public void OpenBonusPanel()
    {
        IsOpen(_bonusPanel, App_Bonus_Panel, true);
    }

    public void HideShopPanel()
    {
        IsOpen(_shopPanel, HIDE_SHOP_Panel, false);
    }

    public void HideBonusPanel()
    {
        IsOpen(_bonusPanel, HIDE_Bonus_Panel, false);
    }

    public void OpenSettingsPanel()
    {
        IsOpen(_settingsPanel, App_SETTINGS_Panel, true);
    }

    public void HideSettingsPanel()
    {
        IsOpen(_settingsPanel, Hide_SETTINGS_Panel, false);
    }

    public void OpenAchievementsPanel()
    {
        IsOpen(_achievementsPanel, App_ACHIEVEMENTS_Panel, true);
    }

    public void HideAchievementsPanel()
    {
        IsOpen(_achievementsPanel, Hide_ACHIEVEMENTS_Panel, false);
    }

    private void IsOpen(GameObject button, string animation, bool isOpen)
    {
        _animator.SetTrigger(animation);
        button.SetActive(isOpen);
    }
}