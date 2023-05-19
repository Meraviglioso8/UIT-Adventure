using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using Unity.Netcode;

public class AutoStartHost : MonoBehaviour
{
    public NetworkManager networkManager;
    private void Start()
    {
        

        if (networkManager == null)
        {
            Debug.LogError("NetworkManager component is missing. Please attach the NetworkManager component to the same GameObject.");
            return;
        }

        if (NetworkManager.Singleton.IsHost)
        {
            networkManager.StartClient(); // Start as client if there is a host in the network
        }
        else
        {
            networkManager.StartHost(); // Start as host
        }
    }
}
