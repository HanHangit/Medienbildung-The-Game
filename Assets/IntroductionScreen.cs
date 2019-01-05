using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class IntroductionScreen : MonoBehaviour {

    [SerializeField]
    private List<string> _text;
    [SerializeField]
    private TextMeshProUGUI _textMesh;
    [SerializeField]
    private float _actionTimer;
    [SerializeField]
    private TextMeshProUGUI _continueText;
    [SerializeField]
    private TextMeshProUGUI _skipText;

    [SerializeField]
    private SceneRef _sceneName;

    private float _curTimer = 0;
    private int _curIndex = 0;
    private bool _finishedInit = false;

    private void Start()
    {
        _continueText.gameObject.SetActive(false);
        _skipText.gameObject.SetActive(false);
        Debug.Log("Fixe: "  + PlayerPrefs.GetInt("Player").ToString());

    }
    private void Update()
    {
        if(_textMesh.color.a >= 0.95f && !_finishedInit)
        {
            _continueText.gameObject.SetActive(true);
            _continueText.gameObject.GetComponent<BackgroundAnimation>().Activate();
            _skipText.gameObject.SetActive(true);
            _finishedInit = true;
        }

        if (!_finishedInit)
            return;

        if (Input.GetKeyDown(KeyCode.E))
            SceneManager.LoadScene(_sceneName.GetSceneName());

        _curTimer += Time.deltaTime;

        if(_curTimer > _actionTimer)
        {
            if (Input.anyKey)
            {
                _curTimer = 0;
                _curIndex++;

                if(_curIndex >= _text.Count)
                    SceneManager.LoadScene(_sceneName.GetSceneName());
                else
                    _textMesh.text = _text[_curIndex];
            }
        }
    }
}


