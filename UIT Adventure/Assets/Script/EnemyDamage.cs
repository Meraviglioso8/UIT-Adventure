using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public float damage;
    float dameRate = 0.25f;
    public float pushBackForce;
    float nextDamage;
    // Start is called before the first frame update
    void Start()
    {
        nextDamage = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player" && nextDamage < Time.time){
            PlayerHealth thePlayerHeath = other.gameObject.GetComponent<PlayerHealth>();
            thePlayerHeath.addDamage(damage);
            nextDamage = dameRate + Time.time;
            
            pushBack(other.transform);
        }
    }

    void pushBack(Transform pushedObject){
        Vector2 pushDirection = (pushedObject.position - transform.position).normalized;
        pushDirection *= pushBackForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        //reset luc ve zero
        pushRB.velocity = Vector2.zero;
        //push back
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}
