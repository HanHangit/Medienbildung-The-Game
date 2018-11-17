using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour {

    [SerializeField]
    private Animator _anim;

    private string _run = "Run";
    private string _idle = "Idle";
    private string _jump = "Jump";
    private string _jumpDown = "JumpDown";

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Run();
        }
        if (Input.GetKey(KeyCode.W))
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.S))
        {
            JumpDown();
        }
        if (Input.GetKey(KeyCode.A))
        {
            Idle();
        }
    }

    public void Run()
    {
        _anim.SetBool(_idle, false);
        _anim.SetBool(_jump, false);
        _anim.SetBool(_jumpDown, false);
        _anim.SetBool(_run, true);

    }

    public void Idle()
    {
        _anim.SetBool(_jump, false);
        _anim.SetBool(_jumpDown, false);
        _anim.SetBool(_run, false);
        _anim.SetBool(_idle, true);

    }

    public void Jump()
    {
        _anim.SetBool(_jumpDown, false);
        _anim.SetBool(_run, false);
        _anim.SetBool(_idle, false);
        _anim.SetBool(_jump, true);

    }

    public void JumpDown()
    {
        _anim.SetBool(_run, false);
        _anim.SetBool(_idle, false);
        _anim.SetBool(_jump, false);
        _anim.SetBool(_jumpDown, true);
    }



}
