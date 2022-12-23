using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class BuisinessView : ViewBase
{
    [SerializeField] TextMeshProUGUI _name;
    [SerializeField] TextMeshProUGUI _level;
    [SerializeField] TextMeshProUGUI _income;
    [SerializeField] Slider _incomeProgress;

    [Header("Unique upgrades")]
    [SerializeField] LevelUpButton _lvlUpButton;
    [SerializeField] UniqueUpgradeButton _upgrade1Button;
    [SerializeField] UniqueUpgradeButton _upgrade2Button;
    
    public void SetName(string name)
    {
        _name.text = name;
    }

    public void SetLevel(int lvl)
    {
        _level.text = $"Level\n{lvl}";
    }

    public void SetIncome(float income)
    {
        _income.text = $"Income\n{income}$";
    }

    public void SetLevelUp(float price)
    {
        _lvlUpButton.SetPrice(price);
    }

    public void SetUpgrade1(BuisinessUpgrade upgrade, bool isActive)
    {
        _upgrade1Button.SetName(upgrade.Name);
        _upgrade1Button.SetPrice(upgrade.Price);
        _upgrade1Button.SetIncomeFactor(upgrade.IncomeFactorPercents);
        _upgrade1Button.SetActive(isActive);
    }

    public void SetUpgrade2(BuisinessUpgrade upgrade, bool isActive)
    {
        _upgrade2Button.SetName(upgrade.Name);
        _upgrade2Button.SetPrice(upgrade.Price);
        _upgrade2Button.SetIncomeFactor(upgrade.IncomeFactorPercents);
        _upgrade2Button.SetActive(isActive);
    }

    public void SetIncomeProgress(float value)
    {
        _incomeProgress.value = value;
    }
}
