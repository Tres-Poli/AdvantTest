using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BuisinessView))]
[RequireComponent(typeof(BuisinessModel))]
public sealed class BuisinessController : 
    ControllerBase<BuisinessView, BuisinessModel, BuisinessData>
{
    [SerializeField] GlobalEvents _globalEvents;

    private BuisinessConfig _config;

    private bool IsEnoughMoney(float value)
    {
        return PlayerController.Instance.Balance >= value;
    }

    private IEnumerator DoIncomeProgress(float progress = 0)
    {
        var step = 1 / _config.IncomeDelaySeconds;
        var progressValue = progress;
        var refreshDelay = new WaitForEndOfFrame();
        while (progressValue < 1f)
        {
            yield return refreshDelay;

            progressValue += step * Time.deltaTime;
            _data.IncomeProgress = progressValue;
            _view.SetIncomeProgress(_data.IncomeProgress);
        }

        _globalEvents.FireOnIncome(GetIncome());
        StartCoroutine(DoIncomeProgress());
    }

    protected override void OnApplicationQuit()
    {
        base.OnApplicationQuit();

        StopAllCoroutines();
    }

    #region Data activities


    /// <summary>
    /// Loads base values from config
    /// </summary>
    /// <param name="config"></param>
    public void LoadConfig(BuisinessConfig config)
    {
        _config = config;
    }

    /// <summary>
    /// Loads saved or default data from model
    /// </summary>
    public void LoadData(string name)
    {
        _model.SetKey(name);
        _data = _model.GetData();
        _data.Name = _config.Name;

        if (_data.Level < 1)
        {
            _data.Level += _config.BaseLevel;
        }
    }

    /// <summary>
    /// Refreshes data in view and starts progress
    /// </summary>
    public void Flush()
    {
        _view.SetName(_data.Name);
        _view.SetLevel(_data.Level);
        _view.SetIncome(GetIncome());
        _view.SetIncomeProgress(_data.IncomeProgress);
        _view.SetLevelUp(GetLevelUpgradePrice());
        _view.SetUpgrade1(_config.Upgrade1, !_data.HasUniqueUpgrade1 && _data.Level > 0);
        _view.SetUpgrade2(_config.Upgrade2, !_data.HasUniqueUpgrade2 && _data.Level > 0);

        if (_data.Level > 0)
        {
            StartCoroutine(DoIncomeProgress(_data.IncomeProgress));
        }
    }


    #endregion

    #region View callbacks


    public void OnLevelUpBtnClicked()
    {
        var price = GetLevelUpgradePrice();
        if (IsEnoughMoney(price))
        {
            _globalEvents.FireOnWithdraw(price);
            UpgradeLevel();
        }
    }

    public void OnUpgrade1BtnClick()
    {
        var price = _config.Upgrade1.Price;
        if (IsEnoughMoney(price))
        {
            _globalEvents.FireOnWithdraw(price);
            UniqueUpgrade1();
        }
    }

    public void OnUpgrade2BtnClick()
    {
        var price = _config.Upgrade2.Price;
        if (IsEnoughMoney(price))
        {
            _globalEvents.FireOnWithdraw(price);
            UniqueUpgrade2();
        }
    }


    #endregion

    #region Upgrades


    public void UpgradeLevel()
    {
        _data.Level += 1;
        _view.SetLevel(_data.Level);
        _view.SetIncome(GetIncome());

        if (_data.Level == 1)
        {
            StartCoroutine(DoIncomeProgress());
            _view.SetUpgrade1(_config.Upgrade1, true);
            _view.SetUpgrade2(_config.Upgrade2, true);
        }

        _view.SetLevelUp(GetLevelUpgradePrice());
    }

    public void UniqueUpgrade1()
    {
        if (_data.HasUniqueUpgrade1)
        {
            Debug.LogWarning($"Upgrade 1 is already present");
            return;
        }

        _data.HasUniqueUpgrade1 = true;
        _view.SetUpgrade1(_config.Upgrade1, false);
        _view.SetIncome(GetIncome());
    }

    public void UniqueUpgrade2()
    {
        if (_data.HasUniqueUpgrade2)
        {
            Debug.LogWarning($"Upgrade 2 is already present");
            return;
        }

        _data.HasUniqueUpgrade2 = true;
        _view.SetUpgrade2(_config.Upgrade2, false);
        _view.SetIncome(GetIncome());
    }


    #endregion

    #region Buisiness logic formulas


    public float GetIncome()
    {
        var temp = _data.Level * _config.BaseIncome;
        var upgradeFactor = _data.HasUniqueUpgrade1
                ? _config.Upgrade1.IncomeFactorPercents / 100
                : 0;
        upgradeFactor += _data.HasUniqueUpgrade2
                ? _config.Upgrade2.IncomeFactorPercents / 100
                : 0;

        return temp * (1 + upgradeFactor);
    }

    public float GetLevelUpgradePrice()
    {
        return (_data.Level + 1) * _config.BasePrice;
    }


    #endregion
}
