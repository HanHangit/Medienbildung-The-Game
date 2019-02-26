using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChinaRoomStart : MonoBehaviour {

    [SerializeField]
    private List<GameObject> _objs;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var item in _objs)
        {
            item.SetActive(true);
        }
    }
}
