using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorKIController : AController
{

    #region Variables

    protected Vector2 _currMove;

    #endregion


    #region Public

    public override Vector2 GetMove()
    {
        return _currMove;
    }

    public override void Init()
    {
         _currMove = new Vector2(Random.Range(-10, 10), 0);
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
