using Unity.Netcode;
using UnityEngine;

public class AutoStartHost : NetworkBehaviour
{
    private static bool isFirstInstance;
    public NetworkManager NetworkManager;

    private void Awake()
    {
        isFirstInstance = PlayerPrefs.GetInt("IsFirstInstance", 1) == 1;

        if (isFirstInstance)
        {
            NetworkManager.OnServerStarted += OnServerStarted;
            NetworkManager.StartHost();
            PlayerPrefs.SetInt("IsFirstInstance", 0);
        }
        else
        {
            NetworkManager.StartClient();
        }
    }

    private void OnDestroy()
    {
        if (NetworkManager.IsServer)
        {
            PlayerPrefs.DeleteKey("IsFirstInstance");
            PlayerPrefs.Save();
        }
    }

    private void OnServerStarted()
    {
        NetworkManager.OnServerStopped += OnServerStopped;
    }

    private void OnServerStopped()
    {
        PlayerPrefs.DeleteKey("IsFirstInstance");
        PlayerPrefs.Save();
    }
}
