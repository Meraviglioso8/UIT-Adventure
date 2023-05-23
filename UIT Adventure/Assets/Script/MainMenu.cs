using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public void exitButton()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void startButton()
    {
        SceneManager.LoadScene(1);
    }

    public void exitloginButton()
    {
        SceneManager.LoadScene(1);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
