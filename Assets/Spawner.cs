using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    #region Variables

    [SerializeField]
    private GameObject _spawnObject = null;
    private GameObject _player = null;
    [SerializeField]
    private float _spawnTimeMax = 5f;
    [SerializeField]
    private float _spawnTimeMin = 3f;
    private float _timer = 0;
    private float _maxTimer = 4f;

    #endregion


    #region Unity

    private void Awake()
    {
        GameManager.Instance.OnPlayerRegistered.AddListener(SetPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_player.transform.position.x + 10, transform.position.y);

        _timer += Time.deltaTime;
        if(_timer >= _maxTimer && _spawnObject)
        {
            GameObject obj = Instantiate(_spawnObject);
            obj.transform.position = transform.position;
            _maxTimer = Random.Range(_spawnTimeMin, _spawnTimeMax);
            _timer = 0;
        }
    }

    #endregion


    #region Events

    private void SetPlayer(Character c)
    {
        _player = c.gameObject;
    }

    #endregion
}
