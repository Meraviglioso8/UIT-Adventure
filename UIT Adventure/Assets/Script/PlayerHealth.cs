using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float maxHealth;
    float currentHealth;

    //UI variables
    public Slider playerHeathSlider;

    // Start is called before the first frame update
    void Start()
    {
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
