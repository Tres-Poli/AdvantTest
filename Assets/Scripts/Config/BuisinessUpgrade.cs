using System;
using UnityEngine;

[Serializable]
public sealed class BuisinessUpgrade
{
    [field: SerializeField] public string Name { get; set; }
    [field: SerializeField] public float Price { get; set; }
    [field: SerializeField] public float IncomeFactorPercents { get; set; }
}
