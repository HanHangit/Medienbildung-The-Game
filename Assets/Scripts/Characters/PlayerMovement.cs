using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : SerializedMonoBehaviour {

    [SerializeField]
    private float _speed = 300;

    [SerializeField]
    private float _jumpForce = 400;

    [Required]
    [SerializeField]
    private Rigidbody2D _rgbd = null;

    [Required]
    [OdinSerialize]
    private AController _controller = null;

	// Use this for initialization
	void Start () {
        if (!_rgbd)
            enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 move = _controller.GetMove() * _speed * Time.deltaTime;
        move.y = _rgbd.velocity.y;
        _rgbd.velocity = move;

        if (_rgbd.velocity.y == 0 && _controller.IsJump())
            _rgbd.AddForce(Vector2.up * _jumpForce);

	}
}
