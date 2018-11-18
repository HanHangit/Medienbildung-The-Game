using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AController : MonoBehaviour
{
    public abstract Vector2 GetMove();
    public abstract bool IsJump();
    public abstract bool IsAction1();
    public abstract bool IsAction2();
}
