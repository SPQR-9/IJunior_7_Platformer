using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerPlayer : MonoBehaviour
{
    private Object _scriptCameraMove;

    private void Start()
    {
        _scriptCameraMove = GetComponent<CameraMove>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            Destroy(_scriptCameraMove);
            Destroy(collision.gameObject);
        }
    }
}
