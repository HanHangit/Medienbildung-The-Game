using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    #region Variables

    private float _speed;
    private Vector2 _dir;
    private Rigidbody2D _rgbd;
    [SerializeField]
    private ProjectileAttribute _attribute;

    #endregion


    #region Unity

    private void Start()
    {
        _rgbd = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_rgbd)
            _rgbd.velocity = _dir * _speed * Time.deltaTime;
    }

    #endregion


    #region Public

    public ProjectileAttribute Attribute => _attribute;

    public static GameObject CreateProjectile(GameObject prefab, Vector2 pos, Vector2 dir, float speed)
    {
        GameObject result = Instantiate(prefab);
        result.transform.position = pos;

        Projectile comp = result.GetComponent<Projectile>() ?? result.AddComponent<Projectile>();
        comp._dir = dir.normalized;
        comp._speed = speed;

        return result;
    }

    public void DestroyOnCollision(Collider2D other)
    {
        Character chr = other.gameObject.GetComponentInParent<Character>();
        if (chr)
        {
            chr.ApplyDamage(this);
            Destroy(gameObject);
        }
    }

    #endregion

}
