using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using TMPro;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] private Button hostBtn;
    [SerializeField] private Button clientBtn;
    [SerializeField] private TMP_InputField joinCode;

    private void Awake()
    {
         // START HOST
        hostBtn?.onClick.AddListener(async () =>
        {
            // this allows the UnityMultiplayer and UnityMultiplayerRelay scene to work with and without
            // relay features - if the Unity transport is found and is relay protocol then we redirect all the 
            // traffic through the relay, else it just uses a LAN type (UNET) communication.
            if (RelayManager.Instance.IsRelayEnabled) 
                await RelayManager.Instance.SetupRelay();

            if (NetworkManager.Singleton.StartHost())
                Logger.Instance.LogInfo("Host started...");
            else
                Logger.Instance.LogInfo("Unable to start host...");
        });

        // START CLIENT
        clientBtn?.onClick.AddListener(async () =>
        {
            if (RelayManager.Instance.IsRelayEnabled && !string.IsNullOrEmpty(joinCode.text))
                await RelayManager.Instance.JoinRelay(joinCode.text);

            if(NetworkManager.Singleton.StartClient())
                Logger.Instance.LogInfo("Client started...");
            else
                Logger.Instance.LogInfo("Unable to start client...");
        });
    }
}
