using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : SerializedMonoBehaviour   {

    #region Variables

    [Required]
    [OdinSerialize]
    private PlayerMovement _controller;

    [SerializeField]
    private GameObject _shootLeft;
    [SerializeField]
    private GameObject _shootRight;

    #endregion


    #region Unity

    private void Update()
    {
        if (_controller.Controller.IsAction1() && _shootLeft && _shootRight)
            Weapon?.Shoot(_controller.LookDir.x > 0 ? _shootRight.transform.position : _shootLeft.transform.position, _controller.LookDir);
        if (_controller.Controller.IsAction2())
            Utility?.Use();
    }

    #endregion


    #region Public

    [OdinSerialize]
    public Utility Utility { get; set; }

    [OdinSerialize]
    public Weapon Weapon { get; set; } 

    #endregion
}
