using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> _spawnObjects;
    [SerializeField]
    private float _spawnTime;
    private float _timer;
    private float _spawnPosY = 0;

    // Use this for initialization
    private void Start()
    {
        _timer = 0;
        _spawnPosY = transform.position.y;
    }

    // Update is called once per frame
    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnTime)
        {
            _timer = 0;

            GameObject instance = Instantiate(_spawnObjects[Random.Range(0, _spawnObjects.Count)]);
            instance.transform.position = new Vector3(transform.position.x, _spawnPosY);
        }
    }
}
