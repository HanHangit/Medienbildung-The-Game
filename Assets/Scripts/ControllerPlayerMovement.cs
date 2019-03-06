using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayerMovement : MonoBehaviour {

    [SerializeField]
    private PlayerMovement _playerMove;


    public void DisableControlling()
    {
        if (_playerMove != null)
            _playerMove.DisableController();
    }

    public void EnableControlling()
    {
        if (_playerMove != null)
            _playerMove.EnableController();
    }


    private void Awake()
    {
		if (GameManager.Instance == null)
			Debug.Log("Null");
        GameManager.Instance.OnPlayerRegistered.AddListener(PlayerRegistered);
    }

    private void PlayerRegistered(Character arg0)
    {
		Debug.Log("PlayerControllerMOvement");
        if(arg0.gameObject.tag == ("Player"))
        {
            _playerMove = arg0.GetComponent<PlayerMovement>();
        }
    }
}
