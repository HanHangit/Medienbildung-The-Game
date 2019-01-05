using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOnCollider : MonoBehaviour {

    [SerializeField]
    private Rigidbody2D _rgbd = null;
    [SerializeField]
    private Collider2D _collider = null;

    private void Start()
    {
        _rgbd = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(_rgbd && _collider)
        {
            if (_rgbd.velocity.y > 0)
                _collider.enabled = false;
            else
                _collider.enabled = true;
        }
    }

}
