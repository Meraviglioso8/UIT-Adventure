using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class ProjectTileController : NetworkBehaviour
{
    public float  bulletSpeed;
    Rigidbody2D myBody;

    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        // Calculate the direction vector from the current position of the bullet to the mouse cursor position
        Vector2 direction = (mousePosition - transform.position).normalized;
        // Add a force in the direction of the mouse click
        myBody.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void removeForce(){
        myBody.velocity  = new Vector2 (0,0);
    }
}
