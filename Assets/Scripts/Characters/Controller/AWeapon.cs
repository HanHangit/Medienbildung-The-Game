using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AWeapon : MonoBehaviour {

    private float _currTime = 0;


    #region Unity

    private void Update()
    {
        _currTime += Time.deltaTime;
    }

    #endregion

    public float ReloadTime { get; set; }

    public bool CanShoot => _currTime > ReloadTime;

    public void Shoot(GameObject prefab, Vector2 dir)
    {
        if(CanShoot)
        {

        }
    }



}
