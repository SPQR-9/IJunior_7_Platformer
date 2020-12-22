using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Diamond : MonoBehaviour
{
    [SerializeField] private UnityEvent _diamondCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player _))
        {
            _diamondCollected.Invoke();
            Destroy(gameObject);
        }
    }
}
