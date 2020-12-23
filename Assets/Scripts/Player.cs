using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;
using UnityEngine.UIElements;
using Vector2 = UnityEngine.Vector2;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _renderer;
    [SerializeField] private float _speed = 0f;
    [SerializeField] private float _jumpForce = 0f;
    [SerializeField] private float _penaltyToSpeedInFlight;
    private bool _isOnGround = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }
  
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround == true)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
        else if (Input.GetKey(KeyCode.D) && _isOnGround == true)
        {
            _rigidbody.AddForce(Vector2.right * _speed, ForceMode2D.Force);
            _renderer.flipX = false;
            _animator.SetBool("Run", true);
        }
        else if (Input.GetKey(KeyCode.A) && _isOnGround == true)
        {
            _rigidbody.AddForce(Vector2.left * _speed, ForceMode2D.Force);
            _renderer.flipX = true;
            _animator.SetBool("Run", true);
        }
        else if (Input.GetKey(KeyCode.D) && _isOnGround == false)
        {
            _rigidbody.AddForce(Vector2.right * _speed/3, ForceMode2D.Force);
            _renderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.A) && _isOnGround == false)
        {
            _rigidbody.AddForce(Vector2.left * _speed/ _penaltyToSpeedInFlight, ForceMode2D.Force);
            _renderer.flipX = true;
        }
        else
        {
            _animator.SetBool("Run", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.TryGetComponent(out TilemapCollider2D _))
        {
            _isOnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.TryGetComponent(out TilemapCollider2D _))
        {
            _isOnGround = false;
        }
    }
}
