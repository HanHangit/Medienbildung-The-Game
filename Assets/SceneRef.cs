using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "SceneRef", menuName = "Misc/SceneRef", order = 1)]
public sealed class SceneRef : ScriptableObject
{
    [SerializeField]
    private Object _scene;
    [SerializeField]
    private string _sceneName;

    private void OnValidate()
    {
#if UNITY_EDITOR

        if (_scene && !(_scene is SceneAsset))
        {
            _scene = null;
            Debug.LogError("Only Scenes can be referenced by " + GetType().Name + "!", this);
        }
#endif
        UpdateString();
    }

    //Also called when building an .exe, thus always up to date:
    private void OnEnable()
    {
        UpdateString();
    }

    private void UpdateString(bool force = false)
    {
        //Needed, because upon building "_scene" is lost
        if (!_scene)
            return;

        if (_sceneName != _scene.name || force)
            _sceneName = _scene.name;
    }

    public string GetSceneName()
    {
        UpdateString(true);
        return _sceneName;
    }
}
