using TMPro;
using UnityEngine;

public sealed class PlayerView : ViewBase
{
    [SerializeField] TextMeshProUGUI _balance;

    public void SetBalance(float value)
    {
        _balance.text = $"BALANCE: {value}$";
    }
}
