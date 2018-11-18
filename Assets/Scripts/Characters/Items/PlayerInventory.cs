using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour   {

    #region Variables

    [SerializeField]
    private PlayerMovement _controller;

    [SerializeField]
    private GameObject _shootLeft;
    [SerializeField]
    private GameObject _shootRight;

    [SerializeField]
    private Weapon _weapon;
    [SerializeField]
    private Utility _utility;
    #endregion


    #region Unity

    private void Update()
    {
        if (_controller.Controller.IsAction1() && _shootLeft && _shootRight)
        {
            Weapon?.Shoot(_controller.LookDir.x > 0 ? _shootRight.transform.position : _shootLeft.transform.position, _controller.LookDir);
        }
        if (_controller.Controller.IsAction2())
            Utility?.Use();
    }

    #endregion


    #region Public

    public Utility Utility => _utility;

    public Weapon Weapon => _weapon;

    #endregion
}
