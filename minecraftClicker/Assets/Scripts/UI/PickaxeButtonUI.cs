using UnityEngine;
using UnityEngine.UI;

public class PickaxeButtonUI : ButtonUI
{
    [SerializeField] private Image _icon;

    public void Initialize(PickaxeButtonUIConfig config, View view)
    {
        SetConfig(config);
        _data = GetButtonData();
        SetButtonParametrons(config);

        AddListenerButtonClicked(view);
    }

    protected void SetButtonParametrons(PickaxeButtonUIConfig config)
    {
        base.SetButtonParametrons();
        _icon.sprite = config.Icon;
    }
}   