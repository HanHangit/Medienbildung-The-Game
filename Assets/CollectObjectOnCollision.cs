using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObjectOnCollision : MonoBehaviour
{

    #region Variables

    [SerializeField]
    private SpriteRenderer _renderer = null;
    [SerializeField]
    private Sprite _image = null;
    [SerializeField]
    private string _tag = "";
    [SerializeField]
    private float _timer = 1;
    private Sprite _oldImage = null;

    #endregion


    #region Unity

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == _tag)
        {
            _renderer.sprite = _image;
            StartCoroutine(ChangeImage());
            Destroy(collision.gameObject);
        }
    }

    // Use this for initialization
    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        if (_renderer)
        {
            _oldImage = _renderer.sprite;
        }
    }

    #endregion


    #region Helpers

    private IEnumerator ChangeImage()
    {
        yield return new WaitForSeconds(_timer);
        if (_renderer)
        {
            Debug.Log(_oldImage);
            _renderer.sprite = _oldImage;
        }
    }

    #endregion
}
