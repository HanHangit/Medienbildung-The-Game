using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Misc/Character", order = 3)]
public class CharacterAttributes : ScriptableObject {

    public int MaxHealth;
    public float Speed;
    public float JumpForce;
    public int Damage;
}
