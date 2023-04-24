using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    float currentHealth;
    public float maxHealth;

    public Slider enemyHealthSlider;
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
            makeDead();
    }
    
    void makeDead(){
        Destroy(gameObject);
    }
}