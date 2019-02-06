using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{

    #region Variables

    [SerializeField]
    private CharacterAttributes _attribute;
    [SerializeField]
    private OnDeath _onDeath = new OnDeath();
    private int _currHealth = 0;

    #endregion


    #region Unity

    private void Start()
    {
        _currHealth = _attribute.MaxHealth;
    }

    #endregion


    #region Public

    public CharacterAttributes Attribute => _attribute;

    public void ApplyDamage(int dmg)
    {
        Debug.Log(dmg);
        _currHealth -= dmg;
        if (_currHealth <= 0)
        {
            _onDeath.Invoke();
            Destroy(gameObject);
        }
    }

    public void ApplyDamage(Projectile proj)
    {
        ApplyDamage(proj.Attribute.Damage);
    }

    public void ApplyDamage(Character attr)
    {
        ApplyDamage(attr.Attribute.Damage);
    }

    #endregion


    #region Strucutures

    [Serializable]
    private class OnDeath : UnityEvent { }

    #endregion


    #region Events

    public void CalcDamage(Collider2D other)
    {
        Debug.Log(gameObject.name);
        Projectile otherProj = other.gameObject.GetComponentInParent<Projectile>();
        if (otherProj)
            ApplyDamage(otherProj);

        Character otherChar = other.gameObject.GetComponentInParent<Character>();
        if (otherChar)
            ApplyDamage(otherChar);
    }

    public void DestroyObject(Collider2D other)
    {
        Destroy(gameObject);
    }

    #endregion
}
