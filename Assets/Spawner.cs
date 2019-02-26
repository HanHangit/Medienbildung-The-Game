using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    #region Variables

    [SerializeField]
    private GameObject _spawnObject = null;
    [SerializeField]
    private float _spawnTimeMax = 5f;
    [SerializeField]
    private float _spawnTimeMin = 3f;
    private float _timer = 0;
    private float _maxTimer = 4f;

    #endregion


    #region MyRegion

    // Update is called once per frame
    void Update()
    {
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
}
