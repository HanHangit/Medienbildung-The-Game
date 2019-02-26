using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGameobject : MonoBehaviour {

	[SerializeField]
	private GameObject _triggerObj;
	[SerializeField]
	private bool _onlyOnce = true;
	private bool _finished = false;


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (_finished)
			return;

		if (collision.tag == "Player")
		{
			_triggerObj.gameObject.SetActive(true);
			if(_onlyOnce)
				_finished = false;
		}
	}
}
