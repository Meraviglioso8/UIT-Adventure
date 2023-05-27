using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class EndGameCondition : NetworkBehaviour
{
    [SerializeField] public int credits;
    [SerializeField] public int remainEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        remainEnemy = GameObject.FindGameObjectsWithTag("enemy").Length;
        if ((100 - remainEnemy) == credits)
            SceneManager.LoadScene("EndGame");
    }
}
