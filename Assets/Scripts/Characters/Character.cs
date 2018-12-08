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
        _currHealth -= dmg;
        if (_currHealth <= 0)
        {
            _onDeath.Invoke();
            Destroy(gameObject);
        }
    }

    public void ApplyProjectile(Projectile proj)
    {
        ApplyDamage(proj.Attribute.Damage);
    }

    #endregion


    #region Strucutures

    private class OnDeath : UnityEvent { }

    #endregion
}
