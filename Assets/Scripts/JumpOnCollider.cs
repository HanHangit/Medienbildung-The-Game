using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOnCollider : MonoBehaviour
{

    #region Variables

    [SerializeField]
    private Rigidbody2D _rgbd = null;
    [SerializeField]
    private Collider2D _collider = null;
    private bool _borderCollision = false;

    #endregion


    private void OnValidate()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void Awake()
    {
        _collider = _collider ?? GetComponent<Collider2D>();

    }

    private void Start()
    {
        _rgbd = _rgbd ?? GetComponentInParent<Rigidbody2D>();
        //GameManager.Instance?.OnPlayerRegistered.AddListener((c) => _rgbd = c.GetComponent<Rigidbody2D>());
    }

    private void Update()
    {
        if (_rgbd)
        {
            if (_rgbd.velocity.y > 0.1f && !_borderCollision)
                _collider.enabled = false;
            else
                _collider.enabled = true;
        }
    }

}
