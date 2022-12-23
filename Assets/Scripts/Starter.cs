using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public sealed class Starter : MonoBehaviour
{
    [SerializeField] Config _config;

    private BuisinessController[] _controllers;

    private void Awake()
    {
        _controllers = GetComponentsInChildren<BuisinessController>();
    }

    private void Start()
    {
        var buisinessesCount = Mathf.Min(_config.Buisinesses.Length, _controllers.Length);
        for (int i = 0; i < buisinessesCount; i++)
        {
            var config = _config.Buisinesses[i];
            var controller = _controllers[i];
            controller.LoadConfig(config);
            controller.LoadData(config.Name);
            controller.Flush();
        }
    }
}
