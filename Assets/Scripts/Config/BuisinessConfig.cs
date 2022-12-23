using UnityEngine;

[CreateAssetMenu(fileName = "BuisinessConfig", menuName = "ScriptableObjects/BuisinessConfig")]
public class BuisinessConfig : ScriptableObject
{
    [field: SerializeField] public string Name { get; set; }
    [field: SerializeField] public float IncomeDelaySeconds { get; set; }
    [field: SerializeField] public int BaseLevel { get; set; }
    [field: SerializeField] public float BasePrice { get; set; }
    [field: SerializeField] public float BaseIncome { get; set; }
    [field: SerializeField] public BuisinessUpgrade Upgrade1 { get; set; }
    [field: SerializeField] public BuisinessUpgrade Upgrade2 { get; set; }
}
