public class BonusButtonUI : ButtonUI
{
    public void Initialize(BonusButtonUIConfig config, View shop)
    {
        SetConfig(config);
        _data = GetButtonData();
        SetButtonParametrons(config);

        AddListenerButtonClicked(shop);
    }

    protected void SetButtonParametrons(BonusButtonUIConfig config)
    {
        base.SetButtonParametrons();
        CoinBonusText.color = config.Color;
        CoinBonusText.text = "+" + CoinBonusText.text + "/Seconds";
    }
}