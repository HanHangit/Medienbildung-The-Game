using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollision : MonoBehaviour
{

    [SerializeField]
    private Sprite _openedDoor;
    [SerializeField]
    private SpriteRenderer _renderer;
    [SerializeField]
    private float _duration;
    private Sprite _default;

    private void Start()
    {
        if (!_renderer)
            _renderer = GetComponent<SpriteRenderer>();
        _default = _renderer.sprite;

    }

    public void OnTrigger2D(Collider2D other)
    {
        if (_renderer)
        {
            if (other.gameObject.tag == "Enemy")
            {
                Destroy(other.gameObject);
                StartCoroutine(ChangeSprite());
            }
        }
    }

    private IEnumerator ChangeSprite()
    {
        _renderer.sprite = _openedDoor;
        yield return new WaitForSeconds(_duration);
        _renderer.sprite = _default;
    }

}
