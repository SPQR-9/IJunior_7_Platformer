using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerPlayer : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            Destroy(GetComponent<CameraMove>());
            Destroy(collision.gameObject);
        }
    }
}
