using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "ScriptableObjects/Config")]
public sealed class Config : ScriptableObject
{
    [SerializeField] public BuisinessConfig[] Buisinesses;
}
