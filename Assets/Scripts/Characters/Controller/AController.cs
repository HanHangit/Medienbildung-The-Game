using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// WARUM KEIN INTERFACE!?
public abstract class AController : MonoBehaviour
{
    public abstract Vector2 GetMove();
    public abstract bool IsJump();
    public abstract bool IsAction1();
    public abstract bool IsAction2();
    public virtual void Init() { }
    public virtual void OnCollision(GameObject obj, Collision2D collision) { }
}
