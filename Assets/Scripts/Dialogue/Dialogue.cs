using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Canvas))]
public class Dialogue : MonoBehaviour {

    [SerializeField]
    private List<string> _dialogue;

    [SerializeField]
    private TextMeshProUGUI _text;

    [SerializeField]
    private bool _onStartActive = false;

    [SerializeField]
    private ControllerPlayerMovement _playerMovement;

    [SerializeField]
    private GameObject _parentObj;

    [SerializeField]
    private bool _onceOnlyTrigger = false;

    private bool _isDialogueTriggered = false;
    private int _index;

    private void Awake()
    {
        if (_onStartActive)
            _parentObj.SetActive(true);
        else
            _parentObj.SetActive(false);
    }

    public void StartDialogue(int index = 0)
    {
        if (_isDialogueTriggered && _onceOnlyTrigger)
            return; 

        if (!_parentObj.gameObject.activeInHierarchy)
            _parentObj.SetActive(true);

        if (_playerMovement != null)
            _playerMovement.DisableControlling();

        _text.text = _dialogue[index];
        _index = index;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            NextDialogue();
        }
    }


    private void NextDialogue()
    {
        _index++;

        if(_index >= _dialogue.Count)
        {
            EndDialogue();
        }
        else
        {
            _text.text = _dialogue[_index];   
        }
    }

    private void EndDialogue()
    {
        _isDialogueTriggered = true;

        if (_playerMovement != null)
            _playerMovement.EnableControlling();

        _parentObj.gameObject.SetActive(false);
    }
}
