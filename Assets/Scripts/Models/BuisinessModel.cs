using UnityEngine;
using Newtonsoft.Json;

public sealed class BuisinessModel : ModelBase<BuisinessData>
{
    protected override BuisinessData CreateDefaultData()
    {
        return new BuisinessData 
        {
            Level = 0,
            IncomeProgress = 0f,
            HasUniqueUpgrade1 = false,
            HasUniqueUpgrade2 = false,
        };
    }
}
