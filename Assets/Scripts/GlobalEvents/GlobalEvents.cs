using System;
using UnityEngine;

[CreateAssetMenu(fileName = "OnGetIncome", menuName = "ScriptableObjects/GlobalEvents/OnGetIncome")]
public class GlobalEvents : ScriptableObject
{
    public event Action<float> OnIncome;
    public event Action<float> OnWithdraw;

    public void FireOnIncome(float value)
    {
        OnIncome?.Invoke(value);
    }

    public void FireOnWithdraw(float value)
    {
        OnWithdraw?.Invoke(value);
    }
}
