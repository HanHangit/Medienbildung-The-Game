using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : AController
{
    #region Public

    public override Vector2 GetMove()
    {
        if (Input.GetKey(KeyCode.A))
            return new Vector2(-1, 0);
        else if (Input.GetKey(KeyCode.D))
            return new Vector2(1, 0);
        else
            return Vector2.zero;
    }

    public override bool IsAction1()
    {
        return Input.GetKey(KeyCode.Q);
    }

    public override bool IsAction2()
    {
        return Input.GetKey(KeyCode.E);
    }

    public override bool IsJump()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    #endregion
}
