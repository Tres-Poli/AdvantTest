using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public sealed class LevelUpButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _price;

    public void SetPrice(float nextLevelPrice)
    {
        _price.text = $"Price: {nextLevelPrice}$";
    }
}
