using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTileController : MonoBehaviour
{
    public float  bulletSpeed;
    Rigidbody2D myBody;

    void Awake(){
        myBody = GetComponent<Rigidbody2D>();

        // Get the position of the mouse cursor in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        // Calculate the direction vector from the current position of the bullet to the mouse cursor position
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Add a force in the direction of the mouse click
        myBody.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void removeForce(){
        myBody.velocity  = new Vector2 (0,0);
    }
}