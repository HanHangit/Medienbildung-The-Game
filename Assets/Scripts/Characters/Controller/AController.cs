using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AController
{
    public abstract Vector2 GetMove();
    public abstract bool IsJump();
    public abstract bool IsAction1();
    public abstract bool IsAction2();
}
