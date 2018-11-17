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

    #endregion


    #region Unity

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    #endregion


    #region Public

    public CharacterAttributes Attribute => _attribute;

    public void ApplyProjectile(Projectile proj)
    {
        _attribute.CurrHealth -= proj.Attribute.Damage;
        if (_attribute.CurrHealth <= 0)
        {
            _onDeath.Invoke();
            Destroy(this);
        }
    }

    #endregion


    #region Strucutures

    private class OnDeath : UnityEvent { }

    #endregion
}
