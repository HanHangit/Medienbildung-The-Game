using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class FadeText : MonoBehaviour {

    [SerializeField]
    private TextMeshProUGUI _fadeText;

    [SerializeField]
    private GameObject _rootObj;

    [SerializeField]
    private float _time = 1.0f;

    [SerializeField]
    private AnimationCurve _alphaCurve;

    private float _curTime;
    [SerializeField]
    private bool _fadeOnStart = false;

    [HideInInspector]
    public class FadingEvent : UnityEvent<GameObject> { }
    [HideInInspector]
    public FadingEvent OnFadingFinished = new FadingEvent();
    private bool _isFinished = false;

    public void StartFading()
    {
        _curTime = 0;
        _fadeOnStart = true;
    }

    private void Update()
    {
        if (!_fadeOnStart || _isFinished)
            return; 

        _curTime += (Time.deltaTime);
        float t = Mathf.Clamp01(_curTime / _time);
        float curveAlpha = _alphaCurve.Evaluate(t);
  
        var color = _fadeText.color;
        color.a = _fadeText.color.a * curveAlpha;
        _fadeText.color = color;

        if ( t >= 1.0f)
        {
            _isFinished = true;
            OnFadingFinished.Invoke(this.gameObject);
            if(_rootObj != null)
             Destroy(_rootObj);

        }
    }
}
