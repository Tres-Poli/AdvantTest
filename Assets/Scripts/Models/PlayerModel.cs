public sealed class PlayerModel : ModelBase<PlayerData>
{
    protected override PlayerData CreateDefaultData()
    {
        return new PlayerData
        {
            Balance = 0f,
        };
    }
}
