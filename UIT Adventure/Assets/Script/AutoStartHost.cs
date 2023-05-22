using Unity.Netcode;
using UnityEngine;

public class AutoStartHost : MonoBehaviour
{
    public NetworkManager NetworkManager;
    public string serverIPAddress = "127.0.0.1"; 
    public ushort serverPort = 7777; 

    private void Awake()
    {
        NetworkManager.ServerIPv4Address = serverIPAddress;
        NetworkManager.ServerPort = serverPort;
        NetworkManager.StartHost();
    }
}