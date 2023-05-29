using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField]
    public float damage;
    
    [SerializeField]
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
        }
    }
}
