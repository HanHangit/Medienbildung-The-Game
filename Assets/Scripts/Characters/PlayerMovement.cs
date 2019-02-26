using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    #region Variables

    [SerializeField]
    Character _character;

    [SerializeField]
    private Rigidbody2D _rgbd = null;

    [SerializeField]
    private AController _controller = null;

    [SerializeField]
    private Vector2 _lookDir = Vector2.zero;

    private bool _isControlling = true;
    public bool IsControlling { get { return _isControlling; } }

    #endregion


    #region Unity

    private void Awake()
    {
        GameManager.Player = GetComponent<Character>();
    }

    private void Start()
    {
        if (!_rgbd || !_controller)
            enabled = false;
        GameManager.Instance.PlayerRegistered(GetComponent<Character>());
    }

    private void Update()
    {
        if (_isControlling)
            SetMoving();
    }

    private void SetMoving()
    {
        Vector2 move = _controller.GetMove() * _character.Attribute.Speed * Time.deltaTime;
        move.y = _rgbd.velocity.y;
        _rgbd.velocity = move;

        if (_rgbd.velocity.y == 0 && _controller.IsJump())
            _rgbd.AddForce(Vector2.up * _character.Attribute.JumpForce);

        if (move.x != 0)
            _lookDir = move;
    }

    public void DisableController()
    {
        _isControlling = false;
        _lookDir = Vector2.right;
        _rgbd.velocity = Vector2.zero;
    }


    public void EnableController()
    {
        _isControlling = true;
    }

    #endregion


    #region Public

    public Vector2 LookDir => new Vector2(_lookDir.x,0);
    public AController Controller => _controller;

    #endregion
}
