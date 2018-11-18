using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FadeInImage : MonoBehaviour {

    [SerializeField]
    private Image _fadeImage;

    [SerializeField]
    private GameObject _rootObj;

    [SerializeField]
    private float _time = 1.0f;

    [SerializeField]
    private AnimationCurve _alphaCurve;

    private float _curTime;

    [HideInInspector]
    public class FadingEvent : UnityEvent<GameObject> { }
    [HideInInspector]
    public FadingEvent OnFadingFinished = new FadingEvent();


    private void Update()
    {

        _curTime += (Time.deltaTime);
        float t = Mathf.Clamp01(_curTime / _time);
        float curveAlpha = _alphaCurve.Evaluate(t);

        var color = _fadeImage.color;
        color.a = _fadeImage.color.a * curveAlpha;
        _fadeImage.color = color;

        if (t >= 1.0f)
        {
            OnFadingFinished.Invoke(this.gameObject);
            Destroy(_rootObj);
        }
    }
}
