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

	[SerializeField]
	private Character _malePrefab;
	[SerializeField]
	private Character _femalePrefab;
	[SerializeField]
	private Transform _spawnPos;


	private void Start()
	{
		int playerPrefabIndex = PlayerPrefs.GetInt("Player");

		if (playerPrefabIndex == 0)
			Instantiate(_malePrefab, _spawnPos.position, Quaternion.identity, null);
		else
			Instantiate(_femalePrefab, _spawnPos.position, Quaternion.identity, null);

		
	}


	public class PlayerRegister : UnityEngine.Events.UnityEvent<Character> { }
    public PlayerRegister OnPlayerRegistered = new PlayerRegister();

    public void PlayerRegistered(Character character)
    {
        OnPlayerRegistered.Invoke(character);
    }
}
