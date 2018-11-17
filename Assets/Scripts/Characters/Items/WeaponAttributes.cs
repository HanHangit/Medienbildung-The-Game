using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Misc/Weapon", order = 1)]
public class WeaponAttributes : ScriptableObject {

    public float ReloadTime;
    public GameObject Projectile;
    public float ProjectileSpeed;

}
