using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour
{

    [SerializeField]
    private AController _controller = null;
    [SerializeField]
    private Transform _transform = null;
    [SerializeField]
    private float _chargeWidth = 1;
    private float _charge = 0;
    private float _maxCharge = 3;

    void Update()
    {
        _charge = Mathf.Min(_charge + Time.deltaTime, _maxCharge);
        if (_charge >= _maxCharge)
        {
            if (_controller)
            {
                if (_controller.IsAction2())
                {
                    Vector3 tar = _controller.GetMove() * _chargeWidth;
                    _transform.position += tar;
                }
            }
        }
    }
}
