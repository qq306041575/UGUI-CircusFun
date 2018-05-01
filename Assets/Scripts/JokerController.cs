using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokerController : MonoBehaviour
{
    const float MatchHeight = 1080f;

    public float MoveSpeed;

    Rigidbody2D _jokerBody;
    Animator _jokerAnimator;
    GameObject _colliderObject;
    Vector3 _position;
    Vector2 _jumpForce;

    void Awake()
    {
        _jokerBody = GetComponent<Rigidbody2D>();
        _jokerAnimator = GetComponentInChildren<Animator>();
        _position = transform.position;
        _jumpForce = Vector2.up * (MoveSpeed - MatchHeight * 10 + Screen.height * 10);
    }

    void OnEnable()
    {
        _jokerBody.isKinematic = false;
        _jokerAnimator.enabled = true;
        _jokerAnimator.Rebind();
        transform.position = _position;
    }

    void OnDisable()
    {
        _jokerBody.velocity = Vector2.zero;
        _jokerBody.isKinematic = true;
        _jokerAnimator.enabled = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        _colliderObject = other.gameObject;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        _colliderObject = other.gameObject;
    }

    public GameObject GetColliderObject()
    {
        var temp = _colliderObject;
        if (_colliderObject)
        {
            _colliderObject = null;
        }
        return temp;
    }

    public void Jump()
    {
        _jokerBody.AddForce(_jumpForce);
        _jokerAnimator.SetTrigger("Jump");
    }
}
