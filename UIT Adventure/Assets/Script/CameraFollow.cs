using UnityEngine;
using System.Collections;
using Unity.Netcode;
public class CameraFollow : NetworkBehaviour
{
    [SerializeField]
    public Camera cam;
    private void Update()
    {
        if (!IsOwner)
        {
            cam.enabled = false;
            return;
        }
        cam.enabled = true;
    }
}