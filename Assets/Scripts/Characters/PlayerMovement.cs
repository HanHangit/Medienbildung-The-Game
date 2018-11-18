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

    private Vector2 _lookDir = Vector2.zero;

    #endregion


    #region Unity

    // Use this for initialization
    private void Start()
    {
        if (!_rgbd)
            enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 move = _controller.GetMove() * _character.Attribute.Speed * Time.deltaTime;
        move.y = _rgbd.velocity.y;
        _rgbd.velocity = move;

        if (_rgbd.velocity.y == 0 && _controller.IsJump())
            _rgbd.AddForce(Vector2.up * _character.Attribute.JumpForce);

        if (move.x != 0)
            _lookDir = move;

    }

    #endregion


    #region Public

    public Vector2 LookDir => new Vector2(_lookDir.x,0);
    public AController Controller => _controller;

    #endregion
}
