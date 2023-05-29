using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class PlayerHealth : NetworkBehaviour
{

    [SerializeField]public float maxHealth;
    [SerializeField]public float currentHealth;

    //UI variables
    public Slider playerHeathSlider ;
    // Start is called before the first frame update
    void Start()
    {
        playerHeathSlider = GameObject.FindGameObjectWithTag ("playerhealthslider")
            .GetComponent<Slider>();
    
        currentHealth = maxHealth;
        playerHeathSlider.maxValue = maxHealth;
        playerHeathSlider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Nhan sat thuong
    public void addDamage(float damage){
        if (damage <= 0)
            return;
        currentHealth -= damage;
        playerHeathSlider.value = currentHealth;
        if (currentHealth <= 0)
            makeDead();
    }
    void makeDead(){
        Destroy(gameObject);
    }
}
