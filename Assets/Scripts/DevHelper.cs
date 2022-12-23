using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


public sealed class DevHelper : MonoBehaviour
{
    [SerializeField] Config _config;

    public Config Config => _config;
}


#if UNITY_EDITOR

[CustomEditor(typeof(DevHelper))]
public sealed class DevHelperEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Clear PlayerPrefs"))
        {
            var devHelper = target as DevHelper;
            foreach (var node in devHelper.Config.Buisinesses)
            {
                PlayerPrefs.SetString(node.Name, null);
            }

            PlayerPrefs.SetString("PlayerData", null);
        }
    }
}

#endif
