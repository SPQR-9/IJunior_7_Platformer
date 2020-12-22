using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]


public class Bomb : MonoBehaviour
{
    private Animator _animator;
    private BombWay _wayScript;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _wayScript = GetComponent<BombWay>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Destroy(_wayScript);
            _animator.SetTrigger("Destroy");
            Destroy(player.gameObject);
        }
    }
}
