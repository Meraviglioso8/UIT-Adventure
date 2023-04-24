using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public float weaponDamage;
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

            if (other.gameObject.layer == LayerMask.NameToLayer("enemy")){
                EnemyHealth hurtEnemy = other.gameObject.GetComponent < EnemyHealth>();
                hurtEnemy.addDamage(weaponDamage);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other){
        if (other.gameObject.tag == "Unshootable"){
            myPC.removeForce();
            Destroy(gameObject);
        }
    }
}
