using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]

public class WinZone : MonoBehaviour
{
    [SerializeField] private Color _winColor;
    [SerializeField] private Text _score;
    [SerializeField] private int _quatityPointsToWin;
    private SpriteRenderer _sprite;
    void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player) && Convert.ToInt32(_score.text) >= _quatityPointsToWin)
        {
            _sprite.color = _winColor;
            Destroy(player);
        }
    }
}
