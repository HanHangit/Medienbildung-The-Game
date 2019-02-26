using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    #region Singleton

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    #endregion


    public class PlayerRegister : UnityEngine.Events.UnityEvent<Character> { }
    public PlayerRegister OnPlayerRegistered = new PlayerRegister();

    public static Character Player { get; set; }

    public void PlayerRegistered(Character character)
    {
        OnPlayerRegistered.Invoke(character);
    }
}
