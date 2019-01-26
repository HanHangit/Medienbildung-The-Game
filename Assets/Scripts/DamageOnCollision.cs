using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour {

    [SerializeField]
    private int _damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Character chr = collision.gameObject.GetComponent<Character>();
        if(chr)
        {
            chr.ApplyDamage(_damage);
            Destroy(gameObject);
        }
    }

}
