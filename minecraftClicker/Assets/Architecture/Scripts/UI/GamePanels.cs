using UnityEngine;

public class GamePanels : MonoBehaviour
{
    private const string App_SHOP_Panel = "AppShop";
    private const string HIDE_SHOP_Panel = "HideShop";

    private const string App_Bonus_Panel = "AppBonus";
    private const string HIDE_Bonus_Panel = "HideBonus";

    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private GameObject _bonusPanel;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OpenShopPanel()
    {
        IsOpen(_shopPanel, true, App_SHOP_Panel);
    }

    public void OpenBonusPanel()
    {
        IsOpen(_bonusPanel, true, App_Bonus_Panel);
    }

    public void HideShopPanel()
    {
        IsOpen(_shopPanel, false, HIDE_SHOP_Panel);
    }

    public void HideBonusPanel()
    {
        IsOpen(_bonusPanel, false, HIDE_Bonus_Panel);
    }

    private void IsOpen(GameObject button, bool isOpen, string animation)
    {
        _animator.SetTrigger(animation);
        button.SetActive(isOpen);
    }
}