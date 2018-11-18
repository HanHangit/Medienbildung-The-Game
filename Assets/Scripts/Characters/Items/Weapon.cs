using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
     
    private float _currTime = 0;
    [SerializeField]
    private WeaponAttributes _attribute = null;

    public float ReloadTime => _attribute.ReloadTime;

    public bool CanShoot => _currTime > ReloadTime;

    public void Shoot(Vector2 pos, Vector2 dir)
    {
        if(CanShoot)
        {
            _currTime = 0;
            Projectile.CreateProjectile(_attribute.Projectile,pos, dir, _attribute.ProjectileSpeed);
        }
    }

    private void Update()
    {
        _currTime += Time.deltaTime;
    }


}
