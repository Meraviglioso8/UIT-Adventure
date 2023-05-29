using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class HealObject : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    public Slider playerHeathSlider ;
    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player" ){
            PlayerHealth thePlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
            thePlayerHealth.currentHealth = thePlayerHealth.maxHealth;

        //update slider    
        playerHeathSlider = GameObject.FindGameObjectWithTag ("playerhealthslider")
            .GetComponent<Slider>();
        playerHeathSlider.value = thePlayerHealth.currentHealth;
        }
    }
}
