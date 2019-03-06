using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    #region Variables

    [SerializeField]
    private GameObject _follow;
    [SerializeField]
    private float _offsetX;
    [SerializeField]
    private float _offsetY;
    [SerializeField]
    private Camera _camera = null;
    private Vector2 _screenSize;
    private Vector2 _pos;

	#endregion

	#region Unity

	private void Awake()
	{
		GameManager.Instance.OnPlayerRegistered.AddListener(PlayerRegistered);
	}

	private void PlayerRegistered(Character arg0)
	{
		_follow = arg0.gameObject;
		if (!_camera)
			_camera = GetComponent<Camera>();

		_camera.transform.position = _follow.transform.position + new Vector3(0, 0, -10);

	}

	private void Start()
    {
        if (!_camera)
            _camera = GetComponent<Camera>();

          
    }

    private void Update()
    {
        if (_camera && _follow)
        {
            Vector3 followPos = _follow.transform.position;
            Vector3 _pos = _camera.transform.position;
            Vector3 diff = followPos - _pos;

            if (diff.x < -_offsetX)
                _pos.x += diff.x + _offsetX;
            if (diff.x > _offsetX)
                _pos.x += diff.x - _offsetX;

            if (diff.y < -_offsetY)
                _pos.y += diff.y + _offsetY;
            if (diff.y > _offsetY)
                _pos.y += diff.y - _offsetY;

            _camera.transform.position = _pos /*Vector3.Lerp(_camera.transform.position, _pos, 0.1f)*/;
        }
    } 

    #endregion

}
