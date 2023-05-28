using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using UnityEngine.Networking;
using System;

public class EnemyHealth : NetworkBehaviour
{
    [SerializeField]float currentHealth;
    [SerializeField]public float maxHealth;
    [SerializeField]public Slider enemyHealthSlider;
    
    //Make the enemy disappear
    [SerializeField] public float targetX = 0f;
    public float targetY = -500f; 
    public float targetZ = 0f;
    
    public NetworkObject networkObject;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        enemyHealthSlider.maxValue = maxHealth;
        enemyHealthSlider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addDamage(float damage){
        currentHealth -= damage;
        enemyHealthSlider.value = currentHealth;
        if (currentHealth <= 0)
            MakeDeadServerRpc();
    }
    
    //destroy() only work locally on server side so i have to call a [ServerRPC]
    //Dont require owership to destroy 
    [ServerRpc(RequireOwnership = false)]
    private void MakeDeadServerRpc()
    {
        networkObject.Despawn(true); 
    }
    private void OnDestroy()
    {

    }
}
