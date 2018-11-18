using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class BackgroundStart : MonoBehaviour {

    [SerializeField]
    private FadeInImage _fadePrefab;
    [SerializeField]
    private BackgroundAnimation _settings;

    [SerializeField]
    private FadeText _fadeText;

    [SerializeField]
    private SceneRef _sceneName;

    private void Start()
    {
        var instance = Instantiate(_fadePrefab, this.transform);
        instance.GetComponent<FadeInImage>().OnFadingFinished.AddListener(FadingIntroCompleted);
    }

    private void FadingIntroCompleted(GameObject arg0)
    {
        Debug.Log("Bin hier driN");
        _fadeText.StartFading();
        _fadeText.OnFadingFinished.AddListener(FadingTextCompleted);
    }


    private void FadingTextCompleted(GameObject arg0)
    {
        Instantiate(_settings, this.transform);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            SceneManager.LoadScene(_sceneName.GetSceneName());
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene(_sceneName.GetSceneName());
        }


    }
}
