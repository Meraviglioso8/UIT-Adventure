using UITAdventure.Core.Singletons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using TMPro;
using UnityEngine.SceneManagement;

public class NetworkManagerUI : Singleton<NetworkManagerUI>
{
    [SerializeField] private Button hostBtn;
    [SerializeField] private Button clientBtn;
    [SerializeField] private TMP_InputField joinCode;  
    [SerializeField] private Button exitBtn;

    private bool hasServerStarted;

    private void Start()
    {
         // START HOST
        hostBtn?.onClick.AddListener(async () =>
        {
            
            if (RelayManager.Instance.IsRelayEnabled) 
                await RelayManager.Instance.SetupRelay();

            if (NetworkManager.Singleton.StartHost())
            {
                Logger.Instance.LogInfo("Host started...");
                
                SpawnerControl.Instance.SpawnObjects();
                // GameObject player = GameObject.FindGameObjectWithTag("Player");

                // GameObject spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
                // if (spawnPoint != null)
                // {
                //     player.transform.position = spawnPoint.transform.position;
                // }
            }

            else
                Logger.Instance.LogInfo("Unable to start host...");
        });

        // START CLIENT
        clientBtn?.onClick.AddListener(async () =>
        {
            if (RelayManager.Instance.IsRelayEnabled && !string.IsNullOrEmpty(joinCode.text))
                await RelayManager.Instance.JoinRelay(joinCode.text);

            if(NetworkManager.Singleton.StartClient())
            {
                Logger.Instance.LogInfo("Client started...");

                // GameObject player = GameObject.FindGameObjectWithTag("Player");
                
                // GameObject spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
                // if (spawnPoint != null)
                // {
                //     player.transform.position = spawnPoint.transform.position;
                // }
            }
                
            else
                Logger.Instance.LogInfo("Unable to start client...");
        });

        NetworkManager.Singleton.OnClientConnectedCallback += (id) =>
        {
            Logger.Instance.LogInfo($"{id} just connected...");
        };

        NetworkManager.Singleton.OnServerStarted += () =>
        {
            hasServerStarted = true;
        };
        // spawn.onClick.AddListener(() => 
        // {
        //     SpawnerControl.Instance.SpawnObjects();
        // });
    }

    public void onClickExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }    
}
