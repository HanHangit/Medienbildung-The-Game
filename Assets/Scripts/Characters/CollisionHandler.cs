using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField]
    private OnCollision2D _onCollision = new OnCollision2D();

    #region Unity

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _onCollision.Invoke(collision);
    }

    #endregion


    #region Structures

    [Serializable]
    private class OnCollision2D : UnityEvent<Collision2D> { }

    #endregion


    #region Events

    public void Destroy(Collision2D collision)
    {
        Destroy(gameObject);
    }

    public void ApplyDamage(Collision2D collision)
    {
        Character myChar = GetComponent<Character>();
        Projectile otherProj = collision.gameObject.GetComponent<Projectile>();

        if(myChar && otherProj)
            myChar.ApplyProjectile(otherProj);
    }

    #endregion
}
