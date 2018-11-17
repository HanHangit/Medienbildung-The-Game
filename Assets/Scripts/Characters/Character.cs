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
    [SerializeField]
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

    public void ApplyProjectile(Projectile proj)
    {
        _currHealth -= proj.Attribute.Damage;
        if (_currHealth <= 0)
        {
            _onDeath.Invoke();
            Destroy(gameObject);
        }
    }

    #endregion


    #region Strucutures

    private class OnDeath : UnityEvent { }

    #endregion
}
