using UnityEngine;
using UnityEngine.SceneManagement;
using MLAPI;

public class AutoStartHost : MonoBehaviour
{
    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (NetworkManager.Singleton != null && !NetworkManager.Singleton.IsHost)
        {
            NetworkManager.Singleton.StartHost();
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
