using UnityEngine;

[RequireComponent(typeof(PlayerView))]
[RequireComponent(typeof(PlayerModel))]
public sealed class PlayerController : 
    ControllerBase<PlayerView, PlayerModel, PlayerData>
{
    [SerializeField] GlobalEvents _incomeEvent;

    public static PlayerController Instance { get; private set; }

    public float Balance => _data.Balance;

    private void OnIncome(float value)
    {
        _data.Balance += value;
        _view.SetBalance(_data.Balance);
    }

    private void OnWithdraw(float value)
    {
        _data.Balance -= value;
        _view.SetBalance(_data.Balance);
    }

    protected override void Awake()
    {
        base.Awake();
        if (ReferenceEquals(Instance, null))
        {
            Instance = this;
            _model.SetKey("PlayerData");
            _data = _model.GetData();

            _view.SetBalance(_data.Balance);

            _incomeEvent.OnIncome += OnIncome;
            _incomeEvent.OnWithdraw += OnWithdraw;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected override void OnApplicationQuit()
    {
        base.OnApplicationQuit();

        _incomeEvent.OnIncome -= OnIncome;
        _incomeEvent.OnWithdraw -= OnWithdraw;
        Instance = null;
    }
}
