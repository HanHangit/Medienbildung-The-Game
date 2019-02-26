using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChinaKI : AController {

    [SerializeField]
    private EnemyMovement _movement;

    [SerializeField]
    private AnimationCurve _speedCurve;

    private Vector2 _direction;
    private Character _player;
    private float _time;
    [SerializeField]
    private int _damageValue = 10;

    public override Vector2 GetMove()
    {
        return _direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var character = collision.gameObject.GetComponent<Character>();
            character.ApplyDamage(_damageValue);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            CollisionTriggered();
        }
    }

    private void Start()
    {
        GameManager.Instance.OnPlayerRegistered.AddListener(PlayerRegistered);
        gameObject.SetActive(false);
    }

    private void PlayerRegistered(Character arg0)
    {
        _player = arg0;
        CollisionTriggered();
    }

    private void Update()
    {
        _time += Time.deltaTime;
     
       _movement.IncreseVelocity(_speedCurve.Evaluate(_time));
    }


    public void CollisionTriggered()
    {

        _direction = _player.transform.position - this.transform.position;
        if (_direction.x > 0)
            _direction = Vector2.right;
        else
            _direction = Vector2.left;

        _movement.ResetVelocity();
        _time = 0;

    }


    public override bool IsAction1()
    {
        return false;
    }

    public override bool IsAction2()
    {
        return false;
    }

    public override bool IsJump()
    {
        return false;
    }

}
