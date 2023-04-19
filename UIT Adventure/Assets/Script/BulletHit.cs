using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{

    ProjectTileController myPC;
    // Start is called before the first frame update
    void Awake()
    {
        myPC = GetComponentInParent<ProjectTileController>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Unshootable"){
            myPC.removeForce();
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other){
        if (other.gameObject.tag == "Unshootable"){
            myPC.removeForce();
            Destroy(gameObject);
        }
    }
}
