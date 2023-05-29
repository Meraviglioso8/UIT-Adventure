using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class EndGameCondition : NetworkBehaviour
{
    [SerializeField] public int credits;
    [SerializeField] public int remainEnemy;
    [SerializeField ] public SpawnerControl spawnerControl;

    // Start is called before the first frame update
    void Start()
    {
        spawnerControl = FindObjectOfType<SpawnerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        remainEnemy = GameObject.FindGameObjectsWithTag("enemy").Length;
        if ((spawnerControl.maxObjectInstanceCount - remainEnemy) == credits)
            SceneManager.LoadScene("QuizScene");
    }
}
