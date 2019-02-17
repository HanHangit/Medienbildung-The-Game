using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorKIController : AController
{

    #region Variables

    protected Vector2 _currMove;

    #endregion


    #region Unity


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CameraBorder")
            Destroy(gameObject);
    }

    public void DestroyOnTrigger(Collider2D collision)
    {
        Destroy(gameObject);
    }

    #endregion


    #region Public

    public override Vector2 GetMove()
    {
        return _currMove;
    }

    public override void Init()
    {
        _currMove = new Vector2(-1, 0);
        _currMove.Normalize();
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

    public override void OnCollision(GameObject obj, Collision2D collision)
    {
        if (Mathf.Abs(collision.gameObject.transform.position.y - obj.transform.position.y) < obj.GetComponent<SpriteRenderer>().bounds.size.y
            && collision.gameObject.tag == "Obstacle")
        {
            _currMove *= -1;
        }
    }

    #endregion
}
