using UnityEngine;
using System.Collections;
using Unity.Netcode;
public class CameraFollow : NetworkBehaviour
{
    [SerializeField]
    public Camera cam;
    
    public GameObject player;
    
    private void Update()
    {
        if (!IsOwner)
        {
            cam.enabled = false;
            return;
        }
        cam.enabled = true;
        cam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -8f);
    }
}