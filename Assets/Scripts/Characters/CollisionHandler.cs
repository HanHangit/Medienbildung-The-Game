using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionHandler : MonoBehaviour
{

    #region Variables

    [SerializeField]
    private OnCollision2D _onCollision = new OnCollision2D();
    [SerializeField]
    private OnTrigger2D _onTrigger = new OnTrigger2D();

    #endregion

    #region Unity

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _onCollision.Invoke(collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Log");
        _onTrigger.Invoke(collision);
    }

    #endregion


    #region Structures

    [Serializable]
    private class OnCollision2D : UnityEvent<Collision2D> { }
    [Serializable]
    private class OnTrigger2D : UnityEvent<Collider2D> { }

    #endregion


    #region Events

    public void Destroy(Collision2D collision)
    {
        Destroy(gameObject);
    }

    public void DestroyOnPlayerCollision(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Destroy(gameObject);
    }

    #endregion
}
