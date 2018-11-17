using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BackgroundAnimation : MonoBehaviour {

    [SerializeField]
    private AnimationCurve _alphaCurve;
    [SerializeField]
    private float _circleTime;
    [SerializeField]
    private float _minAlpha = 0.0f;
    [SerializeField]
    private float _maxAlpha = 1.0f;
    private float _curTime;


    [SerializeField]
    private TextMeshProUGUI[] _text;

    private void Start()
    {
        _curTime = 0;
    }

    private void Update()
    {
        _curTime += Time.deltaTime;

        float t = _curTime / _circleTime;


        for (int i = 0; i < _text.Length; i++)
        {
            Color c = _text[i].color;
            c.a = _alphaCurve.Evaluate(t) * (_maxAlpha - _minAlpha) + _minAlpha;

            _text[i].color = c;

        }
    }
}
