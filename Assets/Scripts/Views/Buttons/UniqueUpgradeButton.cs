using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public sealed class UniqueUpgradeButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _name;
    [SerializeField] TextMeshProUGUI _price;
    [SerializeField] TextMeshProUGUI _incomeFactor;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void SetName(string name)
    {
        _name.text = name;
    }

    public void SetPrice(float price)
    {
        _price.text = $"Price: {price}$";
    }

    public void SetIncomeFactor(float percents)
    {
        _incomeFactor.text = $"Income: +{percents}%";
    }

    public void SetActive(bool isActive)
    {
        _button.interactable = isActive;
    }
}
