using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    [SerializeField]
    private int _heal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character chr = collision.GetComponentInChildren<Character>();
        if (chr && collision.gameObject.tag == "Player")
        {
            chr.ApplyDamage(-_heal);
            Destroy(gameObject);
        }
    }

}
