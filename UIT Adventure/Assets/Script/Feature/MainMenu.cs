using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public void exitButton()
    {
        SceneManager.LoadScene("LoginScene");
    }

    public void startButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void exitloginButton()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void backGameButton()
    {
        SceneManager.LoadScene("MainMenu");
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
