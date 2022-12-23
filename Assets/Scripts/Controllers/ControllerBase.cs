using UnityEngine;

public abstract class ControllerBase<T, Z, N> : MonoBehaviour 
    where T : ViewBase
    where Z : ModelBase<N>
{
    protected T _view;
    protected Z _model;
    protected N _data;

    protected virtual void Awake()
    {
        _view = GetComponent<T>();
        _model = GetComponent<Z>();
    }

    protected virtual void OnApplicationQuit()
    {
        _model.SaveData(_data);
    }
}
